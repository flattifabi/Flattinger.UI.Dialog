# Flattinger.UI.Dialog

For using this Service add the Namespace at your MainWindow:
```
xmlns:dialog="clr-namespace:Flattinger.UI.Dialogs.Controls;assembly=Flattinger.UI.Dialogs"
...
<Grid>
  <dialog:DialogContainer x:Name="dialogContainer"/>
</Grid>
```

if you use MVVM pass this container to your ViewModel

Here how to use
```c#
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
```c#
