﻿using SailorMoonEncyclopedia_Coursework.Windows;
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

namespace SailorMoonEncyclopedia_Coursework
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow hmw = new AuthWindow();
            hmw.Show();
            this.Close();
        }

        private void RegisButton_Click(object sender, RoutedEventArgs e)
        {
            RegisWindow regis = new RegisWindow();
            regis.Show();
            this.Close();
        }
    }
}
