using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace AsyncMVVMApp
{
    /// <summary>
    /// Example service which returns the length of content at the given URL.
    /// </summary>
    public static class MyStaticService
    {
        public static async Task<int> CountBytesInUrlAsync(string url)
        {
            // Artificial delay to show responsiveness.
            await Task.Delay(TimeSpan.FromSeconds(3)).ConfigureAwait(false);

            // Download the actual data and count it.
            using (var client = new HttpClient())
            {
                var data = await client.GetBufferAsync(new Uri(url));

                return (int)data.Length;
            }
        }
    }
}
