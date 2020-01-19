//using Microsoft.Toolkit.Uwp.UI.Animations;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Net.NetworkInformation;
using TestUWP.PrintInfos;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.Networking.Connectivity;
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
            PrintInfoScreen printInfoScreen = new PrintInfoScreen(rl);
            PrintInfoNetwork printInfoNetwork = new PrintInfoNetwork(rl);

            // Infos système d'exploitation
            InfoPlatform.Text = printInfoOS.PrintOperatingSystem();
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

            InfoPlatform.Text += Environment.NewLine + ".";

            // Diagnostique du processus
            InfoPlatform.Text += Environment.NewLine +
                rl.GetString("ResourcesUsage/Text") + ProcessDiagnosticInfo.GetForCurrentProcess().CpuUsage.GetReport().KernelTime + " (KernelTime)";
            InfoPlatform.Text += Environment.NewLine +
                rl.GetString("ResourcesUsage/Text") + ProcessDiagnosticInfo.GetForCurrentProcess().MemoryUsage.GetReport().VirtualMemorySizeInBytes /(2^30) + " GB (VirtualMemorySizeInBytes)";
            InfoPlatform.Text += Environment.NewLine +
                rl.GetString("ResourcesUsage/Text") + ProcessDiagnosticInfo.GetForCurrentProcess().DiskUsage.GetReport().BytesReadCount + " (BytesReadCount)";

            // Récupération des informations sur l'écran
            InfoScreen.Text = printInfoScreen.PrintScreenSize();
            InfoScreen.Text += Environment.NewLine + printInfoScreen.PrintRawDpi();
            InfoScreen.Text += Environment.NewLine + printInfoScreen.PrintScaleFactor();
            InfoScreen.Text += Environment.NewLine + printInfoScreen.PrintResolutionScale();
            InfoScreen.Text += Environment.NewLine + printInfoScreen.PrintDisplayNativeOrientation();
            InfoScreen.Text += Environment.NewLine + printInfoScreen.PrintDisplayCurrentOrientation();

            // Connexion réseau/Internet
            InfoNetwork.Text = printInfoNetwork.PrintIfNetworkAvailable();
            InfoNetwork.Text += Environment.NewLine + printInfoNetwork.PrintNetworkConnectivityLevel();
            InfoNetwork.Text += Environment.NewLine + printInfoNetwork.PrintNetworkCostType();

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
