using System;
using Windows.ApplicationModel.Resources;

namespace TestUWP
{
    class PrintInfoScreen
    {
        private readonly ResourceLoader rl;

        public PrintInfoScreen(ResourceLoader rl)
        {
            this.rl = rl;
        }

        public string PrintScreenSize()
        {
            return rl.GetString("InfoScreen_Size/Text")
                + InfoScreen.GetScreenSize().Width + " × " + InfoScreen.GetScreenSize().Height;
        }

        public string PrintRawDpi()
        {
            return rl.GetString("InfoScreen_PpiX/Text") + InfoScreen.GetRawDpi().Width +
                Environment.NewLine +
                rl.GetString("InfoScreen_PpiY/Text") + InfoScreen.GetRawDpi().Height;
        }

        public string PrintScaleFactor()
        {
            return rl.GetString("InfoScreen_ScaleFactor/Text") + InfoScreen.GetScaleFactor();
        }

        public string PrintResolutionScale()
        {
            return rl.GetString("InfoScreen_ResolutionScale/Text") + InfoScreen.GetResolutionScale();
        }

        public string PrintDisplayNativeOrientation()
        {
            return rl.GetString("InfoScreen_NativeOrientation/Text") +
                InfoScreen.GetDisplayNativeOrientation();
        }

        public string PrintDisplayCurrentOrientation()
        {
            return rl.GetString("InfoScreen_CurrentOrientation/Text") +
                InfoScreen.GetDisplayCurrentOrientation();
        }
    }
}
