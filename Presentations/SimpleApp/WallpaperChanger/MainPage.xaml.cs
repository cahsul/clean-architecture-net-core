using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Microsoft.Win32;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WallpaperChanger
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern Int32 SystemParametersInfo(
        UInt32 action, UInt32 uParam, String vParam, UInt32 winIni);

        private static readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
        private static readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
        private static readonly UInt32 SPIF_SENDWININICHANGE = 0x02;


        public MainPage()
        {
            this.InitializeComponent();
        }

		private async void btnChange_Click(object sender, RoutedEventArgs e)
		{
            string imgWallpaper = @"C:\Users\csw\Pictures\wp2646303.jpg";

            // verify    
            //if (File.Exists(imgWallpaper))
            //{
                SetWallpaper(imgWallpaper);
            //}
        }


        static public void SetWallpaper(String path)
        {
            using (RegistryKey keys = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
            {
                //Read your subkeys here
                //RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
                keys.SetValue(@"WallpaperStyle", 0.ToString()); // 2 is stretched
                keys.SetValue(@"TileWallpaper", 0.ToString());

                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
            }


           
        }
    }
}
