using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CefSharp;
using Songify_Slim.Views;

namespace Songify_Slim.Util.Songify
{
    internal class CefSharpApi : IJavascriptCallback
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<JavascriptResponse> ExecuteAsync(params object[] parms)
        {
            throw new NotImplementedException();
        }

        public Task<JavascriptResponse> ExecuteWithTimeoutAsync(TimeSpan? timeout, params object[] parms)
        {
            throw new NotImplementedException();
        }

        public void VideoFinished()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                foreach (Window win in Application.Current.Windows)
                {
                    if (!(win is Window_Youtube youtube)) continue;
                    youtube.PlayNextSong();
                    return;
                }
            });
        }

        public long Id { get; }
        public bool CanExecute { get; }
        public bool IsDisposed { get; }

    }
}
