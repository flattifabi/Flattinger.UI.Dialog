using Flattinger.Core.Enums;
using Flattinger.Core.Interface.DialogMessage.Base;
using Flattinger.UI.Dialogs.Controls.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flattinger.UI.Dialogs.Controls
{
    /// <summary>
    /// Interaktionslogik für DialogContainer.xaml
    /// </summary>
    public partial class DialogContainer : UserControl
    {
        public DialogContainer()
        {
            InitializeComponent();
        }
        public void CloseDialog(object dialog = null)
        {
            if (dialog == null)
                notificationGrid.Children.Clear();
            else
                notificationGrid.Children.Remove(dialog as UIElement);
        }
        public void PushMessageDialog(DialogType dialogType, string title, string message, IList<IDialogButton> buttonCollection)
        {
            var dialog = new DialogControl();
            Control customDialog = new MessageDialog(dialogType, title, message, buttonCollection);
            SetEmptyActions(buttonCollection);
            dialog.Context = customDialog;
            notificationGrid.Children.Add(dialog);
            ApplyFadeInAnimation(dialog); // Animation anwenden
        }

        public void PushTransferDialog(ITransferItem from, ITransferItem to, string header, string message, Action actionContinue, IList<IDialogButton> buttonCollection)
        {

        }

        public void PushAskingDialog(string header, string message, IList<IDialogButton> buttonCollection)
        {
            var dialog = new DialogControl();
            Control customDialog = new MessageDialog(DialogType.ASKING, header, message, buttonCollection);
            SetEmptyActions(buttonCollection);
            dialog.Context = customDialog;
            notificationGrid.Children.Add(dialog);
            ApplyFadeInAnimation(dialog); // Animation anwenden
        }

        public void PushCustomDialog(Control control)
        {

        }
        private void SetEmptyActions(IList<IDialogButton> buttonCollection)
        {
            foreach (var item in buttonCollection)
            {
                if (item.OnButtonClick == null)
                {
                    item.OnButtonClick = new Action(() =>
                    {
                        notificationGrid.Children.Clear();
                    });
                }
            }
        }
        private void ApplyFadeInAnimation(UIElement element)
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation();
            fadeInAnimation.From = 0;
            fadeInAnimation.To = 1;
            fadeInAnimation.Duration = TimeSpan.FromSeconds(0.6);

            element.Opacity = 0;
            element.BeginAnimation(UIElement.OpacityProperty, fadeInAnimation);
        }
    }
}
