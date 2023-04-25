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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : FramedPage
    {
        public MainPage(MainPageViewModel mainPageViewModel) : base(mainPageViewModel)
        {
            InitializeComponent();
            LbTitle.Content = mainPageViewModel.Title;
        }

        private void BtnOwners_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ListPetOwnerPage(new PetOwnerViewModel()) { Frame = Frame });
        }

        private void BtnPets_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ListPetPage(new PetViewModel()) { Frame = Frame });
        }

        private void BtnVets_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ListVetPage(new VeterinarianViewModel()) { Frame = Frame });
        }
    }
}
