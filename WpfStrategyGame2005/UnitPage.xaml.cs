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

            ImageSource imageSource = new BitmapImage(new Uri(_unitViewModel.SelectedUnit.Photo, UriKind.Relative));
            UnitImage.Source = imageSource;

            DataContext = unitViewModel;

            Str.Text = _unitViewModel.SelectedUnit.Strength.ToString();
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
        }

        private void Plus1000_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Plus10000_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
