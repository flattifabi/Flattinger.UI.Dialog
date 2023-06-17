using Flattinger.Core.Enums;
using Flattinger.Core.Interface.DialogMessage;
using Flattinger.Core.Interface.DialogMessage.Base;
using Flattinger.UI.Dialogs.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Flattinger.UI.Dialogs.Services
{
    public class NotificationService : IDialogService
    {
        private readonly DialogContainer dialogContainer;
        public NotificationService(DialogContainer container)
        {
            dialogContainer = container;
        }
        public void CloseDialogCommand()
        {
            dialogContainer.CloseDialog();
        }
        public void PushAskingDialog(string header, string message, IList<IDialogButton> buttonCollection)
        {
            this.dialogContainer.PushAskingDialog(header, message, buttonCollection);
        }
        public void PushCustomDialog(Control control)
        {
            this.dialogContainer.PushCustomDialog(control);
        }

        public void PushMessageDialog(DialogType dialogType, string title, string message, IList<IDialogButton> buttonCollection)
        {
            this.dialogContainer.PushMessageDialog(dialogType, title, message, buttonCollection);
        }

        public void PushTransferDialog(ITransferItem from, ITransferItem to, string header, string message, Action actionContinue, IList<IDialogButton> buttonCollection)
        {
            this.dialogContainer.PushTransferDialog(from, to, header, message, actionContinue ,buttonCollection);
        }
    }
}
