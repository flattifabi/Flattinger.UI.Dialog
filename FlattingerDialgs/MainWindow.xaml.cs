using Flattinger.Core.Interface.DialogMessage.Base;
using Flattinger.Core.Theme;
using Flattinger.UI.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace FlattingerDialgs
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DialogProvider dialogProvider;
        AppTheme _theme;
        public MainWindow()
        {
            InitializeComponent();
            _theme = new AppTheme();
            _theme.ChangeTheme(Flattinger.Core.Enums.Theme.DARK);
            dialogProvider = new DialogProvider(dialogContainer);
        }
        public void PublishDialog()
        {
            //dialogProvider.DialogService.PushMessageDialog(Flattinger.Core.Enums.DialogType.INFO, "Möchtest du das Farbschema der Controls ändern?", "Drücke auf das gewünschte Farbeschema um dieses mit sofortiger wirkung anzuwenden. Wird dieses nicht überall angewendet bitten wir dich die anwendung neu zu starten", new List<IDialogButton>()
            //{
            //    new DialogButton() {Content="Dialog schliessen", BackgroundColor=Brushes.LightGray, BorderBrush=Brushes.Transparent, ButtonRadius=17, ForegroundColor=Brushes.Black, OnButtonClick = new Action(() =>
            //    {
            //        dialogProvider.DialogService.CloseDialogCommand();
            //    })},
            //    new DialogButton() {Content="Dunkel", BackgroundColor=Brushes.LightGray, BorderBrush=Brushes.Transparent, ButtonRadius=17, ForegroundColor=Brushes.Black, OnButtonClick = new Action(() =>
            //    {
            //        _theme.ChangeTheme(Flattinger.Core.Enums.Theme.DARK);
            //    })},
            //    new DialogButton() {Content = "Hell", BackgroundColor=Brushes.Red,Icon=MahApps.Metro.IconPacks.PackIconMaterialKind.NotebookMultiple, BorderBrush=Brushes.Transparent, ButtonRadius=17, ForegroundColor=Brushes.White, OnButtonClick = new Action(() => {
            //        _theme.ChangeTheme(Flattinger.Core.Enums.Theme.LIGHT);
            //    }) }
            //});
            dialogProvider.DialogService.PushMessageDialog(Flattinger.Core.Enums.DialogType.INFO, "Change the color scheme", "Do you want to change the color scheme? Then press the corresponding button in the action menu", new List<IDialogButton>()
            {
                new DialogButton() {Content="Close Dialog", BackgroundColor=Brushes.Red, BorderBrush=Brushes.Transparent, ButtonRadius=15,
                    ForegroundColor= Brushes.White,Icon = MahApps.Metro.IconPacks.PackIconMaterialKind.Delete, OnButtonClick = new Action(() =>
                    {
                        dialogProvider.DialogService.CloseDialogCommand();
                    })},
                new DialogButton() { Content="Dark", BackgroundColor=Brushes.Gray, BorderBrush=Brushes.Transparent, ButtonRadius=15,
                    ForegroundColor=Brushes.White, OnButtonClick = new Action(() =>
                    {
                        _theme.ChangeTheme(Flattinger.Core.Enums.Theme.DARK);
                    })},
                new DialogButton() { Content="Light", BackgroundColor=Brushes.LightGray, BorderBrush=Brushes.Transparent, ButtonRadius=15,
                    ForegroundColor=Brushes.White, OnButtonClick = new Action(() =>
                    {
                        _theme.ChangeTheme(Flattinger.Core.Enums.Theme.LIGHT);
                    })},
            });
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            PublishDialog();
        }
    }
}
