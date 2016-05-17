using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace AnnuairePro.Converter
{
    class DateNaissanceToAgeConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // Je récupère l'interval de temps entre la date de maintenant et la date de naissance
            TimeSpan Difference = DateTime.Now.Subtract((DateTime)value);
            // je divise le nombre de jour par 365 pour avoir le nombre d'année
            int Age = Difference.Days / 365;
            return (Age).ToString()+" ans";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
