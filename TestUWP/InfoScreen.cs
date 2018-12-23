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

        public static Size GetRawDpi()
        {
            return new Size
            {
                Width = DisplayInformation.GetForCurrentView().RawDpiX,
                Height = DisplayInformation.GetForCurrentView().RawDpiY
            };
        }

        /// <summary>
        /// Gets a value representing the number of raw (physical) pixels for each view (layout) pixel.
        /// 
        /// More info:
        /// https://docs.microsoft.com/en-us/uwp/api/windows.graphics.display.displayinformation.rawpixelsperviewpixel#Windows_Graphics_Display_DisplayInformation_RawPixelsPerViewPixel
        /// </summary>
        /// <returns></returns>
        public static double GetScaleFactor()
        {
            return DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
        }

        /// <summary>
        /// Describes the scale factor of the immersive environment. The scale factor is determined by the operating system in response to high pixel density screens.
        /// Enum of values from 100 to 500. 0 for invalid scale.
        /// 
        /// More info:
        /// https://docs.microsoft.com/en-us/uwp/api/windows.graphics.display.resolutionscale
        /// </summary>
        /// <returns></returns>
        public static ResolutionScale GetResolutionScale()
        {
            return DisplayInformation.GetForCurrentView().ResolutionScale;
        }

        public static DisplayOrientations GetDisplayNativeOrientation()
        {
            return DisplayInformation.GetForCurrentView().NativeOrientation;
        }

        public static DisplayOrientations GetDisplayCurrentOrientation()
        {
            return DisplayInformation.GetForCurrentView().CurrentOrientation;
        }
    }
}
