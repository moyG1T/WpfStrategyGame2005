using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using WpfStrategyGame2005.MyClasses;
using System.Diagnostics.Eventing.Reader;

#pragma warning disable CS0168 // Переменная объявлена, но не используется
namespace WpfStrategyGame2005
{
    /// <summary>
    /// Логика взаимодействия для UnitPage.xaml
    /// </summary>
    public partial class UnitPage : Page
    {
        private Unit unit;

        int strength;
        int dexterity;
        int intelligence;
        int vitality;

        int health;
        int mana;

        int physicalDamage;
        int armor;
        int magicDamage;
        int magicArmor;
        int critChance;
        int critDamage;

        public UnitPage(Unit _unit)
        {
            InitializeComponent();
            unit = _unit;

            ImageSource imageSource = new BitmapImage(new Uri(unit.Photo, UriKind.Relative));
            UnitImage.Source = imageSource;


            switch (unit.RightHand)
            {
                case Unit.Weapons.None:
                    Unload.IsChecked = true;
                    break;
                case Unit.Weapons.Stick:
                    LoadStick.IsChecked = true;
                    break;
                case Unit.Weapons.Dagger:
                    LoadDagger.IsChecked = true;
                    break;
                case Unit.Weapons.Sword:
                    LoadSword.IsChecked = true;
                    break;
                case Unit.Weapons.Axe:
                    LoadAxe.IsChecked = true;
                    break;
                case Unit.Weapons.Hammer:
                    LoadHammer.IsChecked = true;
                    break;
            }

            Refresh();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.MainWindowFrame.Navigate(new UnitSelect());
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            unit.Points = int.Parse(SkillPoints.Text);
            if (unit.Points > 0)
            {
                if (sender.Equals(StrengthUp))
                {
                    if (unit.Strength < unit.MaxStrength)
                    {
                        unit.Strength++;
                        unit.Points--;
                    }
                }
                else if (sender.Equals(DexteryUp))
                {
                    if (unit.Dexterity < unit.MaxDexterity)
                    {
                        unit.Dexterity++;
                        unit.Points--;
                    }
                }
                else if (sender.Equals(IntelligenceUp))
                {
                    if (unit.Intelligence < unit.MaxIntelligence)
                    {
                        unit.Intelligence++;
                        unit.Points--;
                    }
                }
                else if (sender.Equals(VitalityUp))
                {
                    if (unit.Vitality < unit.MaxVitality)
                    {
                        unit.Vitality++;
                        unit.Points--;
                    }
                }
            }

            Refresh();
        }

        private void ShowStats(int strg, int dext, int intel, int vit,
            int hlth, int mn, int pDamage, int armr, int mDamage, int mArmor, int cChance, int cDamage)
        {
            if (strg >= unit.MaxStrength)
                strg = unit.MaxStrength;
            if (dext >= unit.MaxDexterity)
                dext = unit.MaxDexterity;
            if (intel >= unit.MaxIntelligence)
                intel = unit.MaxIntelligence;
            if (vit >= unit.MaxVitality)
                vit = unit.MaxVitality;

            StrengthText.Text = $"{strg}/{unit.MaxStrength}";
            DexterityText.Text = $"{dext}/{unit.MaxDexterity}";
            IntelligenceText.Text = $"{intel}/{unit.MaxIntelligence}";
            VitalityText.Text = $"{vit}/{unit.MaxVitality}";

            HealthText.Text = $"{hlth}";
            ManaText.Text = $"{mn}";

            PhysicalDamageText.Text = pDamage.ToString();
            ArmorText.Text = armr.ToString();
            MagicDamageText.Text = mDamage.ToString();
            MagicArmorText.Text = mArmor.ToString();
            CritChanceText.Text = cChance.ToString();
            CritDamageText.Text = cDamage.ToString();
        }

