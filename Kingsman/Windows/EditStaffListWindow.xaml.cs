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
    /// Логика взаимодействия для EditStaffListWindow.xaml
    /// </summary>
    public partial class EditStaffListWindow : Window
    {
        DB.Staff editStaff = null;

        private bool isEdit = false;
        public EditStaffListWindow()
        {
            InitializeComponent();
            isEdit = false;
        }

        public EditStaffListWindow(DB.Staff staff)
        {
            InitializeComponent();

            isEdit = true;

            editStaff = staff;

            // Заполнение типа услуги

            CmbGender.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGender.DisplayMemberPath = "Code";

            CmbPosition.ItemsSource = ClassHelper.EF.Context.Position.ToList();
            CmbPosition.DisplayMemberPath = "Title";


            // заполнение полей
            TbFirstName.Text = staff.FirstName;
            TbLastName.Text = staff.SecondName;
            TbPatron.Text = staff.Patronymic;
            TbPhone.Text = staff.Phone;
            TbLogin.Text = staff.Login;
            TbPassword.Text = staff.Password;

            CmbGender.SelectedItem = ClassHelper.EF.Context.Gender.Where(i => i.Code == staff.GenderCode).FirstOrDefault();
            CmbPosition.SelectedItem = ClassHelper.EF.Context.Position.Where(i => i.ID == staff.PositionID).FirstOrDefault();

        }


        private void BtnEditStaff_Click(object sender, RoutedEventArgs e)
        {
            editStaff.FirstName = TbFirstName.Text;
            editStaff.SecondName = TbLastName.Text;
            editStaff.Patronymic = TbPatron.Text;
            editStaff.Phone = TbPhone.Text;
            editStaff.Login = TbLogin.Text;
            editStaff.Password = TbPassword.Text;
            editStaff.GenderCode = (CmbGender.SelectedItem as DB.Gender).Code;
            editStaff.PositionID = (CmbPosition.SelectedItem as DB.Position).ID;

            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Данные успешно сохранены");

            StaffListWindow staffListWindow = new StaffListWindow();
            this.Close();
            staffListWindow.Show();


        }
    }
}