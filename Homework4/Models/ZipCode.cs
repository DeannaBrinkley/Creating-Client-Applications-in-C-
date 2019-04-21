using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
namespace Homework4.Models
{
    class ZipCd : IDataErrorInfo, INotifyPropertyChanged
    {
        private string zipCode = string.Empty;
        private string zipCodeError = "invalid";

        // Add ToString method
        public override string ToString()
        {
            return zipCode;
        }

        public string ZipCodeError
        {
            get
            {
                return zipCodeError;
            }
            set
            {
                if (zipCodeError != value)
                {
                    zipCodeError = value;
                    OnPropertyChanged("ZipCodeError");
                }
            }
        }

        public string ZipCode
        {
            get
            {
                return zipCode;
            }
            set
            {
                if (zipCode != value)
                {
                    zipCode = value;
                    OnPropertyChanged("ZipCode");
                }
            }
        }

        // IDataErrorInfo interface
        public string Error
        {
            get
            {
                return ZipCodeError;
            }
        }

        // IDataErrorInfo interface
        // Called when ValidatesOnDataErrors=True
        public string this[string columnZipCode]
        {
            get
            {
                Regex ShortUSZip = new Regex(@"(^[0-9]{5}$)");
                Regex LongUSZip = new Regex(@"(^[0-9]{5}-[0-9]{4}$)");
                Regex CanadianZip = new Regex(@"(^[A-Z][0-9][A-Z][0-9][A-Z][0-9]$)");
                if ((ShortUSZip.IsMatch(ZipCode)) || (LongUSZip.IsMatch(ZipCode)) || (CanadianZip.IsMatch(ZipCode)))
                {
                    ZipCodeError = "";
                }
                else
                {
                    ZipCodeError = "Please enter a US or Canadian zip code, NNNNN or NNNNN-NNNN or ANANAN";
                }
                return ZipCodeError;
            }
        }

        // INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyzipCode)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyzipCode));
            }
        }
    }
}