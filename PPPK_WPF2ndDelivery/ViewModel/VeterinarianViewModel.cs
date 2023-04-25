using PPPK_WPF2ndDelivery.Dal;
using PPPK_WPF2ndDelivery.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_WPF2ndDelivery.ViewModel
{
    public class VeterinarianViewModel
    {
        public ObservableCollection<Veterinarian> Veterinarians { get; } // readonly observable

        public VeterinarianViewModel()
        {
            Veterinarians = new ObservableCollection<Veterinarian>(RepositoryFactory.GetRepository().GetAllVeterinarians());
            Veterinarians.CollectionChanged += Veterinarians_CollectionChanged;
        }

        private void Veterinarians_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().AddVeterinarian(Veterinarians[e.NewStartingIndex]);
                    // u kolekciji veterinara na nekom novom indeksu postoji dodani novi veterinar
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeleteVeterinarian(e.OldItems.OfType<Veterinarian>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdateVeterinarian(e.NewItems.OfType<Veterinarian>().ToList()[0]);
                    break;
            }
        }

        public void Update(Veterinarian veterinarian) => Veterinarians[Veterinarians.IndexOf(veterinarian)] = veterinarian;
        // postavi veterinara na njegovo mjesto da bi se na listi dogodio event, jer inace update evente ne prepoznaje jer se događaju na njoj a ne iz vana
    }
}
