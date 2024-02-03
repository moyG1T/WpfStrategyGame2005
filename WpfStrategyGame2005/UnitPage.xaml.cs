using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using WpfStrategyGame2005.MyClasses;

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

            Refresh();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.MainWindowFrame.Navigate(new UnitSelect());
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            App.points = int.Parse(SkillPoints.Text);
            if (App.points > 0)
            {
                if (sender.Equals(StrengthUp))
                {
                    if (unit.Strength < unit.MaxStrength)
                    {
                        unit.Strength++;
                        App.points--;
                    }
                }
                else if (sender.Equals(DexteryUp))
                {
                    if (unit.Dexterity < unit.MaxDexterity)
                    {
                        unit.Dexterity++;
                        App.points--;
                    }
                }
                else if (sender.Equals(IntelligenceUp))
                {
                    if (unit.Intelligence < unit.MaxIntelligence)
                    {
                        unit.Intelligence++;
                        App.points--;
                    }
                }
                else if (sender.Equals(VitalityUp))
                {
                    if (unit.Vitality < unit.MaxVitality)
                    {
                        unit.Vitality++;
                        App.points--;
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

            SkillPoints.Text = App.points.ToString();
        }

        private void DexteryUp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
