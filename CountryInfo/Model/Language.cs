using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CountryInfo.Model
{
    public class Language : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string iso639_1 ;
        private string iso639_2 ;
        private string _name ;
        private string _nativeName ;
        private string _header ;
       private string _languageList;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
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

        public string Header
        {
            get { return _header; }
            set
            {
                _header = value;
                this.OnPropertyChanged();
            }
        }

        public string LanguageList
        {
            get { return _languageList; }
            set
            {
                _languageList = value;
                this.OnPropertyChanged();
            }
        }


        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
