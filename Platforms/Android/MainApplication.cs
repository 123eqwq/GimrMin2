using Android.App;
using Android.Runtime;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;

namespace GimrMin2
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
#if ANDROID
            // Remove Entry control underline
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
            {
                h.PlatformView.BackgroundTintList =
                    Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
            });
#endif
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
