using Microsoft.Win32;
using PPPK_WPF2ndDelivery.Models;
using PPPK_WPF2ndDelivery.Utils;
using PPPK_WPF2ndDelivery.ViewModel;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PPPK_WPF2ndDelivery
{
    /// <summary>
    /// Interaction logic for EditVetPage.xaml
    /// </summary>
    public partial class EditVetPage : FramedPage
    {
        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
        private readonly Veterinarian _veterinarian;
        public EditVetPage(VeterinarianViewModel veterinarianViewModel, Veterinarian veterinarian = null) : base(veterinarianViewModel)
        {
            InitializeComponent();
            _veterinarian = veterinarian ?? new Veterinarian();
            DataContext = veterinarian;
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
                _veterinarian.Email = TbEmail.Text.Trim();
                _veterinarian.FirstName = TbFirstName.Text.Trim();
                _veterinarian.LastName = TbLastName.Text.Trim();
                _veterinarian.Picture = ImageUtils.BitmapImageToByteArray(Picture.Source as BitmapImage);

                if (_veterinarian.IDVeterinarian == 0)
                {
                    VeterinarianViewModel.Veterinarians.Add(_veterinarian);
                }
                else
                {
                    VeterinarianViewModel.Update(_veterinarian);
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
