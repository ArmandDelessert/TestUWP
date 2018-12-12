//using Microsoft.Toolkit.Uwp.UI.Animations;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.System;
using Windows.UI.Xaml.Controls;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestUWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            ResourceLoader rl = ResourceLoader.GetForCurrentView();

            // Infos système d'exploitation
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("PlatformInfos_OSPlatform/Text") +
                (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? OSPlatform.Windows.ToString() :
                RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? OSPlatform.OSX.ToString() :
                RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? OSPlatform.Linux.ToString() :
                "Unknown");

            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("PlatformInfos_OSDescription/Text") + RuntimeInformation.OSDescription;

            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("PlatformInfos_OSArchitecture/Text") + RuntimeInformation.OSArchitecture;

            // Infos OS UWP Toolkit
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ToolkitUWP_OperatingSystem/Text") + SystemInformation.OperatingSystem;
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ToolkitUWP_OperatingSystemVersion/Text") + SystemInformation.OperatingSystemVersion;
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ToolkitUWP_OperatingSystemArchitecture/Text") + SystemInformation.OperatingSystemArchitecture;
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ToolkitUWP_DeviceFamily/Text") + SystemInformation.DeviceFamily;

            // Infos hardware UWP Toolkit
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ToolkitUWP_NumberProcessorCore/Text") + 4;
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ToolkitUWP_AvailableMemory/Text") + SystemInformation.AvailableMemory;
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ToolkitUWP_DeviceManufacturer/Text") + SystemInformation.DeviceManufacturer;
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ToolkitUWP_DeviceModel/Text") + SystemInformation.DeviceModel;


            // Récupération des informations sur l'écran
            Size screenSize_Pixels = new Size
            {
                Width = DisplayInformation.GetForCurrentView().ScreenWidthInRawPixels,
                Height = DisplayInformation.GetForCurrentView().ScreenHeightInRawPixels
            };

            double scaleFactor = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;

            float rawDpiX = DisplayInformation.GetForCurrentView().RawDpiX;
            float rawDpiY = DisplayInformation.GetForCurrentView().RawDpiY;
            ResolutionScale resolutionScale = DisplayInformation.GetForCurrentView().ResolutionScale;
            DisplayOrientations displayNativeOrientation = DisplayInformation.GetForCurrentView().NativeOrientation;
            DisplayOrientations displayCurrentOrientation = DisplayInformation.GetForCurrentView().CurrentOrientation;

            ScreenInfos.Text = rl.GetString("ScreenInfos_Size/Text") + screenSize_Pixels.Width + " × " + screenSize_Pixels.Height;
            ScreenInfos.Text +=
                Environment.NewLine + rl.GetString("ScreenInfos_PpiX/Text") + rawDpiX +
                Environment.NewLine + rl.GetString("ScreenInfos_PpiY/Text") + rawDpiY;

            ScreenInfos.Text += Environment.NewLine +
                rl.GetString("ScreenInfos_Scale/Text") + resolutionScale;

            ScreenInfos.Text += Environment.NewLine +
                rl.GetString("ScreenInfos_NativeOrientation/Text") + displayNativeOrientation;
            ScreenInfos.Text += Environment.NewLine +
                rl.GetString("ScreenInfos_CurrentOrientation/Text") + displayCurrentOrientation;

            // Connexion réseau/Internet
            bool isNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();

            NetworkInfos.Text = rl.GetString("NetworkInfos_IsAvailable/Text") + isNetworkAvailable;

            // Autres infos
            TimeSpan timeSpendSinceStart = getTimeSpendSinceStart(); // Jours, heures, minutes, secondes, millisecondes
            DateTime startDate = DateTime.Now - timeSpendSinceStart; // Année, mois, jours, heures, minutes, secondes, millisecondes

            OtherInfos.Text =
                rl.GetString("Other_SystemStartDate/Text") +
                startDate +
                Environment.NewLine +
                rl.GetString("Other_TimeElapsedSinceSystemStart/Text") +
                timeSpendSinceStart.ToString() +
                Environment.NewLine +
                rl.GetString("Other_TimeElapsedSinceAppStart/Text") +
                SystemInformation.AppUptime;
        }

        private TimeSpan getTimeSpendSinceStart()
        {
            return new TimeSpan(0, 0, 0, 0, Environment.TickCount); // Jours, heures, minutes, secondes, millisecondes
        }

        private String timeSpendSinceStart_String()
        {
            TimeSpan t = getTimeSpendSinceStart();

            return
                "System started since " +
                t.Days + " days, " +
                t.Hours + " hours, " +
                t.Minutes + " minutes, " +
                t.Seconds + " seconds, " +
                t.Milliseconds + " milliseconds.";
        }
    }
}
