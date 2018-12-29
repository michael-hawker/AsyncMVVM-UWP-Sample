using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncMVVMApp
{
    /// <summary>
    /// Example service which returns the length of content at the given URL.
    /// </summary>
    public static class MyStaticService
    {
        // This is the original example method from the first article on databinding.
        public static async Task<int> CountBytesInUrlAsync(string url)
        {
            // Artificial delay to show responsiveness.
            await Task.Delay(TimeSpan.FromSeconds(3)).ConfigureAwait(false);

            // Download the actual data and count it.
            using (var client = new HttpClient())
            {
                var data = await client.GetByteArrayAsync(new Uri(url)).ConfigureAwait(false);

                return data.Length;
            }
        }

        // This is the same method as above but also supports cancellation used in the second article.
        public static async Task<int> DownloadAndCountBytesAsync(string url,
            CancellationToken token = new CancellationToken())
        {
            // Artificial delay to show responsiveness.
            await Task.Delay(TimeSpan.FromSeconds(5), token).ConfigureAwait(false);

            // Download the actual data and count it.
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(new Uri(url), token).ConfigureAwait(false))
                {
                    var data = await
                      response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    return data.Length;
                }
            }
        }
    }
}
