using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CountryInfo.Model
{
    public class Currency : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string _code ;
        private string _name ;
        private string _symbol ;
        private string _header ;
        private string _curencyList ;

        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
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

        public string Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
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

        public string CurencyList
        {
            get { return _curencyList; }
            set
            {
                _curencyList = value;
                this.OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}