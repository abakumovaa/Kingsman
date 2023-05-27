using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();

            CmbGender.ItemsSource = ClassHelper.EF.Context.Gender.ToList(); //?????????????????????????????????
            CmbGender.DisplayMemberPath = "Code";
            CmbGender.SelectedIndex = 0;
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {

            //валидация 

            // добавление услуги
            DB.Client newClient = new DB.Client();

            newClient.FirstName = TbFirstName.Text;
            newClient.LastName = TbLastName.Text;
            newClient.Patronymic = TbPatron.Text;
            newClient.Phone = TbPhone.Text;
            newClient.GenderCode = (CmbGender.SelectedItem as DB.Gender).Code;
            newClient.Login = TbLogin.Text;
            newClient.Password = TbPassword.Text;
            newClient.Birthday = DpBday.SelectedDate;
            newClient.RegistrationDate = System.DateTime.UtcNow;
            //if (pathImage != null)
            //{
            //    newService.ImagePath = pathImage;
            //}

            ClassHelper.EF.Context.Client.Add(newClient);
            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Клиент добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }
    }
}
