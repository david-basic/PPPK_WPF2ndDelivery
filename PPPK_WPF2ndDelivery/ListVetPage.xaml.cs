using PPPK_WPF2ndDelivery.Models;
using PPPK_WPF2ndDelivery.ViewModel;
using System.Windows;
using System.Windows.Controls;

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
            Frame.Navigate(new EditVetPage(VeterinarianViewModel)
            {
                Frame = Frame
            });
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvVeterinarians.SelectedItem != null)
            {
                Frame.Navigate(new EditVetPage(VeterinarianViewModel, LvVeterinarians.SelectedItem as Veterinarian)
                {
                    Frame = Frame
                });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvVeterinarians.SelectedItem != null)
            {
                VeterinarianViewModel.Veterinarians.Remove(LvVeterinarians.SelectedItem as Veterinarian);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationService.GoBack();
        }
    }
}
