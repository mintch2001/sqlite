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

namespace SQL1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> a;
        public MainWindow()
        {
            InitializeComponent();

            DataAccess.CreateTable();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            a = new List<string>();

            string set = " ";
            foreach (string i in DataAccess.ShowDetail())
            {
                set = set + "\n" +i;
            }
            MessageBox.Show("Name Account : \n" + set);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataAccess.AddData(txtInput.Text);
        }
    }
}
