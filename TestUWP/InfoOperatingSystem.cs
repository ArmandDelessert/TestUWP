using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Runtime.InteropServices;

namespace TestUWP
{
    /// <summary>
    /// This class provides information about the operating system.
    /// </summary>
    public static class InfoOperatingSystem
    {
        /// Infos from Microsoft.Toolkit.Uwp.Helpers.SystemInformation
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/dotnet/api/microsoft.toolkit.uwp.helpers.systeminformation

        /// <summary>
        /// Gets the operating system's name from the Windows Community Toolkit.
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/windows/communitytoolkit/helpers/systeminformation
        /// </summary>
        /// <returns></returns>
        public static string GetOperatingSystem()
        {
            return SystemInformation.OperatingSystem;
        }

        /// <summary>
        /// Gets the operating system's version from the Windows Community Toolkit.
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/windows/communitytoolkit/helpers/systeminformation
        /// </summary>
        /// <returns></returns>
        public static OSVersion GetOperatingSystemVersion_FromSysInf()
        {
            return SystemInformation.OperatingSystemVersion;
        }

        /// <summary>
        /// Gets device's family.
        /// Common values include:
        /// "Windows.Desktop", "Windows.Mobile", "Windows.Xbox",
        /// "Windows.Holographic", "Windows.Team", "Windows.IoT".
        /// Prepare your code for other values.
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/dotnet/api/microsoft.toolkit.uwp.helpers.systeminformation.devicefamily
        /// </summary>
        /// <returns></returns>
        public static string GetDeviceFamily()
        {
            return SystemInformation.DeviceFamily;
        }


        /// Infos from System.Environment
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/dotnet/api/system.environment

        /// <summary>
        /// Gets an OperatingSystem object that contains the current platform identifier and version number.
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/dotnet/api/system.environment.osversion
        /// </summary>
        /// <returns></returns>
        public static OperatingSystem GetOperatingSystemVersion_FromEnv()
        {
            return Environment.OSVersion;
        }

        /// <summary>
        /// Determines whether the current operating system is a 64-bit operating system.
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/dotnet/api/system.environment.is64bitoperatingsystem
        /// </summary>
        /// <returns></returns>
        public static bool Is64BitOperatingSystem()
        {
            return Environment.Is64BitOperatingSystem;
        }


        /// Infos from System.Runtime.InteropServices.RuntimeInformation
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.runtimeinformation

        /// <summary>
        /// Get the current platform (Windows, macOS or Linux).
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.runtimeinformation.isosplatform
        /// https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.osplatform
        /// </summary>
        /// <returns></returns>
        public static OSPlatform GetOSPlatform()
        {
            return
                RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? OSPlatform.Windows :
                RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? OSPlatform.OSX :
                RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? OSPlatform.Linux :
                new OSPlatform();
        }

        /// <summary>
        /// Gets a string that describes the operating system on which the app is running.
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.runtimeinformation.osdescription
        /// </summary>
        /// <returns></returns>
        public static string GetOSDescription()
        {
            return RuntimeInformation.OSDescription;
        }

        /// <summary>
        /// Gets the platform architecture on which the current app is running.
        /// Possible architectures: X86, X64, Arm, Arm64
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.runtimeinformation.osarchitecture
        /// https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.architecture
        /// </summary>
        /// <returns></returns>
        public static Architecture GetOSArchitecture()
        {
            return RuntimeInformation.OSArchitecture;
        }
    }
}
