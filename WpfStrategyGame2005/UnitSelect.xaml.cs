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
            Warrior warrior = new Warrior("Воин", "/Resources/cherry.jpg", 30, 15, 10, 25);
            App.mainWindow.MainWindowFrame.Navigate(new UnitPage(warrior));
        }

        private void RogueButton_Click(object sender, RoutedEventArgs e)
        {
            Rogue rogue = new Rogue("Жулик", "/Resources/rogue.jpg", 20, 30, 15, 20);
            App.mainWindow.MainWindowFrame.Navigate(new UnitPage(rogue));
        }

        private void WizardButton_Click(object sender, RoutedEventArgs e)
        {
            Wizard wizard = new Wizard("Волшебник", "/Resources/mag.png", 15, 20, 35, 15);
            App.mainWindow.MainWindowFrame.Navigate(new UnitPage(wizard));
        }
    }
}
