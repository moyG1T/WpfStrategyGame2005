using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using WpfStrategyGame2005.MyClasses;
using System.Diagnostics.Eventing.Reader;

namespace WpfStrategyGame2005
{
    /// <summary>
    /// Логика взаимодействия для UnitPage.xaml
    /// </summary>
    public partial class UnitPage : Page
    {
        private Unit unit;
        public UnitPage(Unit _unit)
        {
            InitializeComponent();
            unit = _unit;

            ImageSource imageSource = new BitmapImage(new Uri(unit.Photo, UriKind.Relative));
            UnitImage.Source = imageSource;

            switch (unit.WeaponSlot)
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

        private void Refresh()
        {
            NameText.Text = unit.Name;

            StrengthText.Text = $"{unit.Strength}/{unit.MaxStrength}";
            DexterityText.Text = $"{unit.Dexterity}/{unit.MaxDexterity}";
            IntelligenceText.Text = $"{unit.Intelligence}/{unit.MaxIntelligence}";
            VitalityText.Text = $"{unit.Vitality}/{unit.MaxVitality}";

            HealthText.Text = $"{unit.Health}";
            ManaText.Text = $"{unit.Mana}";

            PhysicalDamageText.Text = unit.PhysicalDamage.ToString();
            ArmorText.Text = unit.Armor.ToString();
            MagicDamageText.Text = unit.MagicDamage.ToString();
            MagicArmorText.Text = unit.MagicArmor.ToString();
            CritChanceText.Text = unit.CritChance.ToString();
            CritDamageText.Text = unit.CritDamage.ToString();

            SkillPoints.Text = unit.Points.ToString();
        }

        private void Unload_Checked(object sender, RoutedEventArgs e)
        {
            unit.WeaponSlot = Unit.Weapons.None;
            Refresh();
        }

        private void LoadStick_Checked(object sender, RoutedEventArgs e)
        {
            unit.WeaponSlot = Unit.Weapons.Stick;
            Refresh();
        }

        private void LoadDagger_Checked(object sender, RoutedEventArgs e)
        {
            unit.WeaponSlot = Unit.Weapons.Dagger;
            Refresh();
        }

        private void LoadSword_Checked(object sender, RoutedEventArgs e)
        {
            unit.WeaponSlot = Unit.Weapons.Sword;
            Refresh();
        }

        private void LoadAxe_Checked(object sender, RoutedEventArgs e)
        {
            unit.WeaponSlot = Unit.Weapons.Axe;
            Refresh();
        }

        private void LoadHammer_Checked(object sender, RoutedEventArgs e)
        {
            unit.WeaponSlot = Unit.Weapons.Hammer;
            Refresh();
        }
    }
}
