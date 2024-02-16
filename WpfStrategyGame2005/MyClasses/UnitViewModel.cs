using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
                new Weapon("Кулаки", Weapon.WeaponType.None, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0, 0),
                new Weapon("Щит", Weapon.WeaponType.None, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0, 0),
                new Weapon("Палка", Weapon.WeaponType.None, 0, 0, 15, 0, 0, 50, 0, 0, 0, 0 ,0, 0),
                new Weapon("Кинжал", Weapon.WeaponType.None, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0, 0),
                new Weapon("Меч", Weapon.WeaponType.None, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0, 0),
                new Weapon("Топор",Weapon.WeaponType.None, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0, 0),
                new Weapon("Кувалда", Weapon.WeaponType.None, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0, 0),
            };

            Units = new ObservableCollection<Unit>()
            {
                new Warrior("Воин", "/Resources/cherry.jpg", 30, 15, 10, 25, 50),
                new Rogue("Жулик", "/Resources/rogue.jpg", 20, 30, 15, 20, 50),
                new Wizard("Волшебник", "/Resources/mag.png", 15, 20, 35, 15, 50),
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
