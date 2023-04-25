﻿using PPPK_WPF2ndDelivery.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PPPK_WPF2ndDelivery
{
    /// <summary>
    /// Interaction logic for ListVetPage.xaml
    /// </summary>
    public partial class ListVetPage : FramedPage
    {
        public ListVetPage(VeterinarianViewModel veterinarianViewModel) : base(veterinarianViewModel)
        {
            InitializeComponent();
            LvVeterinarians.ItemsSource = veterinarianViewModel.Veterinarians;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("ADD");
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("EDIT");
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("DELETE");
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationService.GoBack();
        }
    }
}
