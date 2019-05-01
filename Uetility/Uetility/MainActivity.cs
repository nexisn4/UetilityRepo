﻿using System;
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
            btn1.Click += button1Click;
        }

        private void button1Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(ApplicationContext, "hello", ToastLength.Long).Show();
        }
        //[Android(ScreenOrientation = ScreenOrientation.Portrait)]
    }
}

