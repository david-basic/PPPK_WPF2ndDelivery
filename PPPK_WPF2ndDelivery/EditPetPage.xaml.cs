using Microsoft.Win32;
using PPPK_WPF2ndDelivery.Dal;
using PPPK_WPF2ndDelivery.Models;
using PPPK_WPF2ndDelivery.Utils;
using PPPK_WPF2ndDelivery.ViewModel;
using System;
using System.Collections;
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
    /// Interaction logic for EditPetPage.xaml
    /// </summary>
    public partial class EditPetPage : FramedPage
    {
        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
        private readonly Pet _pet;
        private IList<Veterinarian> vets = RepositoryFactory.GetRepository().GetAllVeterinarians();
        private IList<PetOwner> owners = RepositoryFactory.GetRepository().GetAllPetOwners();
        public EditPetPage(PetViewModel petViewModel, Pet pet = null) : base(petViewModel)
        {
            InitializeComponent();
            _pet = pet ?? new Pet();
            DataContext = pet;
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
                _pet.PetName = TbPetName.Text.Trim();
                _pet.Species = TbSpecies.Text.Trim();
                _pet.Age = int.Parse(TbAge.Text.Trim());
                _pet.VeterinarianID = int.Parse(TbVeterinarian.Text.Trim());
                _pet.PetOwnerID = int.Parse(TbPetOwner.Text.Trim());
                _pet.Picture = ImageUtils.BitmapImageToByteArray(Picture.Source as BitmapImage);

                if (_pet.IDPet == 0)
                {
                    PetViewModel.Pets.Add(_pet);
                }
                else
                {
                    PetViewModel.Update(_pet);
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
                    || "Int".Equals(e.Tag) && !int.TryParse(e.Text.Trim(), out int result))
                {
                    e.Background = Brushes.LightCoral;
                    valid = false;
                }
                else
                {
                    if (e.Name == "TbVeterinarian")
                    {
                        foreach (var vet in vets)
                        {
                            if (vet.IDVeterinarian == int.Parse(TbVeterinarian.Text.Trim()))
                            {
                                valid = true;
                                e.Background = Brushes.White;
                                break;
                            }
                            else
                            {
                                valid = false;
                                e.Background = Brushes.LightCoral;
                            }
                        }
                    }

                    if (e.Name == "TbPetOwner")
                    {
                        foreach (var o in owners)
                        {
                            if (o.IDPetOwner == int.Parse(TbPetOwner.Text.Trim()))
                            {
                                valid = true;
                                e.Background = Brushes.White;
                                break;
                            }
                            else
                            {
                                valid = false;
                                e.Background = Brushes.LightCoral;
                            }
                        }
                    }
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
