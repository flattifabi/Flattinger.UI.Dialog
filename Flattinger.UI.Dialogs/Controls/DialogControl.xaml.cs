using Flattinger.Core.Enums;
using Flattinger.Core.Interface.ToastMessage.Base;
using MahApps.Metro.IconPacks;
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

namespace Flattinger.UI.Dialogs.Controls
{
    /// <summary>
    /// Interaktionslogik für DialogControl.xaml
    /// </summary>
    public partial class DialogControl : UserControl
    {
        public event EventHandler CloseButtonClicked;

        public static readonly DependencyProperty ContextProperty =
        DependencyProperty.Register("Context", typeof(Control), typeof(DialogContainer), new PropertyMetadata(null));
        
        public Control Context
        {
            get { return (Control)GetValue(ContextProperty); }
            set { SetValue(ContextProperty, value); }
        }
        public void OnCloseDialog()
        {
            CloseButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        public DialogControl()
        {
            InitializeComponent();
            DataContext = this;

            //closeButton.Click += CloseButton_Click;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            OnCloseDialog();
        }
    }
}
