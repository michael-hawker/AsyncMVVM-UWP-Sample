using AsyncMVVMApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncMVVMApp
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            UrlByteCount = new NotifyTaskCompletion<int>(
              MyStaticService.CountBytesInUrlAsync("http://www.bing.com"));
        }

        public NotifyTaskCompletion<int> UrlByteCount { get; private set; }
    }
}
