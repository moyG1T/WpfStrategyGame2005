using System.Windows;
using System.Windows.Controls;
using WpfStrategyGame2005.MyClasses;

namespace WpfStrategyGame2005
{
    /// <summary>
    /// Логика взаимодействия для UnitPage.xaml
    /// </summary>
    public partial class UnitPage : Page
    {
        private Unit unit;
        private int points = 50;
        public UnitPage(Unit _unit)
        {
            InitializeComponent();
            unit = _unit;
            Refresh();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.MainWindowFrame.Navigate(new UnitSelect());
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            points = int.Parse(SkillPoints.Text);
            if (points > 0)
            {
                if (sender.Equals(StrengthUp))
                {
                    if (unit.Strength < unit.MaxStrength)
                    {
                        unit.Strength++;
                        points--;
                    }
                }
                else if (sender.Equals(DexteryUp))
                {
                    if (unit.Dexterity < unit.MaxDexterity)
                    {
                        unit.Dexterity++;
                        points--;
                    }
                }
                else if (sender.Equals(IntelligenceUp))
                {
                    if (unit.Intelligence < unit.MaxIntelligence)
                    {
                        unit.Intelligence++;
                        points--;
                    }
                }
                else if (sender.Equals(VitalityUp))
                {
                    if (unit.Vitality < unit.MaxVitality)
                    {
                        unit.Vitality++;
                        points--;
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

            SkillPoints.Text = points.ToString();
        }

        private void DexteryUp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
