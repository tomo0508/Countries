using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace CountryInfo.Model
{
    class Country : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string _name;
        private List<string> _topLevelDomain;
        private string _alpha2Code;
        private string _alpha3Code;
        private List<string> _callingCodes;
        private string _capital;
        private List<object> _altSpellings;
        private string _region;
        private string _subRegion;
        private int _population;
        public List<object> _latlng;
        private string _demonym;
        private double? _area;
        private double? gini;
        private List<string> _timezones;
        private List<object> _borders;
        private string _nativeName;
        private string _numericCode;
        private List<Currency> _currencies;
        private List<Language> _languages;
        private Translations translations;

        private List<object> regionalBlocs;
        private string cioc;
        private ImageSource _imageUrl;
        private ImageSource _imageUrl1;
        private string _latlngAsString;
        private string _neighbourd;

        private string _callCode;
        private ObservableCollection<Country> myVar;
        private ObservableCollection<Country> myVar1;


        public ObservableCollection<Country> MyVar
        {
            get { return myVar; }
            set
            {
                myVar = value;
                this.OnPropertyChanged();
            }
        }
        public ObservableCollection<Country> MyVar1
        {
            get { return myVar1; }
            set
            {
                myVar1 = value;
                this.OnPropertyChanged();
            }
        }



        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                this.OnPropertyChanged();
            }
        }
        public string Alpha2Code
        {
            get { return _alpha2Code; }
            set
            {
                _alpha2Code = value;
                this.OnPropertyChanged();
            }
        }


        public string NativeName
        {
            get { return _nativeName; }
            set
            {
                _nativeName = value;
                this.OnPropertyChanged();
            }
        }


        public string Alpha3Code
        {
            get { return _alpha3Code; }
            set
            {
                _alpha3Code = value;
                this.OnPropertyChanged();
            }
        }

        public List<string> CallingCodes
        {
            get { return _callingCodes; }
            set
            {
                _callingCodes = value;
                this.OnPropertyChanged();
            }
        }

        public string Demonym
        {
            get { return _demonym; }
            set
            {
                _demonym = value;
                this.OnPropertyChanged();
            }
        }


        public List<object> LatLng
        {
            get { return _latlng; }
            set { _latlng = value; }
        }

        public string LatLngAsString
        {
            get { return _latlngAsString; }
            set
            {
                _latlngAsString = value;
                this.OnPropertyChanged();
            }
        }


        public List<string> TopLevelDomain
        {
            get { return _topLevelDomain; }
            set
            {
                _topLevelDomain = value;
                this.OnPropertyChanged();
            }
        }

        public int Population
        {
            get { return _population; }
            set
            {
                _population = value;
                this.OnPropertyChanged();
            }
        }

        public string Capital
        {
            get { return _capital; }
            set
            {
                _capital = value;
                this.OnPropertyChanged();
            }
        }

        public double? Area
        {
            get { return _area; }
            set
            {
                _area = value;
                this.OnPropertyChanged();
            }

        }

        public string Neighbourd
        {
            get { return _neighbourd; }
            set
            {
                _neighbourd = value;
                OnPropertyChanged();

            }
        }

        /*   public string FormatNumbers(double? value)
           {

               if (value.HasValue)
               {
                   return string.Format("{0:n0}", value);
               }
               else
               {
                   return "<unknown>";
               }


           }*/
        public string Region
        {
            get { return _region; }
            set
            {
                _region = value;
                this.OnPropertyChanged();
            }
        }

        public string SubRegion
        {
            get { return _subRegion; }
            set
            {
                _subRegion = value;
                this.OnPropertyChanged();
            }
        }

        public List<object> Borders
        {
            get { return _borders; }
            set
            {
                _borders = value;
                this.OnPropertyChanged();
            }
        }

        private string _bordersHeader;

        public string BordersHeader
        {
            get { return _bordersHeader; }
            set
            {
                _bordersHeader = value;
                this.OnPropertyChanged();
            }
        }


        public List<Currency> Currencies
        {
            get { return _currencies; }
            set
            {
                _currencies = value;
                this.OnPropertyChanged();
            }
        }

        public List<Language> Languages
        {
            get { return _languages; }
            set
            {
                _languages = value;
                this.OnPropertyChanged();
            }
        }


        public ImageSource ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                this.OnPropertyChanged();
            }
        }

        public ImageSource ImageUrl1
        {
            get { return _imageUrl1; }
            set
            {
                _imageUrl1 = value;
                this.OnPropertyChanged();
            }
        }
        private List<string> _myNames;

        public List<string> MyNames
        {
            get { return _myNames; }
            set
            {
                _myNames = value;
                OnPropertyChanged();
            }
        }


        private string _levelDomain;
        public string LevelDomain
        {
            get { return _levelDomain; }
            set
            {
                _levelDomain = value;
                this.OnPropertyChanged();
            }
        }


        private double _value;

        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                this.OnPropertyChanged();
            }
        }

        private string _category;

        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                this.OnPropertyChanged();
            }
        }


        private List<Country> myList;
        public List<Country> MyList
        {
            get { return myList; }
            set
            {
                myList = value;
                this.OnPropertyChanged();
            }
        }

      

        public string CallCode
        {
            get { return _callCode; }
            set
            {
                _callCode = value;
                this.OnPropertyChanged();
            }
        }




        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }



    }


}