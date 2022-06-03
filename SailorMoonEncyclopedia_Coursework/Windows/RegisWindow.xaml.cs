using SailorMoonEncyclopedia_Coursework.DB;
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
using System.Windows.Shapes;

namespace SailorMoonEncyclopedia_Coursework.Windows
{
    public partial class RegisWindow : Window
    {
        public RegisWindow()
        {
            InitializeComponent();
        }

        private void RegBTN_Click(object sender, RoutedEventArgs e)
        {
            Users us = new Users(Convert.ToString(name.Text),
                     Convert.ToString(email.Text),
                     Convert.ToString(password.Text),
                     double.Parse(telephone.Text),
                     Convert.ToString("1"));

            us.Add(us);
            MessageBox.Show("Занесено в базу!");

            MainWindow ewe = new MainWindow();
            this.Close();
            ewe.Show();
        }
    }
}
