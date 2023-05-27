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
    /// Логика взаимодействия для AddStaffListWindow.xaml
    /// </summary>
    public partial class AddStaffListWindow : Window
    {
        public AddStaffListWindow()
        {
            InitializeComponent();

            CmbGender.ItemsSource = ClassHelper.EF.Context.Gender.ToList(); //?????????????????????????????????
            CmbGender.DisplayMemberPath = "Code";
            CmbGender.SelectedIndex = 0;


            CmbPosition.ItemsSource = ClassHelper.EF.Context.Position.ToList(); //?????????????????????????????????
            CmbPosition.DisplayMemberPath = "Title";
            CmbPosition.SelectedIndex = 0;
        }

        private void BtnAddStaff_Click(object sender, RoutedEventArgs e)
        {

            //валидация 

            // добавление услуги
            DB.Staff newStaff = new DB.Staff();

            newStaff.FirstName = TbFirstName.Text;
            newStaff.SecondName = TbLastName.Text;
            newStaff.Patronymic = TbPatron.Text;
            newStaff.Phone = TbPhone.Text;
            newStaff.GenderCode = (CmbGender.SelectedItem as DB.Gender).Code;
            newStaff.Login = TbLogin.Text;
            newStaff.Password = TbPassword.Text;
            newStaff.PositionID = (CmbPosition.SelectedItem as DB.Position).ID;
            //if (pathImage != null)
            //{
            //    newService.ImagePath = pathImage;
            //}

            ClassHelper.EF.Context.Staff.Add(newStaff);
            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Сотрудник добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            StaffListWindow staffListWindow = new StaffListWindow();
            this.Close();
            staffListWindow.Show();
        }
    }
}

