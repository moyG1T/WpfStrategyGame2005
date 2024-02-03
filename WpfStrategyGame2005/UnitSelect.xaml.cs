using System.Windows;
using System.Windows.Controls;
using WpfStrategyGame2005.MyClasses;

namespace WpfStrategyGame2005
{
    /// <summary>
    /// Логика взаимодействия для UnitSelect.xaml
    /// </summary>
    public partial class UnitSelect : Page
    {
        public UnitSelect()
        {
            InitializeComponent();
        }

        private void WarriorButton_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.MainWindowFrame.Navigate(new UnitPage(App.warrior));
        }

        private void RogueButton_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.MainWindowFrame.Navigate(new UnitPage(App.rogue));
        }

        private void WizardButton_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.MainWindowFrame.Navigate(new UnitPage(App.wizard));
        }
    }
}
