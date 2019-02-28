
using CountryInfo.Converters;
using CountryInfo.Model;
using GeoJSON.Net;
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

using Windows.Devices.Geolocation;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Media.Imaging;
using static CountryInfo.Model.IpDetails;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CountryInfo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        Country country;
        Currency currency;
        Language language;

        List<Country> names;
        static List<string> countryName;
        List<object> borderList;
        List<object> latLng;
        List<string> topLevelDomain;
        List<string> callCode;
        List<Currency> currencyList;
        List<Language> languageList;
        int countryIndex = 0;
        string flagUrl;

        StringBuilder stringBuilder;

        private double lat;
        private double lng;
        List<Country> sorted;

        public MainPage()
        {
            this.InitializeComponent();

            country = new Country();
            currency = new Currency();
            language = new Language();

            names = new List<Country>();
            countryName = new List<string>();
            borderList = new List<object>();
            latLng = new List<object>();
            currencyList = new List<Currency>();
            languageList = new List<Language>();
            topLevelDomain = new List<string>();
            callCode = new List<string>();

            svMain.Visibility = Visibility.Collapsed;




        }




        public async void LoadJson()
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(Constants.JsonPath1 + "country.json"));
            var stream = await file.OpenStreamForReadAsync();
            using (var sr = new StreamReader(stream))
            {
                string json = sr.ReadToEnd();
                names = JsonConvert.DeserializeObject<List<Country>>(json);
                try
                {
                    string currentCountry = await GetLocation();
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (names[i].Alpha2Code.Equals(currentCountry, StringComparison.OrdinalIgnoreCase))
                        {
                            countryIndex = i;
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }

                country.MyNames = new List<string>();
                for (int i = 0; i < names.Count; i++)
                {

                    countryName.Add(names[i].Name);


                }

                asbCountry.ItemsSource = countryName;

                lbBusy.Focus(FocusState.Programmatic);
                Populating(countryIndex);

                asbCountry.Text = names[countryIndex].Name;
                lbBusy.Visibility = Visibility.Collapsed;
                mapCountry.Visibility = Visibility.Visible;
                svMain.Visibility = Visibility.Visible;
            }
        }



        private void AsbCountry_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {

            var selectedItem = args.SelectedItem.ToString();
            sender.Text = selectedItem;



        }

        private void AsbCountry_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {

            for (int i = 0; i < names.Count; i++)
            {
                if (names[i].Name.Equals(asbCountry.Text, StringComparison.OrdinalIgnoreCase))
                {
                    countryIndex = i;
                    break;
                }
            }

            Populating(countryIndex);

        }

        public void Populating(int index)
        {
            country.Name = names[index].Name;
            country.Capital = names[index].Capital;

            flagUrl = Constants.FlagPath1 + names[index].Alpha3Code.ToLower() + ".png";
            country.ImageUrl = new BitmapImage(new Uri(flagUrl));

            country.Area = names[index].Area;
            // country.Povrsina = (double)( country.Area / 17124442) *100 ;
            // country.Ostatak = 100 - country.Povrsina;
            country.Population = names[index].Population;


            country.Region = names[index].Region;
            country.SubRegion = names[index].SubRegion;

            country.Alpha2Code = names[index].Alpha2Code;
            country.Alpha3Code = names[index].Alpha3Code;

            country.Demonym = names[index].Demonym;

            callCode = names[index].CallingCodes;

            stringBuilder = new StringBuilder();
            for (int i = 0; i < callCode.Count; i++)
            {
                stringBuilder.Append("+" + callCode[i]);

                if (i < callCode.Count - 1)
                {
                    stringBuilder.Append(",\n");
                }
                else
                {
                    stringBuilder.Append("");
                }
            }
            country.CallCode = stringBuilder.ToString();




            borderList = names[index].Borders;

            country.BordersHeader = Headers.BorderHeader(borderList.Count);
            country.MyVar = new ObservableCollection<Country>();
            for (int i = 0; i < borderList.Count; i++)
            {
                country.Neighbourd = names.Find(x => x.Alpha3Code == borderList[i].ToString()).Name;

                flagUrl = Constants.FlagPath1 + borderList[i].ToString() + ".png";
                country.ImageUrl1 = new BitmapImage(new Uri(flagUrl));
                country.MyVar.Add(new Country { Neighbourd = country.Neighbourd, ImageUrl1 = country.ImageUrl1 });
            }


            country.NativeName = "( " + names[index].NativeName + " )";

            lat = (double)names[index]._latlng[0];
            lng = (double)names[index]._latlng[1];

            country.LatLngAsString = string.Format("{0},\n {1}", lat, lng);


            stringBuilder = new StringBuilder();
            currencyList = names[index].Currencies;
            currency.Header = Headers.CurrencyHeader(currencyList.Count);
            for (int i = 0; i < currencyList.Count; i++)
            {
                currency.Name = currencyList[i].Name;
                currency.Code = currencyList[i].Code;
                currency.Symbol = currencyList[i].Symbol;

                if (currency.Name != null)
                    stringBuilder.Append(currency.Name + " (" + currency.Code + ") " + currency.Symbol);

                if (i < currencyList.Count - 1)
                {
                    stringBuilder.Append("\n");
                }
                else
                {
                    stringBuilder.Append("");
                }
            }
            currency.Code = stringBuilder.ToString();



            stringBuilder = new StringBuilder();
            languageList = names[index].Languages;
            language.Header = Headers.LanguageHeader(languageList.Count);

            for (int i = 0; i < languageList.Count; i++)
            {
                language.Name = languageList[i].Name;
                language.NativeName = languageList[i].NativeName;

                stringBuilder.Append(language.Name + " ( " + language.NativeName + " )");

                if (i < languageList.Count - 1)
                {
                    stringBuilder.Append("\n");
                }
                else
                {
                    stringBuilder.Append("");
                }
            }
            language.LanguageList = stringBuilder.ToString();


            stringBuilder = new StringBuilder();
            topLevelDomain = names[index].TopLevelDomain;
            for (int i = 0; i < topLevelDomain.Count; i++)
            {
                country.LevelDomain = topLevelDomain[i];
                stringBuilder.Append(country.LevelDomain);
            }
            country.LevelDomain = stringBuilder.ToString();

            HighlightClick(country.Alpha3Code, lat, lng);

        }




        private FeatureCollection _countryPolygons = null;

        private async void HighlightClick(string alpha3Code, double latitude, double longitude)
        {
            mapCountry.MapElements.Clear();

            if (_countryPolygons == null)
            {
                _countryPolygons = JsonConvert.DeserializeObject<FeatureCollection>(
                    await FileIO.ReadTextAsync(
                        await StorageFile.GetFileFromApplicationUriAsync(new Uri(Constants.JsonPath1 + "countries.geo.json",
                            UriKind.Absolute))));
            }


            var feature = _countryPolygons.Features.FirstOrDefault(f =>
                f.Id.Equals(alpha3Code, StringComparison.OrdinalIgnoreCase));

            if (feature != null && feature.Geometry.Type == GeoJSONObjectType.Polygon)
            {
                var polygonGeometry = feature.Geometry as Polygon;
                MapPolygon polygon = new MapPolygon();
                polygon.Path = new Geopath(polygonGeometry.Coordinates[0].Coordinates.Select(coord => new BasicGeoposition()
                { Latitude = coord.Latitude, Longitude = coord.Longitude }));
                polygon.FillColor = Color.FromArgb(120, 255, 0, 0);

                mapCountry.MapElements.Add(polygon);

            }
            else if (feature != null && feature.Geometry.Type == GeoJSONObjectType.MultiPolygon)
            {


                var ploy = (feature.Geometry as MultiPolygon);
                foreach (var item in ploy.Coordinates)
                {
                    var polygon1 = new MapPolygon
                    {
                        Path = new Geopath(item.Coordinates[0].Coordinates.Select(coord => new BasicGeoposition() { Latitude = coord.Latitude, Longitude = coord.Longitude })),
                        FillColor = Color.FromArgb(120, 255, 0, 0)
                    };
                    mapCountry.MapElements.Add(polygon1);
                }
            }

            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = latitude, Longitude = longitude };
            Geopoint cityCenter = new Geopoint(cityPosition);
            mapCountry.Center = cityCenter;

        }



        List<string> listSuggestion = null;
        private void AsbCountry_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {

                listSuggestion = countryName.Where(x => x.Contains(sender.Text, StringComparison.OrdinalIgnoreCase)).ToList();
                sender.ItemsSource = listSuggestion;

            }


        }

        private void LvNeighbourds_ItemClick(object sender, ItemClickEventArgs e)
        {
            Country country = e.ClickedItem as Country;
            string countrySelected = country.Neighbourd;
            for (int i = 0; i < names.Count; i++)
            {
                if (names[i].Name.Equals(countrySelected, StringComparison.OrdinalIgnoreCase))
                {
                    countryIndex = i;
                    break;
                }
            }
            asbCountry.Text = countrySelected.ToString();
            Populating(countryIndex);


        }

        private void Image_ImageOpened(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_BringIntoViewRequested(UIElement sender, BringIntoViewRequestedEventArgs args)
        {

        }



        private void Page_Loading(FrameworkElement sender, object args)
        {
            LoadJson();
        }
    }


}
