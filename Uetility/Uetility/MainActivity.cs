using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;


namespace Uetility
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private bool number;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Button btn1 = FindViewById<Button>(Resource.Id.button1);
            btn1.Click += Button1Click;

            Button btn2 = FindViewById<Button>(Resource.Id.button2);
            btn2.Click += Button2Click;
        }

        private void Button1Click(object sender, System.EventArgs e)
        {
            var isPortrait = RequestedOrientation == Android.Content.PM.ScreenOrientation.Portrait;
            var isUnspecified = RequestedOrientation == Android.Content.PM.ScreenOrientation.Unspecified;
            if (isPortrait || isUnspecified)
            {
                RequestedOrientation = Android.Content.PM.ScreenOrientation.Landscape;
            }
            else
            {
                RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
            }
        }

        private void Button2Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent();
            intent.PutExtra("Button1Click", true);
            PendingIntent pendingIntent = PendingIntent.GetActivity(this, 0, intent, 0);

            NotificationCompat.Builder builder = new NotificationCompat.Builder(this, "location")
                   .SetContentTitle("my title")
                   .SetContentText("my text")
                   .SetSmallIcon(Resource.Drawable.abc_scrubber_primary_mtrl_alpha)
                   .SetAutoCancel(true)
                   .SetOngoing(true)
                   .AddAction(Resource.Drawable.abc_ab_share_pack_mtrl_alpha, "BUTTON1", pendingIntent)
                   .AddAction(Resource.Drawable.abc_scrubber_control_to_pressed_mtrl_000, "BUTTON2", pendingIntent);

            NotificationManager notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
            notificationManager.Notify(100, builder.Build());
        }

        private void Myprint(string s)
        {
            Toast.MakeText(ApplicationContext, s, ToastLength.Short).Show();
        }
        //[Android(ScreenOrientation = ScreenOrientation.Portrait)]
    }
}

