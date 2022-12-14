using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bank
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Sporici> S = new List<Sporici>();
        //List<Uver> U = new List<Uver>();
        //List<Student> St = new List<Student>();
        double urok = 5;
        int pocetmesicu = 0;
        public MainWindow()
        {
            TimeTick();
            InitializeComponent();
            lb_urok.Content = urok + "%";
            lb_time.Content = pocetmesicu + ". měsíc";
            listbox_spor.ItemsSource = S;
        }

        private void btn_Zalozit_Click(object sender, RoutedEventArgs e)
        {
            double d;
            try
            {
                d = Convert.ToDouble(tb_Vklad.Text);
                Sporici spo = new Sporici(tb_JmenoPrijemni.Text, d, urok);
                S.Add(spo);
                tb_text.Text = spo.Majitel + "," + spo.Zustatek + "Kč ," + spo.Urok + " %";
                listbox_spor.Items.Refresh();
                tb_JmenoPrijemni.Text = null;
                tb_Vklad.Text = null;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void bt_Vklad_Click(object sender, RoutedEventArgs e)
        {
            Sporici spo = (Sporici)listbox_spor.SelectedItem;
            try
            {
                double d = Convert.ToDouble(tb_Vloz.Text);
                spo.Vklad(d);
                tb_text.Text = spo.Majitel + "," + spo.Zustatek + "Kč ," + spo.Urok + " %";
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void bt_Vyber_Click(object sender, RoutedEventArgs e)
        {
            Sporici spo = (Sporici)listbox_spor.SelectedItem;
            try
            {
                double d = Convert.ToDouble(tb_Vyber.Text);
                spo.Vyber(d);
                tb_text.Text = spo.Majitel + "," + spo.Zustatek + "Kč ," + spo.Urok + " %";
            }
            catch (Exception)
            {       
                MessageBox.Show("Chyba", "Nemáte dost peněž!", MessageBoxButton.OK);
            }
        }

        private void ListBoxItem_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Sporici spo = (Sporici)listbox_spor.SelectedItem;
            tb_text.Text = spo.Majitel + "," + spo.Zustatek + "Kč ," + spo.Urok + " %";
        }
        public async Task TimeTick()
        {
            while (true)
            {
                await Task.Delay(5000);
                foreach (var item in S)
                {
                    item.Zustatek = item.Zustatek * 1.05;
                }
                if (listbox_spor.SelectedItem != null)
                {
                    Sporici spo = (Sporici)listbox_spor.SelectedItem;
                    tb_text.Text = spo.Majitel + "," + spo.Zustatek + "Kč ," + spo.Urok + " %";
                }
                pocetmesicu++;
                lb_time.Content = pocetmesicu + ". měsíc";
            }
        }
    }
}
