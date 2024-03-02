using System.Collections.Generic;
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
        public ObservableCollection<Chest> Chests { get; set; }
        public ObservableCollection<Charity> Charities { get; set; }

        public UnitViewModel()
        {
            Charities = new ObservableCollection<Charity>()
            {
                new Charity("Без зачарований", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0, 0 ),
                new Charity("Мобильность", 0, 5, 0, 5, 0, 0, 0, 0, 0, 0 ,0, 0 ),
                new Charity("Тупость", 10, 10, 0, 10, 10, 0, 0, 0, 0, 0 ,0, 0 ),
                new Charity("Донат", 100, 100, 100, 100, 100, 100, 100, 100, 100, 100,0, 0 ),
            };

            Chests = new ObservableCollection<Chest>()
            {
                new Chest("Маечка",                 Charities, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
                new Chest("Строительная роба",      Charities, 0, 0, 20, 0, 10, 20, 0, 0, 0, 0, 0, 0),
                new Chest("Гачи броня (кожа)",      Charities, 10, 20, 0, 0, 15, 0, 0, 0, 0, 0, 0, 0),
                new Chest("Рабская броня (цепи)",   Charities, 15, -10, 0, 0, 15, 20, 0, 0, 0, 0, 0, 0),
                new Chest("Пластины (музыкальные)", Charities, 20, -20, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0),
            };

            Weapons = new ObservableCollection<Weapon>()
            {
                new Weapon("Кулаки", Charities, true,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0, 0),
                new Weapon("Щит", Charities, true,      0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0, 0),
                new Weapon("Палка", Charities, false,   0, 0, 15, 0, 0, 50, 0, 0, 0, 0 ,1.05, 3),
                new Weapon("Кинжал", Charities, false,  0, 25, 0, 0, 0, 0, 15, 0, 0, 0 ,1.6, 1.7),
                new Weapon("Меч", Charities, true,      15, 15, 0, 0, 0, 0, 25, 0, 0, 0 ,1.35, 2.5),
                new Weapon("Топор", Charities, true,    40, 0, 0, 0, 0, 0, 40, 0, 0, 0 ,1.2, 2.7),
                new Weapon("Кувалда", Charities, false, 25, 0, 0, 0, 25, 0, 40, 0, 0, 0 ,1.1, 3.5),
            };

            Units = new ObservableCollection<Unit>()
            {
                new Warrior("Воин", "/Resources/cherry.jpg", Weapons, Chests, 30, 15, 10, 25, 50),
                new Rogue("Жулик", "/Resources/rogue.jpg",Weapons, Chests, 20, 30, 15, 20, 50),
                new Wizard("Волшебник", "/Resources/mag.png",Weapons, Chests,15, 20, 35, 15, 50),
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
