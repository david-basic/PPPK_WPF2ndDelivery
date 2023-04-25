using Microsoft.Win32;
using PPPK_WPF2ndDelivery.Models;
using PPPK_WPF2ndDelivery.Utils;
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
    /// Interaction logic for EditPetOwnerPage.xaml
    /// </summary>
    public partial class EditPetOwnerPage : FramedPage
    {
        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
        private readonly PetOwner _petOwner;
        public EditPetOwnerPage(PetOwnerViewModel petOwnerViewModel, PetOwner petOwner = null) : base(petOwnerViewModel)
        {
            InitializeComponent();
            _petOwner = petOwner ?? new PetOwner();
            DataContext = petOwner;
        }

        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = Filter
            };

            if (dialog.ShowDialog() == true)
            {
                Picture.Source = new BitmapImage(
                    new Uri(dialog.FileName)
                    );
            }
        }

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                _petOwner.Email = TbEmail.Text.Trim();
                _petOwner.FirstName = TbFirstName.Text.Trim();
                _petOwner.LastName = TbLastName.Text.Trim();
                _petOwner.Picture = ImageUtils.BitmapImageToByteArray(Picture.Source as BitmapImage);

                if (_petOwner.IDPetOwner == 0)
                {
                    PetOwnerViewModel.PetOwners.Add(_petOwner);
                }
                else
                {
                    PetOwnerViewModel.Update(_petOwner);
                }

                Frame.NavigationService.GoBack();
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationService.GoBack();
        }

        private bool FormValid()
        {
            bool valid = true;

            GridContainer.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim())
                    || "Email".Equals(e.Tag) && !ValidationUtils.isValidEmail(e.Text.Trim()))
                {
                    e.Background = Brushes.LightCoral;
                    valid = false;
                }
                else
                {
                    e.Background = Brushes.White;
                }
            });

            if (Picture.Source == null)
            {
                PictureBorder.BorderBrush = Brushes.LightCoral;
                valid = false;
            }
            else
            {
                PictureBorder.BorderBrush = Brushes.White;
            }

            return valid;
        }
    }
}
