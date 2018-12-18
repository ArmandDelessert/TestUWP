using Windows.Foundation;
using Windows.Graphics.Display;

namespace TestUWP
{
    /// <summary>
    /// This class provides information about the screen.
    /// 
    /// À ajouter :
    /// - Plusieurs écrans ? Infos sur chacun ?
    /// </summary>
    public static class InfoScreen
    {
        public static Size GetScreenSize()
        {
            return new Size
            {
                Width = DisplayInformation.GetForCurrentView().ScreenWidthInRawPixels,
                Height = DisplayInformation.GetForCurrentView().ScreenHeightInRawPixels
            };
        }

        public static double GetScaleFactor()
        {
            return DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
        }

        public static Size GetRawDpi()
        {
            return new Size
            {
                Width = DisplayInformation.GetForCurrentView().RawDpiX,
                Height = DisplayInformation.GetForCurrentView().RawDpiY
            };
        }

        public static ResolutionScale GetResolutionScale()
        {
            return DisplayInformation.GetForCurrentView().ResolutionScale;
        }

        public static DisplayOrientations GetDisplayNativeOrientations()
        {
            return DisplayInformation.GetForCurrentView().NativeOrientation;
        }

        public static DisplayOrientations GetDisplayCurrentOrientations()
        {
            return DisplayInformation.GetForCurrentView().CurrentOrientation;
        }
    }
}
