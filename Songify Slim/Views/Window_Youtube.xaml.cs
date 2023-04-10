using CefSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Songify_Slim.Util.General;
using Songify_Slim.Util.Songify;

namespace Songify_Slim.Views
{
    /// <summary>
    /// Interaction logic for Window_Youtube.xaml
    /// </summary>
    public partial class Window_Youtube
    {
        public Window_Youtube()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            browser.JavascriptObjectRepository.Register("cefSharpApi", new CefSharpApi(), true);
            LbPlaylist.ItemsSource = GlobalObjects.YoutubePlaylist;
        }

        public void PlayNextSong()
        {
            if (GlobalObjects.YoutubePlaylist.Count <= 0) return;
            Debug.WriteLine($"https://songify.overcode.tv/youtube/index.html?id={GlobalObjects.YoutubePlaylist[0]}");
            browser.Address = $"https://songify.overcode.tv/youtube/index.html?id={GlobalObjects.YoutubePlaylist[0]}";

            browser.ExecuteScriptAsync(@"
                    var player = document.getElementById('my-player');
                    player.addEventListener('onStateChange', function(event) {
                        if (event.data === 0) { // Video has finished playing
                            window.cefSharpApi.videoFinished();
                        }
                    });
                ");
            GlobalObjects.YoutubePlaylist.RemoveAt(0);
            LbPlaylist.Items.Refresh();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            PlayNextSong();
        }
    }
}
