using Flattinger.Core.Interface.DialogMessage.Base;
using Flattinger.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Flattinger.UI.Dialogs.Controls.ViewModel
{
    public class TransferDialogViewModel : BaseViewModel
    {
        public ITransferItem TransferFrom { get; set; }
        public ITransferItem TransferTo { get; set; }
        public string Header { get; set; }
        public string Message { get; set; }
        public ICommand ActionContinue { get; set; }
        public IList<IDialogButton> buttonCollection { get; set; }
        public TransferDialogViewModel(ITransferItem from, ITransferItem to, string header, string message, Action actionContinue, IList<IDialogButton> buttonCollection) 
        {
            this.TransferTo = to;
            this.TransferFrom = from;
            this.Header = header;
            this.Message = message;
            this.ActionContinue = new RelayCommand(param => actionContinue());
            this.buttonCollection = buttonCollection;
        }
    }
}
