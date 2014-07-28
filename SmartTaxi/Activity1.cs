using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Views.Animations;
using SmartTaxi.Android;
using Android.Gms.Maps;
using Android.Gms;
using Android.Gms.Common;
using Android.Gms.Maps.Model;
//using Android.Gms.Location;
using Android.Locations;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Android.Util;
using Android.Webkit;

namespace SmartTaxi
{
    [Activity(Label = "SmartTaxi.Android", MainLauncher = true, Icon = "@drawable/icon",
		Theme = "@android:style/Theme.Black.NoTitleBar")]
	public class Activity1 : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Display display = WindowManager.DefaultDisplay;
            int width = display.Width;
            int height = display.Height;

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.AboutDriver);
            Typeface tf = Typeface.CreateFromAsset(Application.Context.Assets, "fonts/RobotoCondensed-Light.ttf");
            TextView AboutDriver = FindViewById<TextView>(Resource.Id.AboutDriver);
            AboutDriver.SetTypeface(tf, TypefaceStyle.Normal);

            TextView NameFname = FindViewById<TextView>(Resource.Id.NameFname);
            NameFname.SetTypeface(tf, TypefaceStyle.Normal);

            TextView RatingCount = FindViewById<TextView>(Resource.Id.RatingCount);
            RatingCount.SetTypeface(tf, TypefaceStyle.Normal);

            TextView textView1 = FindViewById<TextView>(Resource.Id.textView1);
            textView1.SetTypeface(tf, TypefaceStyle.Normal);

            TextView textView3 = FindViewById<TextView>(Resource.Id.textView3);
            textView3.SetTypeface(tf, TypefaceStyle.Normal);

            TextView BrandTextView = FindViewById<TextView>(Resource.Id.BrandTextView);
            BrandTextView.SetTypeface(tf, TypefaceStyle.Normal);

            TextView ModelTextView = FindViewById<TextView>(Resource.Id.ModelTextView);
            ModelTextView.SetTypeface(tf, TypefaceStyle.Normal);

            TextView textView4 = FindViewById<TextView>(Resource.Id.textView4);
            textView4.SetTypeface(tf, TypefaceStyle.Normal);

            TextView textView5 = FindViewById<TextView>(Resource.Id.textView5);
            textView5.SetTypeface(tf, TypefaceStyle.Normal);

            TextView VNumberTextView = FindViewById<TextView>(Resource.Id.VNumberTextView);
            VNumberTextView.SetTypeface(tf, TypefaceStyle.Normal);

            TextView VColorTextView = FindViewById<TextView>(Resource.Id.VColorTextView);
            VColorTextView.SetTypeface(tf, TypefaceStyle.Normal);

            TextView textView7 = FindViewById<TextView>(Resource.Id.textView7);
            textView7.SetTypeface(tf, TypefaceStyle.Normal);

            EditText PhoneEditText = FindViewById<EditText>(Resource.Id.PhoneEditText);
            PhoneEditText.SetTypeface(tf, TypefaceStyle.Normal);

            Button RememberButton = FindViewById<Button>(Resource.Id.RememberButton);
            RememberButton.SetTypeface(tf, TypefaceStyle.Normal);

            Button OkButton = FindViewById<Button>(Resource.Id.OkButton);
            OkButton.SetTypeface(tf, TypefaceStyle.Normal);

            ImageButton BackImageButton = FindViewById<ImageButton>(Resource.Id.BackImageButton);
            BackImageButton.Click += (sender2, e2) =>
            {
                SetContentView(Resource.Layout.MainMenu);

                TextView FromTV = FindViewById<TextView>(Resource.Id.FromTV);
                FromTV.SetTypeface(tf, TypefaceStyle.Normal);

                TextView WhereTV = FindViewById<TextView>(Resource.Id.WhereTV);
                WhereTV.SetTypeface(tf, TypefaceStyle.Normal);

                TextView WhenTV = FindViewById<TextView>(Resource.Id.WhenTV);
                WhenTV.SetTypeface(tf, TypefaceStyle.Normal);

                TextView CallTV = FindViewById<TextView>(Resource.Id.CallTV);
                CallTV.SetTypeface(tf, TypefaceStyle.Normal);

                TextView DescrTV = FindViewById<TextView>(Resource.Id.DescrTV);
                DescrTV.SetTypeface(tf, TypefaceStyle.Normal);

                TextView ImDriverTV = FindViewById<TextView>(Resource.Id.ImDriverTV);
                ImDriverTV.SetTypeface(tf, TypefaceStyle.Normal);

                Animation ScaleAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.scale_main_menu_animation);
                Animation TranslateUpAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.translate_up_main_menu_animation);
                Animation TranslateDownAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.translate_down_main_menu_animation);
                Animation DropDownAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.drop_down_main_menu_animation);
                Animation WhereMoveUpAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.where_move_up_main_menu_animation);
                Animation WhenMoveUpAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.when_move_up_main_menu_animation);
                Animation DescrMoveUpAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.descr_move_up_main_menu_animation);
                Animation CallMoveUpAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.call_move_up_main_menu_animation);
                Animation DriverMoveUpAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.driver_move_up_main_menu_animation);

                LinearLayout FromLinearLayout = FindViewById<LinearLayout>(Resource.Id.FromLinearLayout);
                //FromLinearLayout.Visibility = ViewStates.Invisible;

                LinearLayout WhereLinearLayout = FindViewById<LinearLayout>(Resource.Id.WhereLinearLayout);
                //WhereLinearLayout.Visibility = ViewStates.Invisible;

                LinearLayout WhenLinearLayout = FindViewById<LinearLayout>(Resource.Id.WhenLinearLayout);
                //WhenLinearLayout.Visibility = ViewStates.Invisible;

                LinearLayout DescriptionLinearLayout = FindViewById<LinearLayout>(Resource.Id.DescriptionLinearLayout);
                //DescriptionLinearLayout.Visibility = ViewStates.Invisible;

                LinearLayout CallLinearLayout = FindViewById<LinearLayout>(Resource.Id.CallLinearLayout);
                //CallLinearLayout.Visibility = ViewStates.Invisible;

                LinearLayout IAmDriverLinearLayout = FindViewById<LinearLayout>(Resource.Id.IAmDriverLinearLayout);
                //IAmDriverLinearLayout.Visibility = ViewStates.Invisible;

                LinearLayout linearLayout1 = FindViewById<LinearLayout>(Resource.Id.linearLayout1);
                LinearLayout linearLayout8 = FindViewById<LinearLayout>(Resource.Id.linearLayout8);
                LinearLayout linearLayout9 = FindViewById<LinearLayout>(Resource.Id.linearLayout9);

                //Drop down animation
                /*linearLayout1.SetBackgroundColor(Color.ParseColor("#ff6600"));

                FromLinearLayout.StartAnimation(DropDownAnimation);
                WhereLinearLayout.StartAnimation(DropDownAnimation);
                WhenLinearLayout.StartAnimation(DropDownAnimation);
                DescriptionLinearLayout.StartAnimation(DropDownAnimation);
                CallLinearLayout.StartAnimation(DropDownAnimation);
                IAmDriverLinearLayout.StartAnimation(DropDownAnimation);
                linearLayout8.StartAnimation(DropDownAnimation);
                linearLayout9.StartAnimation(DropDownAnimation);*/

                FromLinearLayout.Click += (sender3, e3) =>
                {
                    linearLayout1.SetBackgroundColor(Color.ParseColor("#ffd800"));

                    WhereLinearLayout.StartAnimation(TranslateDownAnimation);
                    WhenLinearLayout.StartAnimation(TranslateDownAnimation);
                    DescriptionLinearLayout.StartAnimation(TranslateDownAnimation);
                    CallLinearLayout.StartAnimation(TranslateDownAnimation);
                    IAmDriverLinearLayout.StartAnimation(TranslateDownAnimation);
                    linearLayout8.StartAnimation(TranslateDownAnimation);
                    linearLayout9.StartAnimation(TranslateDownAnimation);

                    TranslateDownAnimation.AnimationEnd += (sen, ev) =>
                    {
                        WhereLinearLayout.Visibility = ViewStates.Invisible;
                        WhenLinearLayout.Visibility = ViewStates.Invisible;
                        DescriptionLinearLayout.Visibility = ViewStates.Invisible;
                        CallLinearLayout.Visibility = ViewStates.Invisible;
                        IAmDriverLinearLayout.Visibility = ViewStates.Invisible;
                        linearLayout8.Visibility = ViewStates.Invisible;
                        linearLayout9.Visibility = ViewStates.Invisible;

						//SetContentView(Resource.Layout.FromA);


						StartActivity(typeof(FromA));

						/*var _myMapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
						Map = _myMapFragment.Map;

						if (Map == null) return;

						Map.UiSettings.MyLocationButtonEnabled = true;
						//getInitialLocation();

						Map.MapClick += (sendermap, emap) => 
						{
							getAddress(emap.Point.Latitude, emap.Point.Longitude);
							var marker = new MarkerOptions();
							Map.Clear();
							marker.SetPosition(new LatLng(emap.Point.Latitude, emap.Point.Longitude));// 43.2227445, 76.9192032));
							//marker.SetTitle(gpsaddress);
							marker.Draggable(true);
							marker.InvokeIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.MarkerA));
							LastMarker = Map.AddMarker(marker);
								LastMarker.ShowInfoWindow();
							};

						//UpdateLocation(GetCurrentLocation());


						Map.MyLocationButtonClick += (object sender, GoogleMap.MyLocationButtonClickEventArgs e) =>  
						{
							var marker = new MarkerOptions();
							Map.Clear();
							marker.SetPosition(new LatLng(_currentLocation.Latitude, _currentLocation.Longitude));// 43.2227445, 76.9192032));
							//marker.SetTitle(gpsaddress);
							marker.Draggable(true);
							marker.InvokeIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.MarkerA));
							//LastMarker = 
								Map.AddMarker(marker);
							//LastMarker.ShowInfoWindow();
						};*/
			
                        /*TextView FromATV = FindViewById<TextView>(Resource.Id.FromATV);
                        FromATV.SetTypeface(tf, TypefaceStyle.Normal);

                        LinearLayout FromALinearLayout = FindViewById<LinearLayout>(Resource.Id.FromALinearLayout);
                        FromALinearLayout.Click += (sender4, e4) =>
						{


							SetContentView(Resource.Layout.MainMenu);
						};*/
                    };

                };

                WhereLinearLayout.Click += (sender3, e3) =>
                {
                    linearLayout1.SetBackgroundColor(Color.ParseColor("#ffcc00"));

                    FromLinearLayout.StartAnimation(TranslateUpAnimation);

                    WhereLinearLayout.StartAnimation(WhereMoveUpAnimation);
                    WhereMoveUpAnimation.AnimationEnd += (sen, ev) =>
                    {
                        LinearLayout.LayoutParams param1 = (LinearLayout.LayoutParams)FromLinearLayout.LayoutParameters;
                        param1.Height = 0;
                        FromLinearLayout.LayoutParameters = param1;
                    };

                    WhenLinearLayout.StartAnimation(TranslateDownAnimation);
                    DescriptionLinearLayout.StartAnimation(TranslateDownAnimation);
                    CallLinearLayout.StartAnimation(TranslateDownAnimation);
                    IAmDriverLinearLayout.StartAnimation(TranslateDownAnimation);
                    linearLayout8.StartAnimation(TranslateDownAnimation);
                    linearLayout9.StartAnimation(TranslateDownAnimation);

                    TranslateDownAnimation.AnimationEnd += (sen, ev) =>
                    {

                        FromLinearLayout.Visibility = ViewStates.Invisible;
                        WhenLinearLayout.Visibility = ViewStates.Invisible;
                        DescriptionLinearLayout.Visibility = ViewStates.Invisible;
                        CallLinearLayout.Visibility = ViewStates.Invisible;
                        IAmDriverLinearLayout.Visibility = ViewStates.Invisible;
                        linearLayout8.Visibility = ViewStates.Invisible;
                        linearLayout9.Visibility = ViewStates.Invisible;
                    };
                };

                WhenLinearLayout.Click += (sender3, e3) =>
                {
                    linearLayout1.SetBackgroundColor(Color.ParseColor("#ffb901"));

                    FromLinearLayout.StartAnimation(TranslateUpAnimation);
                    WhereLinearLayout.StartAnimation(TranslateUpAnimation);

                    WhenLinearLayout.StartAnimation(WhenMoveUpAnimation);
                    WhenMoveUpAnimation.AnimationEnd += (sen, ev) =>
                    {
                        LinearLayout.LayoutParams param1 = (LinearLayout.LayoutParams)FromLinearLayout.LayoutParameters;
                        param1.Height = 0;
                        FromLinearLayout.LayoutParameters = param1;

                        LinearLayout.LayoutParams param2 = (LinearLayout.LayoutParams)WhereLinearLayout.LayoutParameters;
                        param2.Height = 0;
                        WhereLinearLayout.LayoutParameters = param2;
                    };

                    DescriptionLinearLayout.StartAnimation(TranslateDownAnimation);
                    CallLinearLayout.StartAnimation(TranslateDownAnimation);
                    IAmDriverLinearLayout.StartAnimation(TranslateDownAnimation);
                    linearLayout8.StartAnimation(TranslateDownAnimation);
                    linearLayout9.StartAnimation(TranslateDownAnimation);

                    TranslateDownAnimation.AnimationEnd += (sen, ev) =>
                    {

                        FromLinearLayout.Visibility = ViewStates.Invisible;
                        WhereLinearLayout.Visibility = ViewStates.Invisible;
                        DescriptionLinearLayout.Visibility = ViewStates.Invisible;
                        CallLinearLayout.Visibility = ViewStates.Invisible;
                        IAmDriverLinearLayout.Visibility = ViewStates.Invisible;
                        linearLayout8.Visibility = ViewStates.Invisible;
                        linearLayout9.Visibility = ViewStates.Invisible;
                    };
                };

                DescriptionLinearLayout.Click += (sender3, e3) =>
                {
                    linearLayout1.SetBackgroundColor(Color.ParseColor("#ffa800"));

                    FromLinearLayout.StartAnimation(TranslateUpAnimation);
                    WhereLinearLayout.StartAnimation(TranslateUpAnimation);
                    WhenLinearLayout.StartAnimation(TranslateUpAnimation);

                    DescriptionLinearLayout.StartAnimation(DescrMoveUpAnimation);
                    DescrMoveUpAnimation.AnimationEnd += (sen, ev) =>
                    {
                        LinearLayout.LayoutParams param1 = (LinearLayout.LayoutParams)FromLinearLayout.LayoutParameters;
                        param1.Height = 0;
                        FromLinearLayout.LayoutParameters = param1;

                        LinearLayout.LayoutParams param2 = (LinearLayout.LayoutParams)WhereLinearLayout.LayoutParameters;
                        param2.Height = 0;
                        WhereLinearLayout.LayoutParameters = param2;

                        LinearLayout.LayoutParams param3 = (LinearLayout.LayoutParams)WhenLinearLayout.LayoutParameters;
                        param3.Height = 0;
                        WhenLinearLayout.LayoutParameters = param3;
                    };

                    CallLinearLayout.StartAnimation(TranslateDownAnimation);
                    IAmDriverLinearLayout.StartAnimation(TranslateDownAnimation);
                    linearLayout8.StartAnimation(TranslateDownAnimation);
                    linearLayout9.StartAnimation(TranslateDownAnimation);

                    TranslateDownAnimation.AnimationEnd += (sen, ev) =>
                    {

                        FromLinearLayout.Visibility = ViewStates.Invisible;
                        WhereLinearLayout.Visibility = ViewStates.Invisible;
                        WhenLinearLayout.Visibility = ViewStates.Invisible;
                        CallLinearLayout.Visibility = ViewStates.Invisible;
                        IAmDriverLinearLayout.Visibility = ViewStates.Invisible;
                        linearLayout8.Visibility = ViewStates.Invisible;
                        linearLayout9.Visibility = ViewStates.Invisible;
                    };
                };

                CallLinearLayout.Click += (sender3, e3) =>
                {
                    linearLayout1.SetBackgroundColor(Color.ParseColor("#ff9000"));

                    FromLinearLayout.StartAnimation(TranslateUpAnimation);
                    WhereLinearLayout.StartAnimation(TranslateUpAnimation);
                    WhenLinearLayout.StartAnimation(TranslateUpAnimation);
                    DescriptionLinearLayout.StartAnimation(TranslateUpAnimation);

                    CallLinearLayout.StartAnimation(CallMoveUpAnimation);
                    CallMoveUpAnimation.AnimationEnd += (sen, ev) =>
                    {
                        LinearLayout.LayoutParams param1 = (LinearLayout.LayoutParams)FromLinearLayout.LayoutParameters;
                        param1.Height = 0;
                        FromLinearLayout.LayoutParameters = param1;

                        LinearLayout.LayoutParams param2 = (LinearLayout.LayoutParams)WhereLinearLayout.LayoutParameters;
                        param2.Height = 0;
                        WhereLinearLayout.LayoutParameters = param2;

                        LinearLayout.LayoutParams param3 = (LinearLayout.LayoutParams)WhenLinearLayout.LayoutParameters;
                        param3.Height = 0;
                        WhenLinearLayout.LayoutParameters = param3;

                        LinearLayout.LayoutParams param4 = (LinearLayout.LayoutParams)DescriptionLinearLayout.LayoutParameters;
                        param4.Height = 0;
                        DescriptionLinearLayout.LayoutParameters = param4;
                    };

                    IAmDriverLinearLayout.StartAnimation(TranslateDownAnimation);
                    linearLayout8.StartAnimation(TranslateDownAnimation);
                    linearLayout9.StartAnimation(TranslateDownAnimation);

                    TranslateDownAnimation.AnimationEnd += (sen, ev) =>
                    {

                        FromLinearLayout.Visibility = ViewStates.Invisible;
                        WhereLinearLayout.Visibility = ViewStates.Invisible;
                        WhenLinearLayout.Visibility = ViewStates.Invisible;
                        DescriptionLinearLayout.Visibility = ViewStates.Invisible;
                        IAmDriverLinearLayout.Visibility = ViewStates.Invisible;
                        linearLayout8.Visibility = ViewStates.Invisible;
                        linearLayout9.Visibility = ViewStates.Invisible;
                    };
                };

                IAmDriverLinearLayout.Click += (sender3, e3) =>
                {
                    linearLayout1.SetBackgroundColor(Color.ParseColor("#ff8500"));

                    FromLinearLayout.StartAnimation(TranslateUpAnimation);
                    WhereLinearLayout.StartAnimation(TranslateUpAnimation);
                    WhenLinearLayout.StartAnimation(TranslateUpAnimation);
                    DescriptionLinearLayout.StartAnimation(TranslateUpAnimation);
                    CallLinearLayout.StartAnimation(TranslateUpAnimation);

                    IAmDriverLinearLayout.StartAnimation(DriverMoveUpAnimation);
                    DriverMoveUpAnimation.AnimationEnd += (sen, ev) =>
                    {
                        LinearLayout.LayoutParams param1 = (LinearLayout.LayoutParams)FromLinearLayout.LayoutParameters;
                        param1.Height = 0;
                        FromLinearLayout.LayoutParameters = param1;

                        LinearLayout.LayoutParams param2 = (LinearLayout.LayoutParams)WhereLinearLayout.LayoutParameters;
                        param2.Height = 0;
                        WhereLinearLayout.LayoutParameters = param2;

                        LinearLayout.LayoutParams param3 = (LinearLayout.LayoutParams)WhenLinearLayout.LayoutParameters;
                        param3.Height = 0;
                        WhenLinearLayout.LayoutParameters = param3;

                        LinearLayout.LayoutParams param4 = (LinearLayout.LayoutParams)DescriptionLinearLayout.LayoutParameters;
                        param4.Height = 0;
                        DescriptionLinearLayout.LayoutParameters = param4;

                        LinearLayout.LayoutParams param5 = (LinearLayout.LayoutParams)CallLinearLayout.LayoutParameters;
                        param5.Height = 0;
                        CallLinearLayout.LayoutParameters = param5;
                    };

                    linearLayout8.StartAnimation(TranslateDownAnimation);
                    linearLayout9.StartAnimation(TranslateDownAnimation);

                    TranslateDownAnimation.AnimationEnd += (sen, ev) =>
                    {

                        FromLinearLayout.Visibility = ViewStates.Invisible;
                        WhereLinearLayout.Visibility = ViewStates.Invisible;
                        WhenLinearLayout.Visibility = ViewStates.Invisible;
                        DescriptionLinearLayout.Visibility = ViewStates.Invisible;
                        CallLinearLayout.Visibility = ViewStates.Invisible;
                        linearLayout8.Visibility = ViewStates.Invisible;
                        linearLayout9.Visibility = ViewStates.Invisible;
                    };
                };
            };
        }

    }
}

