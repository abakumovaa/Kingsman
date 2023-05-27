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
    /// Логика взаимодействия для StaffListWindow.xaml
    /// </summary>
    public partial class StaffListWindow : Window
    {
        public StaffListWindow()
        {
            InitializeComponent();
            GetListStaff();
        }

        private void GetListStaff()
        {
            DgStaff.ItemsSource = ClassHelper.EF.Context.Staff.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            ServiceListWindow serviceListWindow = new ServiceListWindow();
            this.Close();
            serviceListWindow.Show();
        }

        private void BtnEditStaff_Click(object sender, RoutedEventArgs e)
        {

            if (DgStaff.SelectedItem == null)
            {
                return;
            }
            var staff = DgStaff.SelectedItem as DB.Staff; // получаем выбранную запись
            EditStaffListWindow editStaffListWindow = new EditStaffListWindow(staff);
            editStaffListWindow.ShowDialog();

            GetListStaff();
        }

        private void BtnAddStaff_Click(object sender, RoutedEventArgs e)
        {
            AddStaffListWindow addStaffListWindow = new AddStaffListWindow();
            this.Close();
            addStaffListWindow.Show();
        }

    }
}
