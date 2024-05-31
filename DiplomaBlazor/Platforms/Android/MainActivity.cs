using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Widget;
using static Android.Resource;
using Rect = Android.Graphics.Rect;
using View = Android.Views.View;


namespace DiplomaBlazor;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        GlobalLayoutUtil.AssistActivity(this);
    }


    //фикс когда клава закрывает форму ввода 
    // https://github.com/dotnet/maui/issues/14197
    public class GlobalLayoutUtil
    {
        private bool isImmersed = false;
        private View mChildContent;
        private FrameLayout.LayoutParams frameLayoutParams;
        private int usableHeightPrevious = 0;

        public static void AssistActivity(Activity activity)
        {
            _ = new GlobalLayoutUtil(activity);
        }

        public GlobalLayoutUtil(Activity activity)
        {
            FrameLayout content = (FrameLayout)activity.FindViewById(Id.Content);
            mChildContent = content.GetChildAt(0);
            mChildContent.ViewTreeObserver.GlobalLayout += (s, o) =>
                PossiblyResizeChildOfContent(activity);
            frameLayoutParams =
                (FrameLayout.LayoutParams)mChildContent.LayoutParameters;
        }

        private void PossiblyResizeChildOfContent(Activity activity)
        {
            int usableHeightNow = ComputeUsableHeight();

            if (usableHeightNow != usableHeightPrevious)
            {
                int usableHeightSansKeyboard = mChildContent.RootView.Height;
                int heightDiff = usableHeightSansKeyboard - usableHeightNow;

                if (heightDiff < 0)
                {
                    usableHeightSansKeyboard = mChildContent.RootView.Width;
                    heightDiff = usableHeightSansKeyboard - usableHeightNow;
                }
                if (heightDiff > usableHeightSansKeyboard / 4)
                {
                    frameLayoutParams.Height = usableHeightSansKeyboard - heightDiff;
                }
                else
                {
                    frameLayoutParams.Height = usableHeightNow;
                }               
            }
            mChildContent.RequestLayout();

            usableHeightPrevious = usableHeightNow;
        }
        private int ComputeUsableHeight()
        { 
            Rect rect = new Rect();
            mChildContent.GetWindowVisibleDisplayFrame(rect);
            if (isImmersed)
                return (int)rect.Bottom;
            else
                return (int)(rect.Bottom - rect.Top);
        }
        private static int GetNavigationBarHeight(Context context)
        {
            int result = 0;
            Resources resources = context.Resources;
            int resourceId =
                resources.GetIdentifier("navigation_bar_height", "dimen", "android");
            if (resourceId > 0) 
                result = resources.GetDimensionPixelSize(resourceId);
            return result;
        }
    }
}
