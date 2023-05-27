using Kingsman.DB;
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
    /// Логика взаимодействия для ClientsListWindow.xaml
    /// </summary>
    public partial class ClientsListWindow : Window
    {
        public ClientsListWindow()
        {
            InitializeComponent();
            GetListClient();
        }

        private void GetListClient()
        {
            DgClient.ItemsSource = ClassHelper.EF.Context.Client.ToList();
        }


        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            ServiceListWindow serviceListWindow = new ServiceListWindow();
            this.Close();
            serviceListWindow.Show();
        }

        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {

            if (DgClient.SelectedItem == null)
            {
                return;
            }
            var client = DgClient.SelectedItem as DB.Client; // получаем выбранную запись
            EditClientListWindow editClientListWindow = new EditClientListWindow(client);
            editClientListWindow.ShowDialog();

            GetListClient();
    }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.Show();
        }
    }
}
