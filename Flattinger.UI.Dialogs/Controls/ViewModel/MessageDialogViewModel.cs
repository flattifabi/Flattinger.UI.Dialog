using Flattinger.Core.Enums;
using Flattinger.Core.Interface.DialogMessage.Base;
using Flattinger.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Flattinger.UI.Dialogs.Controls.ViewModel
{
    public class MessageDialogViewModel : BaseViewModel
    {
        public DialogType DialogType { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public IList<IDialogButton> Buttons { get; set; }
        private StackPanel _buttonPanel;
        public MessageDialogViewModel(DialogType dialogType, string title, string message, IList<IDialogButton> buttonCollection, StackPanel stackPanel)
        {
            this.DialogType = dialogType;
            this.Title = title;
            this.Message = message;
            this.Buttons = buttonCollection;
            this._buttonPanel = stackPanel;
            
            FillButtons();
        }
        public void FillButtons()
        {
            foreach (var item in Buttons)
            {
                Button btn = new Button();
                
                if(item.Icon == MahApps.Metro.IconPacks.PackIconMaterialKind.None)
                {
                    btn.Content = item.Content;
                }
                else
                {
                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Orientation = Orientation.Horizontal;
                    stackPanel.Margin = new Thickness(5);

                    // Icon hinzufügen
                    MahApps.Metro.IconPacks.PackIconMaterial icon = new MahApps.Metro.IconPacks.PackIconMaterial();
                    icon.Kind = item.Icon;
                    stackPanel.Children.Add(icon);

                    // Text hinzufügen
                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = item.Content;
                    textBlock.Margin = new Thickness(5, 0, 0, 0);
                    stackPanel.Children.Add(textBlock);

                    btn.Content = stackPanel;
                }

                btn.Background = item.BackgroundColor;
                btn.Foreground = item.ForegroundColor;
                btn.FontSize = 13;
                btn.BorderThickness = new Thickness(0);
                Border border = new Border();
                border.Margin = new Thickness(0, 0, 5, 0);
                border.Background = item.BackgroundColor;
                border.Background = item.BackgroundColor;
                border.BorderBrush = item.BorderBrush;
                border.Padding = new Thickness(11, 7, 11, 7);
                border.CornerRadius = new CornerRadius(item.ButtonRadius); // Setze den Corner Radius hier entsprechend deiner Anforderungen
                border.Child = btn;
                _buttonPanel.Children.Add(border);



                btn.Click += (sender, e) =>
                {
                    item.OnButtonClick();
                };
            }
        }
    }
}
