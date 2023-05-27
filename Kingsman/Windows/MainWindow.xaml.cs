using Kingsman.Windows;
using Kingsman.Windows.Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
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


namespace Kingsman
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
           
        }

        private void Show(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Заходит как-то скелет в бар. Заказывает пиво и швабру");
            //List<DB.Staff> db = new List<DB.Staff>;
            var userAuth = ClassHelper.EF.Context.Staff.ToList().Where(i => i.Login == TbLogin.Text && i.Password == TbPassword.Text).
                //поменять с textbox на passwordbox
            FirstOrDefault();

            
            if (userAuth != null)
            {
                //переход на главное окно
                FeaturesWindow featuresWindow = new FeaturesWindow();
                featuresWindow.Show();
                this.Close();
            }

            else
            {
                MessageBox.Show("There is no such user in database", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //проверка на наличие пользователя
           
        }

        private void Reg(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }
    }
}
