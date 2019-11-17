using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrVELLog.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Position = Xamarin.Forms.Maps.Position;

namespace TrVELLog
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public bool hasLocationPersmission = false;
        public MapPage()
        {
            InitializeComponent();

            GetPermissions();
        }

        public async void GetPermissions()
        {
            try
            {
                var status = await CrossPermissions.
                                Current.CheckPermissionStatusAsync
                                (Permission.LocationWhenInUse);

                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        await DisplayAlert("Need your location", "We need to access your location", "Ok");
                    }

                    var results = await CrossPermissions.Current.
                    RequestPermissionsAsync(Permission.LocationWhenInUse);

                    if (results.ContainsKey(Permission.LocationWhenInUse))
                        status = results[Permission.LocationWhenInUse];
                }

                if (status == PermissionStatus.Granted)
                {
                    hasLocationPersmission = true;
                    locationsMap.IsShowingUser = true;

                    GetLocation();
                }
                else
                {
                    await DisplayAlert("Location denied", "We can't launch the app untill you give us access", "Ok");
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("An error occured", ex.Message, "Ok");
            }      
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (hasLocationPersmission)
            {
                var locator = CrossGeolocator.Current;

                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(TimeSpan.Zero, 100);
            }
            GetLocation();
            
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

            var locator = CrossGeolocator.Current;

            locator.PositionChanged -= Locator_PositionChanged;
            await locator.StopListeningAsync();

        }

        private void Locator_PositionChanged(object sender, PositionEventArgs e)
        {
            MoveMap(e.Position);
        }

        private async void GetLocation()
        {
            if (hasLocationPersmission)
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();

                MoveMap(position);
            }

            
        }
        private void MoveMap(Plugin.Geolocator.Abstractions.Position position)
        {
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);
            locationsMap.MoveToRegion(span);

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {

                //var posts = conn.Table<Post>().ToList();
                var places = new List<Place>();

                DisplayInMap(places);

            }
        }

        private void DisplayInMap(List<Place> places)
        {
            try
            {
                var pin1 = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(50.867219, 20.649602),
                Label = "Pływalnie Orka",
                    Address = "Kujawska 18",
                };

                var pin3 = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(50.988294, 20.679538),
                    Label = "Kryta pływalnia JURAJSKA",
                    Address = "ul. Jurajska 7"
                };

                var pin4 = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(50.8899294, 20.079538),
                    Label = "Hala Widowiskowo-Sportowa",
                    Address = "ul. Żytnia 1"
                };

                var pin5 = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(50.8088294, 20.0579538),
                    Label = "Hala Legionów",
                    Address = "ul. Boczna 15"
                };
                
                var pin2 = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(51.088294, 20.789538),
                    Label = "Hala Sportowa w Dąbrowie",
                    Address = "ul. Warszawska 338"
                };

                var pin6 = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(49.9988294, 23.879538),
                    Label = "Hala Mosir",
                    Address = "ul. Krakowska 72"
                };

                var pin7 = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(50.666294, 22.669538),
                    Label = "Boisko sportowe",
                    Address = "przy szkole"
                };

                locationsMap.Pins.Add(pin1);
                locationsMap.Pins.Add(pin2);
                locationsMap.Pins.Add(pin3);
                locationsMap.Pins.Add(pin4);
                locationsMap.Pins.Add(pin5);
                locationsMap.Pins.Add(pin6);
                locationsMap.Pins.Add(pin7);
                //}
            } catch (NullReferenceException nre)
            {

            } catch (Exception ex)
            {

            }
            
        }
    }
}