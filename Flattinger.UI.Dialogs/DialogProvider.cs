using Flattinger.Core.Interface.DialogMessage;
using Flattinger.UI.Dialogs.Controls;
using Flattinger.UI.Dialogs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flattinger.UI.Dialogs
{
    public class DialogProvider
    {
        public IDialogService DialogService { get; set; }
        public DialogProvider(DialogContainer dialogContainer) 
        {
            DialogService = new NotificationService(dialogContainer);
        }
    }
}
