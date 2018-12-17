using Microsoft.Toolkit.Uwp.Helpers;
using System;
using Windows.System;

namespace TestUWP
{
    /// <summary>
    /// This class provides information about the hardware of the machine.
    /// </summary>
    public static class HardwareInfo
    {
        /// <summary>
        /// Gets the processor architecture from the Windows Community Toolkit.
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/windows/communitytoolkit/helpers/systeminformation
        /// </summary>
        /// <returns></returns>
        public static ProcessorArchitecture GetProcessorArchitecture()
        {
            return SystemInformation.OperatingSystemArchitecture;
        }

        /// <summary>
        /// Determines whether the current process is a 64-bit process.
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/dotnet/api/system.environment.is64bitprocess
        /// </summary>
        /// <returns></returns>
        public static bool Is64BitProcessor()
        {
            return Environment.Is64BitProcess;
        }

        /// <summary>
        /// Gets the number of logicals processors on the current machine.
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/dotnet/api/system.environment.processorcount
        /// </summary>
        /// <returns></returns>
        public static int GetProcessorCount()
        {
            return Environment.ProcessorCount;
        }

        /// <summary>
        /// Gets amount of available memory for this application in MB.
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/dotnet/api/microsoft.toolkit.uwp.helpers.systeminformation.availablememory
        /// </summary>
        /// <returns></returns>
        public static float GetAvailableMemory()
        {
            return SystemInformation.AvailableMemory;
        }

        /// <summary>
        /// Gets the number of bytes in the operating system's memory page.
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/dotnet/api/system.environment.systempagesize
        /// </summary>
        /// <returns></returns>
        public static float GetMemoryPageSize()
        {
            return Environment.SystemPageSize;
        }

        /// <summary>
        /// Gets the amount of physical memory mapped to the process context.
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/dotnet/api/system.environment.workingset
        /// </summary>
        /// <returns></returns>
        public static float GetPhysicalMemoryMapped()
        {
            return Environment.WorkingSet;
        }

        /// <summary>
        /// Gets the NetBIOS name of this local computer.
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/dotnet/api/system.environment.machinename
        /// </summary>
        /// <returns></returns>
        public static string GetMachineName()
        {
            return Environment.MachineName;
        }

        /// <summary>
        /// Gets device's manufacturer. Will be empty if the device manufacturer couldn't be determined (ex: when running in a virtual machine).
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/dotnet/api/microsoft.toolkit.uwp.helpers.systeminformation.devicemanufacturer
        /// </summary>
        /// <returns></returns>
        public static string GetDeviceManufacturer()
        {
            return SystemInformation.DeviceManufacturer;
        }

        /// <summary>
        /// Gets device model. Will be empty if the device model couldn't be determined (ex: when running in a virtual machine).
        /// 
        /// More infos:
        /// https://docs.microsoft.com/en-us/dotnet/api/microsoft.toolkit.uwp.helpers.systeminformation.devicemodel
        /// </summary>
        /// <returns></returns>
        public static string GtDeviceModel()
        {
            return SystemInformation.DeviceModel;
        }
    }
}
