using Microsoft.Win32;
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
    /// Логика взаимодействия для EditClientListWindow.xaml
    /// </summary>
    public partial class EditClientListWindow : Window
    {
        DB.Client editClient = null;

        private bool isEdit = false;
        public EditClientListWindow()
        {
            InitializeComponent();
            isEdit = false;
        }

        public EditClientListWindow(DB.Client client)
        {
            InitializeComponent();

            isEdit = true;

            editClient = client;

            // Заполнение типа услуги

            CmbGender.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGender.DisplayMemberPath = "Gender";


            // заполнение полей
            TbFirstName.Text = client.FirstName;
            TbLastName.Text = client.LastName;
            TbPatron.Text = client.Patronymic;
            TbPhone.Text = client.Phone;
            TbLogin.Text = client.Login;
            TbPassword.Text = client.Password;

            // заполнение типа услуги
            CmbGender.SelectedItem = ClassHelper.EF.Context.Gender.Where(i => i.Code == client.GenderCode).FirstOrDefault();

        }


        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {
            editClient.FirstName = TbFirstName.Text;
            editClient.LastName = TbLastName.Text;
            editClient.Patronymic = TbPatron.Text;
            editClient.Phone = TbPhone.Text;
            editClient.Login = TbLogin.Text;
            editClient.Password = TbPassword.Text;
            editClient.GenderCode = (CmbGender.SelectedItem as DB.Gender).Code;

            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Данные успешно сохранены");

            ClientsListWindow clientsListWindow = new ClientsListWindow();
            this.Close();
            clientsListWindow.Show();
            

        }
    }
}
