using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfStrategyGame2005.MyClasses
{
    public class UnitViewModel : INotifyPropertyChanged
    {
        public Unit SelectedUnit { get; set; }
        public ObservableCollection<Unit> Units { get; set; }

        public UnitViewModel()
        {
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
