using System;
using TestUWP.GetInfos;
using Windows.ApplicationModel.Resources;
using Windows.Graphics.Display;

namespace TestUWP.PrintInfos
{
    public class PrintInfoScreen
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
            string baseString = rl.GetString("InfoScreen_ResolutionScale/Text");

            switch (InfoScreen.GetResolutionScale())
            {
                case ResolutionScale.Invalid:
                    return baseString + rl.GetString("InfoScreen_ResolutionScale_Invalid.Text");
                case ResolutionScale.Scale100Percent:
                    return baseString + "100%";
                case ResolutionScale.Scale120Percent:
                    return baseString + "120%";
                case ResolutionScale.Scale125Percent:
                    return baseString + "125%";
                case ResolutionScale.Scale140Percent:
                    return baseString + "140%";
                case ResolutionScale.Scale150Percent:
                    return baseString + "150%";
                case ResolutionScale.Scale160Percent:
                    return baseString + "160%";
                case ResolutionScale.Scale175Percent:
                    return baseString + "175%";
                case ResolutionScale.Scale180Percent:
                    return baseString + "180%";
                case ResolutionScale.Scale200Percent:
                    return baseString + "200%";
                case ResolutionScale.Scale225Percent:
                    return baseString + "225%";
                case ResolutionScale.Scale250Percent:
                    return baseString + "250%";
                case ResolutionScale.Scale300Percent:
                    return baseString + "300%";
                case ResolutionScale.Scale350Percent:
                    return baseString + "350%";
                case ResolutionScale.Scale400Percent:
                    return baseString + "400%";
                case ResolutionScale.Scale450Percent:
                    return baseString + "450%";
                case ResolutionScale.Scale500Percent:
                    return baseString + "500%";
            }

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
