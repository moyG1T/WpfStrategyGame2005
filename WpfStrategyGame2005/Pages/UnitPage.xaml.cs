using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using WpfStrategyGame2005.MyClasses;

#pragma warning disable CS0168 // Переменная объявлена, но не используется
namespace WpfStrategyGame2005
{
    /// <summary>
    /// Логика взаимодействия для UnitPage.xaml
    /// </summary>
    public partial class UnitPage : Page
    {
        UnitViewModel unitViewModel;
        public UnitPage(UnitViewModel _unitViewModel)
        {
            InitializeComponent();

            unitViewModel = _unitViewModel;
            DataContext = unitViewModel;

            //UnitImage.Source = new BitmapImage(new Uri(unitViewModel.SelectedUnit.Photo, UriKind.Relative));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UnitSelect());
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {

        }



        private void Unload_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void LoadStick_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void LoadDagger_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void LoadSword_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void LoadAxe_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void LoadHammer_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Plus100_Click(object sender, RoutedEventArgs e)
        {
            unitViewModel.SelectedUnit.Exp += 100;
        }

        private void Plus1000_Click(object sender, RoutedEventArgs e)
        {
            unitViewModel.SelectedUnit.Exp += 1000;
        }

        private void Plus10000_Click(object sender, RoutedEventArgs e)
        {
            unitViewModel.SelectedUnit.Exp += 10000;
        }

    }
}
