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
    /// Логика взаимодействия для FeaturesWindow.xaml
    /// </summary>
    public partial class FeaturesWindow : Window
    {
        public FeaturesWindow()
        {
            InitializeComponent();
        }

        private void StaffButton_Click(object sender, RoutedEventArgs e)
        {
            StaffListWindow staffListWindow = new StaffListWindow();
            staffListWindow.Show();
        }

        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            ClientsListWindow clientsListWindow = new ClientsListWindow();
            clientsListWindow.Show();
        }

        private void ServiceButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceListWindow serviceListWindow = new ServiceListWindow();
            serviceListWindow.Show();
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
        }
    }
}
