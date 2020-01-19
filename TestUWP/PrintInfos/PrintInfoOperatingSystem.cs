using System.Runtime.InteropServices;
using TestUWP.GetInfos;
using Windows.ApplicationModel.Resources;

namespace TestUWP.PrintInfos
{
    public class PrintInfoOperatingSystem
    {
        private readonly ResourceLoader rl;

        public PrintInfoOperatingSystem(ResourceLoader rl)
        {
            this.rl = rl;
        }

        public string PrintOperatingSystem()
        {
            string baseString = rl.GetString("InfoPlatform_OperatingSystem/Text");

            switch (InfoOperatingSystem.GetOperatingSystem())
            {
                case "WINDOWS":
                    return baseString + "Windows";
                case "OSX":
                    return baseString + "macOS";
                case "LINUX":
                    return baseString + "Linux";
            }

            return rl.GetString("InfoPlatform_OperatingSystem/Text") +
                InfoOperatingSystem.GetOperatingSystem();
        }

        public string PrintOperatingSystemVersion()
        {
            return rl.GetString("InfoPlatform_OperatingSystemVersion/Text") +
                InfoOperatingSystem.GetOperatingSystemVersion_FromSysInf();
        }

        public string PrintOperatingSystemArchitecture()
        {
            string baseString = rl.GetString("InfoPlatform_OperatingSystemArchitecture/Text");

            switch (InfoOperatingSystem.GetOSArchitecture())
            {
                case Architecture.X86:
                    return baseString + rl.GetString("InfoPlatform_OperatingSystemArchitecture_X86/Text");
                case Architecture.X64:
                    return baseString + rl.GetString("InfoPlatform_OperatingSystemArchitecture_X64/Text");
                case Architecture.Arm:
                    return baseString + rl.GetString("InfoPlatform_OperatingSystemArchitecture_Arm/Text");
                case Architecture.Arm64:
                    return baseString + rl.GetString("InfoPlatform_OperatingSystemArchitecture_Arm64/Text");
            }

            return baseString + InfoOperatingSystem.GetOSArchitecture().ToString();
        }

        public string PrintIfOperatingSystemIs64Bit()
        {
            if (InfoOperatingSystem.Is64BitOperatingSystem())
                return rl.GetString("InfoPlatform_OperatingSystemIs64Bit/Text");
            else
                return rl.GetString("InfoPlatform_OperatingSystemIsNot64Bit/Text");
        }

        public string PrintDeviceFamily()
        {
            return rl.GetString("InfoPlatform_DeviceFamily/Text") +
                InfoOperatingSystem.GetDeviceFamily().Replace('.', ' ');
        }
    }
}
