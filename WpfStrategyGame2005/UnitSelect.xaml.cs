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
        UnitViewModel unitViewModel;
        public UnitSelect()
        {
            InitializeComponent();
            unitViewModel = new UnitViewModel();
            DataContext = unitViewModel;
        }

        private void WarriorButton_Click(object sender, RoutedEventArgs e)
        {
            unitViewModel.SelectedUnit = unitViewModel.Units[0];
            NavigationService.Navigate(new UnitPage(unitViewModel));
        }

        private void RogueButton_Click(object sender, RoutedEventArgs e)
        {
            unitViewModel.SelectedUnit = unitViewModel.Units[1];
            NavigationService.Navigate(new UnitPage(unitViewModel));
        }

        private void WizardButton_Click(object sender, RoutedEventArgs e)
        {
            unitViewModel.SelectedUnit = unitViewModel.Units[2];
            NavigationService.Navigate(new UnitPage(unitViewModel));
        }
    }
}
