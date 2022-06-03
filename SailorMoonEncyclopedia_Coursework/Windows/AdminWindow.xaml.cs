using Microsoft.Win32;
using MongoDB.Driver;
using SailorMoonEncyclopedia_Coursework.DB;
using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class AdminWindow : Window
    {
        public static MongoClient client = new MongoClient();
        OpenFileDialog ofdImage = new OpenFileDialog();

        public AdminWindow()
        {
            InitializeComponent();
            var abase = client.GetDatabase("DB_SailorMoon");
            var b = abase.GetCollection<Character>("Character");
            listpers.ItemsSource = b.AsQueryable().ToList();
        }

        private void BTNImage_Click(object sender, RoutedEventArgs e)
        {
            ofdImage.Filter = "Image files|*.bmp;*.jpg;*.png|All files|*.*";
            ofdImage.FilterIndex = 1;
            if (ofdImage.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(ofdImage.FileName);
                image.EndInit();
                images.Source = image;
            }
        }

        private void BTNDel_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage image = new BitmapImage();
            image.Freeze();
            images.Source = image;
        }

        private void BTNCreate_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" || Description.Text == "" || Capabilities.Text == "")
            {
                MessageBox.Show("Введите ваши данные!");
            }
            else
            {
                Character character = new Character(Convert.ToString(name.Text),
                                     Convert.ToString(ShortDescription.Text),
                                     Convert.ToString(Description.Text),
                                     Convert.ToString(Capabilities.Text),
                                     File.ReadAllBytes(ofdImage.FileName));
                character.Add(character);
                MessageBox.Show("Занесено в базу!");
                AdminWindow admin = new AdminWindow();
                this.Close();
                admin.Show();
            }
        }
    }
}
