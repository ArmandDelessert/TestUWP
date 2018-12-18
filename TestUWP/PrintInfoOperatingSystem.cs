using System.Runtime.InteropServices;
using Windows.ApplicationModel.Resources;

namespace TestUWP
{
    class PrintInfoOperatingSystem
    {
        private ResourceLoader rl;

        public PrintInfoOperatingSystem(ResourceLoader rl)
        {
            this.rl = rl;
        }

        public string PrintOperatingSystem()
        {
            switch (InfoOperatingSystem.GetOSPlatform().ToString())
            {
                case "WINDOWS":
                    return rl.GetString("ToolkitUWP_OperatingSystem/Text") + 
                        "Windows";
                case "OSX":
                    return rl.GetString("ToolkitUWP_OperatingSystem/Text") + 
                        "macOS";
                case "LINUX":
                    return rl.GetString("ToolkitUWP_OperatingSystem/Text") + 
                        "Linux";
            }

            return rl.GetString("ToolkitUWP_OperatingSystem/Text") +
                InfoOperatingSystem.GetOperatingSystem();
        }

        public string PrintOperatingSystemVersion()
        {
            return rl.GetString("ToolkitUWP_OperatingSystemVersion/Text") +
                InfoOperatingSystem.GetOperatingSystemVersion_FromSysInf();
        }

        public string PrintOperatingSystemArchitecture()
        {
            switch (InfoOperatingSystem.GetOSArchitecture())
            {
                case Architecture.X86:
                    return rl.GetString("ToolkitUWP_OperatingSystemArchitecture/Text") +
                        "Intel-based 32-bit processor architecture";
                case Architecture.X64:
                    return rl.GetString("ToolkitUWP_OperatingSystemArchitecture/Text") +
                        "Intel-based 64-bit processor architecture";
                case Architecture.Arm:
                    return rl.GetString("ToolkitUWP_OperatingSystemArchitecture/Text") +
                        "32-bit ARM processor architecture";
                case Architecture.Arm64:
                    return rl.GetString("ToolkitUWP_OperatingSystemArchitecture/Text") +
                        "64-bit ARM processor architecture";
            }

            return InfoOperatingSystem.GetOSArchitecture().ToString();
        }

        public string PrintIfOperatingSystemIs64Bit()
        {
            if (InfoOperatingSystem.Is64BitOperatingSystem())
                return rl.GetString("ToolkitUWP_OperatingSystem64Bit/Text");
            else
                return rl.GetString("ToolkitUWP_OperatingSystemNon64Bit/Text");
        }

        public string PrintDeviceFamily()
        {
            return rl.GetString("ToolkitUWP_DeviceFamily/Text") +
                InfoOperatingSystem.GetDeviceFamily();
        }
    }
}
