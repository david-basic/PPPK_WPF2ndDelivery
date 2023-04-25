using PPPK_WPF2ndDelivery.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PPPK_WPF2ndDelivery
{
    public class FramedPage : Page
    {
        public VeterinarianViewModel VeterinarianViewModel { get; }
        public PetOwnerViewModel PetOwnerViewModel { get; }
        public PetViewModel PetViewModel { get; }
        public MainPageViewModel MainPageViewModel { get;  }
        public Frame Frame { get; set; }

        public FramedPage(VeterinarianViewModel veterinarianViewModel)
        {
            VeterinarianViewModel = veterinarianViewModel;
        }
        public FramedPage(PetOwnerViewModel petOwnerViewModel)
        {
            PetOwnerViewModel = petOwnerViewModel;
        }
        public FramedPage(PetViewModel petViewModel)
        {
            PetViewModel = petViewModel;
        }
        public FramedPage(MainPageViewModel mainPageViewModel)
        {
            MainPageViewModel = mainPageViewModel;
        }
    }
}
