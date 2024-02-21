using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfStrategyGame2005.Equipments;
using static WpfStrategyGame2005.MyClasses.Weapon;

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
        public ObservableCollection<Equipment> Equipments { get; set; }
        public ObservableCollection<Charity> Charities { get; set; }

        public UnitViewModel()
        {
            Charities = new ObservableCollection<Charity>()
            {
                new Charity("Без зачарований", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0, 0 ),
                new Charity("Мобильность", 0, 5, 0, 5, 0, 0, 0, 0, 0, 0 ,0, 0 ),
                new Charity("Острота", 10, 10, 0, 10, 10, 0, 0, 0, 0, 0 ,0, 0 ),
                new Charity("Донат", 100, 100, 100, 100, 100, 100, 100, 100, 100, 100,0, 0 ),
            };

            Equipments = new ObservableCollection<Equipment>()
            {
                new Weapon("Щит",Charities[0],Charities, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0, 0),
                new Weapon("Палка", Charities[0],Charities, 0, 0, 15, 0, 0, 50, 0, 0, 0, 0 ,1.05, 3),
                new Weapon("Кинжал", Charities[0],Charities, 0, 25, 0, 0, 0, 0, 15, 0, 0, 0 ,1.6, 1.7),
                new Weapon("Меч", Charities[0],Charities, 15, 15, 0, 0, 0, 0, 25, 0, 0, 0 ,1.35, 2.5),
                new Weapon("Топор", Charities[0],Charities, 40, 0, 0, 0, 0, 0, 40, 0, 0, 0 ,1.2, 2.7),
                new Weapon("Кувалда", Charities[0],Charities, 25, 0, 0, 0, 25, 0, 40, 0, 0, 0 ,1.1, 3.5),
            };

            Units = new ObservableCollection<Unit>()
            {
                new Warrior("Воин", "/Resources/cherry.jpg", Equipments, 30, 15, 10, 25, 50),
                new Rogue("Жулик", "/Resources/rogue.jpg", Equipments, 20, 30, 15, 20, 50),
                new Wizard("Волшебник", "/Resources/mag.png", Equipments, 15, 20, 35, 15, 50),
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
