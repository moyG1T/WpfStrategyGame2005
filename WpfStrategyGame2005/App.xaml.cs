using System.Windows;
using WpfStrategyGame2005.MyClasses;

namespace WpfStrategyGame2005
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow mainWindow;
        public static Warrior warrior = new Warrior("Воин", "/Resources/cherry.jpg", 30, 15, 10, 25, 50);
        public static Rogue rogue = new Rogue("Жулик", "/Resources/rogue.jpg", 20, 30, 15, 20, 50);
        public static Wizard wizard = new Wizard("Волшебник", "/Resources/mag.png", 15, 20, 35, 15, 50);
    }
}
