using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Warrior warrior = new Warrior("Воин", 30, 15, 10, 25);
            App.mainWindow.MainWindowFrame.Navigate(new UnitPage(warrior));
        }

        private void RogueButton_Click(object sender, RoutedEventArgs e)
        {
            Rogue rogue = new Rogue("Жулик", 20, 30, 15, 20);
            App.mainWindow.MainWindowFrame.Navigate(new UnitPage(rogue));
        }

        private void WizardButton_Click(object sender, RoutedEventArgs e)
        {
            Wizard wizard = new Wizard("Волшебник", 15, 20, 35, 15);
            App.mainWindow.MainWindowFrame.Navigate(new UnitPage(wizard));
        }
    }
}
