using Flattinger.Core.Enums;
using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Flattinger.UI.Dialogs.Converter
{
    public class DialogTypeToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DialogType type = (DialogType)value;
            switch (type)
            {
                case DialogType.INFO:
                    return "/Flattinger.UI.Dialogs;component/Resources/info.png";
                case DialogType.ERROR:
                    return "/Flattinger.UI.Dialogs;component/Resources/error.png";
                case DialogType.WARNING:
                    return "/Flattinger.UI.Dialogs;component/Resources/warn.png";
                case DialogType.FATAL:
                    return "/Flattinger.UI.Dialogs;component/Resources/fatal.png";
                case DialogType.SUCCESS:
                    return "/Flattinger.UI.Dialogs;component/Resources/success.png";
                default:
                    return PackIconOcticonsKind.Info;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
