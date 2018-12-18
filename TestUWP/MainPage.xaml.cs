//using Microsoft.Toolkit.Uwp.UI.Animations;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.System.Diagnostics;
using Windows.UI.Xaml.Controls;

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

            PrintInfoOperatingSystem printInfoOS = new PrintInfoOperatingSystem(rl);

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
            PlatformInfos.Text += Environment.NewLine + printInfoOS.PrintOperatingSystem();
            PlatformInfos.Text += Environment.NewLine + printInfoOS.PrintOperatingSystemVersion();
            PlatformInfos.Text += Environment.NewLine + printInfoOS.PrintOperatingSystemArchitecture();
            PlatformInfos.Text += Environment.NewLine + printInfoOS.PrintIfOperatingSystemIs64Bit();
            PlatformInfos.Text += Environment.NewLine + printInfoOS.PrintDeviceFamily();

            /*
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ToolkitUWP_OperatingSystem/Text") + SystemInformation.OperatingSystem;
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ToolkitUWP_OperatingSystemVersion/Text") +
                SystemInformation.OperatingSystemVersion + " (from SystemInformation) ; " +
                Environment.OSVersion + " (from Environment)";
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ToolkitUWP_OperatingSystemArchitecture/Text") + SystemInformation.OperatingSystemArchitecture;
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ToolkitUWP_Is64BitOperatingSystem/Text") + Environment.Is64BitOperatingSystem;
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ToolkitUWP_DeviceFamily/Text") + SystemInformation.DeviceFamily;
            */

            // Infos hardware UWP Toolkit
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ToolkitUWP_Is64BitProcessor/Text") + Environment.Is64BitProcess;
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ToolkitUWP_NumberProcessorCore/Text") + Environment.ProcessorCount;
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ToolkitUWP_AvailableMemory/Text") + SystemInformation.AvailableMemory + " MB";
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ToolkitUWP_MachineName/Text") + Environment.MachineName;
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ToolkitUWP_DeviceManufacturer/Text") + SystemInformation.DeviceManufacturer;
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ToolkitUWP_DeviceModel/Text") + SystemInformation.DeviceModel;

            // Diagnostique du processus

            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ResourcesUsage/Text") + ProcessDiagnosticInfo.GetForCurrentProcess().CpuUsage.GetReport();
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ResourcesUsage/Text") + ProcessDiagnosticInfo.GetForCurrentProcess().MemoryUsage.GetReport();
            PlatformInfos.Text += Environment.NewLine +
                rl.GetString("ResourcesUsage/Text") + ProcessDiagnosticInfo.GetForCurrentProcess().DiskUsage.GetReport();

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

            // Voir aussi : connexion limitée ? Type de co (Ethernet, Wi-Fi, 4G, etc.) ?

            // Autres infos
            TimeSpan timeSpendSinceStart = getTimeSpendSinceStart(); // Jours, heures, minutes, secondes, millisecondes
            DateTime startDate = DateTime.Now - timeSpendSinceStart; // Année, mois, jours, heures, minutes, secondes, millisecondes

            OthersInfos.Text =
                rl.GetString("Others_SystemStartDate/Text") +
                startDate +
                Environment.NewLine +
                rl.GetString("Others_TimeElapsedSinceSystemStart/Text") +
                timeSpendSinceStart.ToString() +
                Environment.NewLine +
                rl.GetString("Others_TimeElapsedSinceAppStart/Text") +
                SystemInformation.AppUptime;
        }

        private TimeSpan getTimeSpendSinceStart()
        {
            return new TimeSpan(0, 0, 0, 0, Environment.TickCount); // Jours, heures, minutes, secondes, millisecondes
        }

        private string timeSpendSinceStart_String()
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
