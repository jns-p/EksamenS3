using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace EksamenS3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Func Func { get ; set; } = new Func();

        public ObservableCollection<Bog> BogListe
        {
            get
            {
                return Func.Bøger;
            }
        }
        public ObservableCollection<Låner> LånerListe
        {
            get
            {
                return Func.Lånere;
            }
        }
        public ObservableCollection<Udlån> UdlånListe
        {
            get
            {
                return Func.Udlånere;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }       

        private void btn_RegistrerBog_Click(object sender, RoutedEventArgs e)
        {
            Func.OpretBog(tb_regForfatter.Text, tb_regTitel.Text, tb_regUdgiver.Text, int.Parse(tb_regUdgiverÅr.Text), int.Parse(tb_regAntal.Text), int.Parse(tb_regISBN.Text));
        }

        private void btn_regLåner_Click(object sender, RoutedEventArgs e)
        {
            Func.OpretLåner(tb_regLånere.Text, tb_regEmail.Text);
        }

        private void btn_Udlån_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            Func.OpretUdlån(dp_UdlånDato.SelectedDate, int.Parse(tb_UdlånAntal.Text), cbx_Låner.SelectedItem as Låner, cbx_UdlånBog.SelectedItem as Bog);      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl i udlån");
            }            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Func.SletLån(dg_Lån.SelectedItem as Udlån);
        }

        private void btn_regRediger_Click(object sender, RoutedEventArgs e)
        {
            Func.SletBog(dg_Bøger.SelectedItem as Bog);
        }

        private void btn_SletLåner_Click(object sender, RoutedEventArgs e)
        {
            Func.SletUdlåner(dg_udlånere.SelectedItem as Låner);
        }
    }
}
