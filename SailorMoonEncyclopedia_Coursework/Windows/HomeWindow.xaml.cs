using Microsoft.Win32;
using MongoDB.Driver;
using SailorMoonEncyclopedia_Coursework.DB;
using System;
using System.Linq;
using System.Windows;

namespace SailorMoonEncyclopedia_Coursework.Windows
{
    public partial class HomeWindow : Window
    {
        public static MongoClient client = new MongoClient();
        OpenFileDialog ofdImage = new OpenFileDialog();

        public HomeWindow()
        {
            InitializeComponent();
            var abase = client.GetDatabase("DB_SailorMoon");
            var b = abase.GetCollection<Character>("Character");
            listpers.ItemsSource = b.AsQueryable().ToList();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
