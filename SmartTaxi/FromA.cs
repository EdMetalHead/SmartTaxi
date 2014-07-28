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


namespace SmartTaxi.Android
{
	[Activity (Label = "FromA", Theme = "@android:style/Theme.Black.NoTitleBar")]			
	public class FromA : Activity, ILocationListener
	{
		string gpsaddress = null;
		GoogleMap Map;
		Marker LastMarker;
		Location _currentLocation;
		LocationManager _locationManager;
		String _locationProvider;
		bool movecameraswitch = true;

		public void OnLocationChanged(Location location) 
		{
			_currentLocation = location;
			if (_currentLocation == null)
			{
				//_locationText.Text = "Unable to determine your location.";
			}
			else
			{
				LatLng latlon = new LatLng(_currentLocation.Latitude, _currentLocation.Longitude);
				CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
				builder.Target(latlon);
				builder.Zoom(18);
				builder.Bearing(155);
				builder.Tilt(0);
				CameraPosition cameraPosition = builder.Build();
				CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
				//Map.MyLocationEnabled = true;
				Map.UiSettings.MyLocationButtonEnabled = true;
				if (movecameraswitch) 
				{
					Map.MoveCamera (cameraUpdate);

					var marker = new MarkerOptions();
					Map.Clear();
					marker.SetPosition(new LatLng(_currentLocation.Latitude, _currentLocation.Longitude));// 43.2227445, 76.9192032));
					//marker.SetTitle(gpsaddress);
					marker.Draggable(true);
					marker.InvokeIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.MarkerA));
					//LastMarker = 
					Map.AddMarker(marker);
					//LastMarker.ShowInfoWindow();

					movecameraswitch = false;
				}

				//_locationText.Text = String.Format("{0},{1}", _currentLocation.Latitude, _currentLocation.Longitude);
			}
		}

		public void OnProviderDisabled(string provider) {}

		public void OnProviderEnabled(string provider) {}

		public void OnStatusChanged(string provider, Availability status, Bundle extras) {}

		protected override void OnResume()
		{
			base.OnResume();
			_locationManager.RequestLocationUpdates(_locationProvider, 0, 0, this);
		}

		protected override void OnPause()
		{
			base.OnPause();
			_locationManager.RemoveUpdates(this);
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			InitializeLocationManager();

			SetContentView(Resource.Layout.FromA);

			Typeface tf = Typeface.CreateFromAsset(Application.Context.Assets, "fonts/RobotoCondensed-Light.ttf");
			TextView FromATV = FindViewById<TextView>(Resource.Id.FromATV);
			FromATV.SetTypeface(tf, TypefaceStyle.Normal);

			LinearLayout FromALinearLayout = FindViewById<LinearLayout>(Resource.Id.FromALinearLayout);
			FromALinearLayout.Click += (sender4, e4) =>
			{

				StartActivity(typeof(Activity1));
				SetContentView(Resource.Layout.MainMenu);
			};

			var _myMapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map);
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
			};
		}


		async void getAddress(double lat, double lon)
		{
			/*Location _currentLocation; //= new Location( // null;
			LocationManager _locationManager;
			String _locationProvider;

			_locationManager = (LocationManager)GetSystemService(LocationService);
			Criteria criteriaForLocationService = new Criteria
			{
				Accuracy = Accuracy.Fine
			};
			IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

			if (acceptableLocationProviders.Any())
			{
				_locationProvider = acceptableLocationProviders.First();
			}
			else
			{
				_locationProvider = String.Empty;
			}

			_currentLocation = new Location(_locationProvider);

			if (_currentLocation == null)
			{
				//_addressText.Text
				gpsaddress = "Can't determine the current address.";
				return;
			}*/
			//LastMarker.HideInfoWindow ();

			Geocoder geocoder = new Geocoder(this);
			IList<Address> addressList = await geocoder.GetFromLocationAsync(lat, lon, 10);

			Address address1 = addressList.FirstOrDefault();
			if (address1 != null)
			{
				StringBuilder deviceAddress1 = new StringBuilder();
				for (int i = 0; i < address1.MaxAddressLineIndex - 1; i++)
				{
					deviceAddress1.Append(address1.GetAddressLine(i))
						.AppendLine(" ");
				}

				gpsaddress = deviceAddress1.ToString();

				LastMarker.Title = gpsaddress;

				LastMarker.ShowInfoWindow ();


			}
			else
			{
				gpsaddress = "Unable to determine the address.";
			}
		}

		async void getInitialLocation()
		{
			_locationManager = (LocationManager)GetSystemService(LocationService);
			Criteria criteriaForLocationService = new Criteria
			{
				Accuracy = Accuracy.Fine
			};
			IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

			if (acceptableLocationProviders.Any())
			{
				_locationProvider = acceptableLocationProviders.First();
			}
			else
			{
				_locationProvider = String.Empty;
			}

			if (_currentLocation == null)
			{
				//_addressText.Text = "Can't determine the current address.";
				return;
			}

			Geocoder geocoder = new Geocoder(this);
			IList<Address> addressList = await geocoder.GetFromLocationAsync(_currentLocation.Latitude, _currentLocation.Longitude, 10);

			Address address = addressList.FirstOrDefault();
			if (address != null)
			{
				StringBuilder deviceAddress = new StringBuilder();
				for (int i = 0; i < address.MaxAddressLineIndex; i++)
				{
					deviceAddress.Append(address.GetAddressLine(i))
						.AppendLine(",");
				}
				//_addressText.Text = deviceAddress.ToString();


				LatLng latlon = new LatLng(_currentLocation.Latitude, _currentLocation.Longitude);
				CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
				builder.Target(latlon);
				builder.Zoom(18);
				builder.Bearing(155);
				builder.Tilt(65);
				CameraPosition cameraPosition = builder.Build();
				CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

				Map.MoveCamera (cameraUpdate);
			}
			else
			{
				//_addressText.Text = "Unable to determine the address.";
			}
   		}

		void InitializeLocationManager()
		{
			_locationManager = (LocationManager)GetSystemService(LocationService);
			Criteria criteriaForLocationService = new Criteria
			{
				Accuracy = Accuracy.Fine
			};
			IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

			if (acceptableLocationProviders.Any())
			{
				_locationProvider = acceptableLocationProviders.First();
			}
			else
			{
				_locationProvider = String.Empty;
			}
			//Log.Debug(LogTag, "Using " + _locationProvider + ".");
		}
	}
}

