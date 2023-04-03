using Kingsman.Windows.Staff;
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

namespace Kingsman.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            CmbGender.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGender.DisplayMemberPath = "GenderName";
            CmbGender.SelectedIndex = 0;
        }

        private void Reg(object sender, RoutedEventArgs e)
        {
            // валидация
            if (string.IsNullOrWhiteSpace(TbLastName.Text))
            {
                MessageBox.Show("Fill out the Last Name form");
                return;
            }

            if (string.IsNullOrWhiteSpace(TbFirstName.Text))
            {
                MessageBox.Show("Fill out the First Name form");
                return;
            }
            // добавление 
            DB.Client addClient = new DB.Client();
            addClient.Login = TbLogin.Text;
            addClient.Password = PbPassword.Password;
            addClient.Phone = TbPhone.Text;
            addClient.FirstName = TbFirstName.Text;
            addClient.LastName = TbLastName.Text;
            if (TbMiddleName.Text != string.Empty)
            {
                addClient.Patronymic = TbMiddleName.Text;
            }
            addClient.GenderCode = (CmbGender.SelectedItem as DB.Gender).Code;

            ClassHelper.EF.Context.Client.Add(addClient);

            // сохранение
            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("User has been added to the database");


        }
        private void Show(object sender, RoutedEventArgs e) { 
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }
    }
}
