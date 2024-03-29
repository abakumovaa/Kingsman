﻿using System;
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

using Kingsman.ClassHelper;

namespace Kingsman.Windows.Staff
{
    /// <summary>
    /// Логика взаимодействия для ServiceListWindow.xaml
    /// </summary>
    public partial class ServiceListWindow : Window
    {
        public ServiceListWindow()
        {
            InitializeComponent();
            GetListService();
        }

        private void GetListService()
        {
            LvService.ItemsSource = ClassHelper.EF.Context.Service.ToList();
        }

        private void LvService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            AddServiceWindow addServiceWindow = new AddServiceWindow();
            addServiceWindow.ShowDialog();

            // Обновляем лист
            GetListService();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

            if (LvService.SelectedItem == null)
            {
                return;
            }
            var service = LvService.SelectedItem as DB.Service; // получаем выбранную запись
            EditServiceWindow editServiceWindow = new EditServiceWindow(service);
            editServiceWindow.ShowDialog();

            GetListService();
        }

        // добавление в корзину
        private void BtnAddToCart_Click(object sender, RoutedEventArgs e)
        {
 
            if (LvService.SelectedItem == null)
            {
                return;
            }
            var service = LvService.SelectedItem as DB.Service; // получаем выбранную запись

            CartServiceClass.ServiceCart.Add(service);

            MessageBox.Show($"Услуга {service.Title} добавлена в корзину!");
        }

        private void BtnGoToCart_Click(object sender, RoutedEventArgs e)
        {
            CartWindow cartWindow = new CartWindow();
            this.Close();
            cartWindow.ShowDialog();

        }

        private void BtnClientsList_Click(object sender, RoutedEventArgs e)
        {
            ClientsListWindow clientsListWindow = new ClientsListWindow();
            this.Close();
            clientsListWindow.ShowDialog();
        }

        private void BtnStaffList_Click(object sender, RoutedEventArgs e)
        {
            StaffListWindow staffListWindow = new StaffListWindow();
            this.Close();
            staffListWindow.ShowDialog();
        }
    }
}
