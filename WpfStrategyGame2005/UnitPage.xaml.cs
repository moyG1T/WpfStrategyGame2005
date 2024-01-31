using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfStrategyGame2005.MyClasses;

namespace WpfStrategyGame2005
{
    /// <summary>
    /// Логика взаимодействия для UnitPage.xaml
    /// </summary>
    public partial class UnitPage : Page
    {
        public UnitPage(Unit unit)
        {
            InitializeComponent();

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
        }
    }
}
