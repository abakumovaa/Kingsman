﻿using Microsoft.Win32;
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
    /// Логика взаимодействия для AddServiceWindow.xaml
    /// </summary>
    public partial class AddServiceWindow : Window
    {

        private string pathImage = null;
        public AddServiceWindow()
        {
            InitializeComponent();

            CmbTypeService.ItemsSource = ClassHelper.EF.Context.Category.ToList(); //?????????????????????????????????
            CmbTypeService.DisplayMemberPath = "Title";
            CmbTypeService.SelectedIndex = 0;
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgImageService.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                pathImage = openFileDialog.FileName;
            }
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {

            //валидация 

            // добавление услуги
            DB.Service newService = new DB.Service();

            newService.Cost = Convert.ToDecimal(TbPriceService.Text);
            newService.Title = TbNameService.Text;
            newService.Description = TbDiscService.Text;
            newService.CategoryID = (CmbTypeService.SelectedItem as DB.Category).ID;
            if (pathImage != null)
            {
                newService.ImagePath = pathImage;
            }

            ClassHelper.EF.Context.Service.Add(newService);
            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Услуга добавлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }
    }
}