        private void Refresh()
        {
            strength = unit.Strength;
            dexterity = unit.Dexterity;
            intelligence = unit.Intelligence;
            vitality = unit.Vitality;

            health = unit.Health;
            mana = unit.Mana;

            physicalDamage = unit.PhysicalDamage;
            armor = unit.Armor;
            magicDamage = unit.MagicDamage;
            magicArmor = unit.MagicArmor;
            critChance = unit.CritChance;
            critDamage = unit.CritDamage;

            switch (unit.RightHand)
            {
                case Unit.Weapons.None:
                    ShowStats(strength, dexterity, intelligence, vitality, health, mana,
                        physicalDamage, armor, magicDamage, magicArmor, critChance, critDamage);
                    break;

                case Unit.Weapons.Stick:
                    ShowStats(strength, dexterity, intelligence, vitality, health * 2, mana * 2,
                        (int)(physicalDamage * 1.1), armor, magicDamage, magicArmor, (int)(critChance * 1.05), critDamage * 3);
                    break;

                case Unit.Weapons.Dagger:
                    ShowStats(strength, dexterity * 2, intelligence, vitality, health, mana,
                        (int)(physicalDamage * 1.25), armor, magicDamage, magicArmor, critChance, critDamage);
                    break;

                case Unit.Weapons.Sword:
                    ShowStats((int)(strength * 1.5), (int)(dexterity * 0.5), intelligence, vitality, health, mana,
                        (int)(physicalDamage * 1.5), armor, magicDamage, magicArmor, (int)(critChance * 1.05), (int)(critDamage * 1.05));
                    break;

                case Unit.Weapons.Axe:
                    ShowStats(strength * 2, dexterity, intelligence, vitality, health, mana,
                        physicalDamage * 2, armor, magicDamage, magicArmor, (int)(critChance * 1.2), (int)(critDamage * 1.7));
                    break;

                case Unit.Weapons.Hammer:
                    ShowStats(strength, dexterity, intelligence, vitality, health * 2, mana,
                        (int)(physicalDamage * 2.5), armor, magicDamage, magicArmor, (int)(critChance * 1.1), (int)(critDamage * 2.5));
                    break;
            }

            NameText.Text = unit.Name;

            SkillPoints.Text = unit.Points.ToString();

            if (unit.Exp < 1000)
                ExpText.Text = $"Лвл 1 - ({unit.Exp}/1000)";
            else if (unit.Exp >= 1000 && unit.Exp < 3000)
                ExpText.Text = $"Лвл 2 - ({unit.Exp - 1000}/2000)";
            else if (unit.Exp >= 3000 && unit.Exp < 6000)
                ExpText.Text = $"Лвл 3 - ({unit.Exp - 3000}/3000)";
            else if (unit.Exp >= 6000 && unit.Exp < 10000)
                ExpText.Text = $"Лвл 4 - ({unit.Exp - 6000}/4000)";
            else if (unit.Exp >= 10000 && unit.Exp < 15000)
                ExpText.Text = $"Лвл 5 - ({unit.Exp - 10000}/5000)";
            else if (unit.Exp >= 15000 && unit.Exp < 21000)
                ExpText.Text = $"Лвл 6 - ({unit.Exp - 15000}/6000)";
            else if (unit.Exp >= 21000 && unit.Exp < 28000)
                ExpText.Text = $"Лвл 7 - ({unit.Exp - 21000}/7000)";
            else if (unit.Exp >= 28000 && unit.Exp < 36000)
                ExpText.Text = $"Лвл 8 - ({unit.Exp - 28000}/8000)";
            else if (unit.Exp >= 36000 && unit.Exp < 45000)
                ExpText.Text = $"Лвл 9 - ({unit.Exp - 36000}/9000)";
            else if (unit.Exp >= 45000)
                ExpText.Text = $"Лвл 10 - ({unit.Exp - 45000})";
        }

        private void Unload_Checked(object sender, RoutedEventArgs e)
        {
            unit.RightHand = Unit.Weapons.None;
            Refresh();
        }

        private void LoadStick_Checked(object sender, RoutedEventArgs e)
        {
            unit.RightHand = Unit.Weapons.Stick;
            Refresh();
        }

        private void LoadDagger_Checked(object sender, RoutedEventArgs e)
        {
            unit.RightHand = Unit.Weapons.Dagger;
            Refresh();
        }

        private void LoadSword_Checked(object sender, RoutedEventArgs e)
        {
            unit.RightHand = Unit.Weapons.Sword;
            Refresh();
        }

        private void LoadAxe_Checked(object sender, RoutedEventArgs e)
        {
            unit.RightHand = Unit.Weapons.Axe;
            Refresh();
        }

        private void LoadHammer_Checked(object sender, RoutedEventArgs e)
        {
            unit.RightHand = Unit.Weapons.Hammer;
            Refresh();
        }

        private void Plus100_Click(object sender, RoutedEventArgs e)
        {
            unit.Exp += 100;
            Refresh();
        }

        private void Plus1000_Click(object sender, RoutedEventArgs e)
        {
            unit.Exp += 1000;
            Refresh();
        }

        private void Plus10000_Click(object sender, RoutedEventArgs e)
        {
            unit.Exp += 10000;
            Refresh();
        }
    }
}
