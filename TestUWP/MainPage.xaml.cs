//using Microsoft.Toolkit.Uwp.UI.Animations;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Net.NetworkInformation;
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
            PrintInfoHardware printInfoHw = new PrintInfoHardware(rl);

            // Infos système d'exploitation
            InfoPlatform.Text += Environment.NewLine + printInfoOS.PrintOperatingSystem();
            InfoPlatform.Text += Environment.NewLine + printInfoOS.PrintOperatingSystemVersion();
            InfoPlatform.Text += Environment.NewLine + printInfoOS.PrintOperatingSystemArchitecture();
            InfoPlatform.Text += Environment.NewLine + printInfoOS.PrintIfOperatingSystemIs64Bit();
            InfoPlatform.Text += Environment.NewLine + printInfoOS.PrintDeviceFamily();

            InfoPlatform.Text += Environment.NewLine;

            // Infos hardware
            InfoPlatform.Text += Environment.NewLine + printInfoHw.PrintMachineName();
            InfoPlatform.Text += Environment.NewLine + printInfoHw.PrintDeviceManufacturer();
            InfoPlatform.Text += Environment.NewLine + printInfoHw.PrintDeviceModel();
            InfoPlatform.Text += Environment.NewLine + printInfoHw.PrintProcessorArchitecture();
            InfoPlatform.Text += Environment.NewLine + printInfoHw.PrintIf64BitProcessor();
            InfoPlatform.Text += Environment.NewLine + printInfoHw.PrintProcessorCount();
            InfoPlatform.Text += Environment.NewLine + printInfoHw.PrintAvailableMemory();
            InfoPlatform.Text += Environment.NewLine + printInfoHw.PrintMemoryPageSize();
            InfoPlatform.Text += Environment.NewLine + printInfoHw.PrintPhysicalMemoryMapped();

            InfoPlatform.Text += Environment.NewLine;

            // Diagnostique du processus
            InfoPlatform.Text += Environment.NewLine +
                rl.GetString("ResourcesUsage/Text") + ProcessDiagnosticInfo.GetForCurrentProcess().CpuUsage.GetReport();
            InfoPlatform.Text += Environment.NewLine +
                rl.GetString("ResourcesUsage/Text") + ProcessDiagnosticInfo.GetForCurrentProcess().MemoryUsage.GetReport();
            InfoPlatform.Text += Environment.NewLine +
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

            InfoScreen.Text = rl.GetString("InfoScreen_Size/Text") + screenSize_Pixels.Width + " × " + screenSize_Pixels.Height;
            InfoScreen.Text +=
                Environment.NewLine + rl.GetString("InfoScreen_PpiX/Text") + rawDpiX +
                Environment.NewLine + rl.GetString("InfoScreen_PpiY/Text") + rawDpiY;

            InfoScreen.Text += Environment.NewLine +
                rl.GetString("InfoScreen_Scale/Text") + resolutionScale;

            InfoScreen.Text += Environment.NewLine +
                rl.GetString("InfoScreen_NativeOrientation/Text") + displayNativeOrientation;
            InfoScreen.Text += Environment.NewLine +
                rl.GetString("InfoScreen_CurrentOrientation/Text") + displayCurrentOrientation;

            // Connexion réseau/Internet
            bool isNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();

            InfoNetwork.Text = rl.GetString("InfoNetwork_IsAvailable/Text") + isNetworkAvailable;

            // Voir aussi : connexion limitée ? Type de co (Ethernet, Wi-Fi, 4G, etc.) ?

            // Autres infos
            TimeSpan timeSpendSinceStart = getTimeSpendSinceStart(); // Jours, heures, minutes, secondes, millisecondes
            DateTime startDate = DateTime.Now - timeSpendSinceStart; // Année, mois, jours, heures, minutes, secondes, millisecondes

            InfoOthers.Text =
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
