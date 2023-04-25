using PPPK_WPF2ndDelivery.Models;
using PPPK_WPF2ndDelivery.ViewModel;
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
    /// Interaction logic for ListPetOwnerPage.xaml
    /// </summary>
    public partial class ListPetOwnerPage : FramedPage
    {
        public ListPetOwnerPage(PetOwnerViewModel petOwnerViewModel) : base(petOwnerViewModel)
        {
            InitializeComponent();
            LvPetOwners.ItemsSource = petOwnerViewModel.PetOwners;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new EditPetOwnerPage(PetOwnerViewModel)
            {
                Frame = Frame
            });
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvPetOwners.SelectedItem != null)
            {
                Frame.Navigate(new EditPetOwnerPage(PetOwnerViewModel, LvPetOwners.SelectedItem as PetOwner)
                {
                    Frame = Frame
                });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvPetOwners.SelectedItem != null)
            {
                PetOwnerViewModel.PetOwners.Remove(LvPetOwners.SelectedItem as PetOwner);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationService.GoBack();
        }
    }
}
