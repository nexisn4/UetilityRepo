using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Uetility
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

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
            int randomInt = new Random().Next(0, 2);

            if (Convert.ToBoolean(randomInt))
            {
                RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
            }
            else
            {
                RequestedOrientation = Android.Content.PM.ScreenOrientation.Landscape;
            }

            Myprint("rand: " + randomInt);
        }

        private void Button2Click(object sender, System.EventArgs e)
        {
            Myprint("clicked button2");
        }

        private void Myprint(string s)
        {
            Toast.MakeText(ApplicationContext, s, ToastLength.Short).Show();
        }
        //[Android(ScreenOrientation = ScreenOrientation.Portrait)]
    }
}

