using MongoDB.Driver;
using SailorMoonEncyclopedia_Coursework.DB;
using System.Linq;
using System.Windows;

namespace SailorMoonEncyclopedia_Coursework.Windows
{
    public partial class AuthWindow : Window
    {
        public static MongoClient client = new MongoClient();
        public AuthWindow()
        {
            InitializeComponent();
        }

        public bool Auth(string nickname, string password)
        {
            var abase = client.GetDatabase("DB_SailorMoon");
            var b = abase.GetCollection<Users>("users");
            var listPerson = b.Find(Resorts => Resorts._email == nickname && Resorts._password == password).ToList().FirstOrDefault();
            try
            {
                if (string.IsNullOrEmpty(nickname) || string.IsNullOrEmpty(password) || listPerson == null)
                {
                    MessageBox.Show("Введите логин и пароль или введены неправильные данные");
                    return false;
                }
                else if (listPerson._email == nickname && listPerson._password == password && listPerson._role == "1")
                {
                    MessageBox.Show($"Добро пожаловать администратор: {listPerson._name} ");
                    AdminWindow qwe = new AdminWindow();
                    this.Close();
                    qwe.Show();
                }

                else if (listPerson._email == nickname && listPerson._password == password && listPerson._role == "2")
                {
                    MessageBox.Show($"Добро пожаловать пользователь:  {listPerson._name}");
                    HomeWindow qwe = new HomeWindow();
                    this.Close();
                    qwe.Show();
                }
            }
            catch
            {
                MessageBox.Show("Введите логин и пароль или введены неправильные данные");
            }

            return true;
        }

        private void Sign_Up_Click(object sender, RoutedEventArgs e)
        {
            Auth(email.Text, password.Text);
        }
    }
}
