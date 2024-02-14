using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfStrategyGame2005.MyClasses
{
    public class UnitViewModel : INotifyPropertyChanged
    {
        private Unit selectedUnit;
        public Unit SelectedUnit
        {
            get
            {
                return selectedUnit;
            }
            set
            {
                selectedUnit = value;
                OnPropertyChanged("SelectedUnit");
            }
        }


        public ObservableCollection<Unit> Units { get; set; }
        public ObservableCollection<Weapon> Weapons { get; set; }

        public UnitViewModel()
        {
            Weapons = new ObservableCollection<Weapon>()
            {
                new Weapon("Кулаки", Weapon.WeaponType.None, true, true),
                new Weapon("Щит", Weapon.WeaponType.None, false, false),
                new Weapon("Палка", Weapon.WeaponType.None, false, false),
                new Weapon("Кинжал", Weapon.WeaponType.None,  true, false),
                new Weapon("Меч", Weapon.WeaponType.None, false, true),
                new Weapon("Топор",Weapon.WeaponType.None,  false, true),
                new Weapon("Кувалда", Weapon.WeaponType.None, false, false),
            };

            Units = new ObservableCollection<Unit>()
            {
                new Warrior("Воин", "/Resources/cherry.jpg", 30, 15, 10, 25, Weapons[0], Weapons[0], 50),
                new Rogue("Жулик", "/Resources/rogue.jpg", 20, 30, 15, 20, Weapons[0], Weapons[0], 50),
                new Wizard("Волшебник", "/Resources/mag.png", 15, 20, 35, 15, Weapons[0], Weapons[0], 50),
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
