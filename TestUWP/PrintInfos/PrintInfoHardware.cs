using TestUWP.GetInfos;
using Windows.ApplicationModel.Resources;
using Windows.System;

namespace TestUWP.PrintInfos
{
    public class PrintInfoHardware
    {
        private readonly ResourceLoader rl;

        public PrintInfoHardware(ResourceLoader rl)
        {
            this.rl = rl;
        }

        public string PrintMachineName()
        {
            return rl.GetString("InfoPlatform_MachineName/Text") +
                InfoHardware.GetMachineName();
        }

        public string PrintDeviceManufacturer()
        {
            return rl.GetString("InfoPlatform_DeviceManufacturer/Text") +
                InfoHardware.GetDeviceManufacturer();
        }

        public string PrintDeviceModel()
        {
            return rl.GetString("InfoPlatform_DeviceModel/Text") +
                InfoHardware.GetDeviceModel();
        }

        public string PrintProcessorArchitecture()
        {
            string baseString = rl.GetString("InfoPlatform_ProcessorArchitecture/Text");

            switch (InfoHardware.GetProcessorArchitecture())
            {
                case ProcessorArchitecture.X86:
                    return baseString + rl.GetString("InfoPlatform_ProcessorArchitecture_X86/Text");
                case ProcessorArchitecture.X64:
                    return baseString + rl.GetString("InfoPlatform_ProcessorArchitecture_X64/Text");
                case ProcessorArchitecture.Arm:
                    return baseString + rl.GetString("InfoPlatform_ProcessorArchitecture_Arm/Text");
                case ProcessorArchitecture.Neutral:
                    return baseString + rl.GetString("InfoPlatform_ProcessorArchitecture_Neutral/Text");
                case ProcessorArchitecture.Unknown:
                    return baseString + rl.GetString("InfoPlatform_ProcessorArchitecture_Unknown/Text");
            }

            return baseString + InfoHardware.GetProcessorArchitecture().ToString();
        }

        public string PrintIf64BitProcessor()
        {
            if (InfoHardware.Is64BitProcessor())
                return rl.GetString("InfoPlatform_ProcessorIs64Bit/Text");
            else
                return rl.GetString("InfoPlatform_ProcessorIsNot64Bit/Text");
        }

        public string PrintProcessorCount()
        {
            return rl.GetString("InfoPlatform_NumberProcessorCore/Text") +
                InfoHardware.GetProcessorCount();
        }

        public string PrintAvailableMemory()
        {
            return rl.GetString("InfoPlatform_AvailableMemory/Text") +
                InfoHardware.GetAvailableMemory();
        }

        public string PrintMemoryPageSize()
        {
            return rl.GetString("InfoPlatform_MemoryPageSize/Text") +
                InfoHardware.GetMemoryPageSize();
        }

        public string PrintPhysicalMemoryMapped()
        {
            return rl.GetString("InfoPlatform_PhysicalMemoryMapped/Text") +
                InfoHardware.GetPhysicalMemoryMapped();
        }
    }
}
