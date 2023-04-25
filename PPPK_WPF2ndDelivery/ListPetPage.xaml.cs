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
    /// Interaction logic for ListPetPage.xaml
    /// </summary>
    public partial class ListPetPage : FramedPage
    {
        public ListPetPage(PetViewModel petViewModel) : base(petViewModel)
        {
            InitializeComponent();
            LvPets.ItemsSource = petViewModel.Pets;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new EditPetPage(PetViewModel)
            {
                Frame = Frame
            });
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvPets.SelectedItem != null)
            {
                Frame.Navigate(new EditPetPage(PetViewModel, LvPets.SelectedItem as Pet)
                {
                    Frame = Frame
                });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvPets.SelectedItem != null)
            {
                PetViewModel.Pets.Remove(LvPets.SelectedItem as Pet);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationService.GoBack();
        }
    }
}
