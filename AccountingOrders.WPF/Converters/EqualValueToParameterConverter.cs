using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace AccountingOrders.WPF.Converters
{
    public class EqualValueToParameterConverter: MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            #pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            return value.ToString().Equals(parameter.ToString());
            #pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}