using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DiplomnaCarProject
{
    class NotificationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            DateTime todayDate = DateTime.Today;
            DateTime values = (DateTime)value;
            System.TimeSpan diff1 = values.Subtract(DateTime.Today);
            

            if (diff1.Days <3)
                return 1;
            else if (diff1.Days < 7 )
                return -1;
            else if (diff1.Days < 15 )
                return 0;
            else
                return 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
