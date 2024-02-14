using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using WpfStrategyGame2005.MyInterfaces;

namespace WpfStrategyGame2005.MyClasses
{
    public class Unit : INotifyPropertyChanged
    {
        private int _strength;
        private int _dexterity;
        private int _intelligence;
        private int _vitality;


        public string Name { get; set; }
        public string Photo { get; set; }
        public int Points { get; set; }
        public int Exp { get; set; }

        public virtual int Strength
        {
            get { return _strength; }
            set
            {
                Health = Vitality * 2 + value;
                PhysicalDamage = value;
                _strength = value;
                OnPropertyChanged("Strength");
            }
        }
        public int MaxStrength { get; set; }

        public virtual int Dexterity
        {
            get { return _dexterity; }
            set
            {
                Armor = value;
                CritChance = (int)(value * 0.2);
                CritDamage = (int)(value * 0.1);
                //if (value >= MaxDexterity)
                //    _dexterity = MaxDexterity;
                //else
                _dexterity = value;
                OnPropertyChanged("Dexterity");
            }
        }
        public int MaxDexterity { get; set; }

        public virtual int Intelligence
        {
            get { return _intelligence; }
            set
            {
                Mana = value;
                MagicDamage = (int)(value * 0.2);
                MagicArmor = (int)(value * 0.5);
                //if (value >= MaxIntelligence)
                //    _intelligence = MaxIntelligence;
                //else
                _intelligence = value;
                OnPropertyChanged("Intelligence");
            }
        }
        public int MaxIntelligence { get; set; }

        public virtual int Vitality
        {
            get { return _vitality; }
            set
            {
                Health = value * 2 + Strength;
                //if (value >= MaxVitality)
                //    _vitality = MaxVitality;
                //else
                _vitality = value;
                OnPropertyChanged("Vitality");
            }
        }
        public int MaxVitality { get; set; }



        public int Health { get; set; }
        public int Mana { get; set; }
        public int PhysicalDamage { get; set; }
        public int Armor { get; set; }
        public int MagicDamage { get; set; }
        public int MagicArmor { get; set; }
        public int CritChance { get; set; }
        public int CritDamage { get; set; }

        private Weapon leftHand;
        private Weapon rightHand;

        public Weapon LeftHand
        {
            get
            {
                return leftHand;
            }
            set
            {
                leftHand = value;
                OnPropertyChanged("LeftHand");
            }
        }
        public Weapon RightHand
        {
            get
            {
                return rightHand;
            }
            set
            {
                MessageBox.Show("123");
                rightHand = value;
                OnPropertyChanged("RightHand");
            }
        }

        public Unit(string name, string photo, int strength, int dexterity, int intelligence, int vitality, Weapon leftHand, Weapon rightHand, int points)
        {
            Name = name;
            Photo = photo;
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
            Vitality = vitality;
            LeftHand = leftHand;
            RightHand = rightHand;
            Points = points;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
