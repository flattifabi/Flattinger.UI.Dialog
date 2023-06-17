using Flattinger.Core.Enums;
using Flattinger.Core.Interface.DialogMessage.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flattinger.UI.Dialogs.Controls.Modules
{
    /// <summary>
    /// Interaktionslogik für MessageDialog.xaml
    /// </summary>
    public partial class MessageDialog : UserControl
    {
        public MessageDialog(DialogType dialogType, string title, string message, IList<IDialogButton> buttonCollection)
        {
            InitializeComponent();
            DataContext = new ViewModel.MessageDialogViewModel(dialogType, title, message, buttonCollection, _buttonPanel); 
        }
    }
}
