using PPPK_WPF2ndDelivery.Dal;
using PPPK_WPF2ndDelivery.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace PPPK_WPF2ndDelivery.ViewModel
{
    public class VeterinarianViewModel
    {
        public ObservableCollection<Veterinarian> Veterinarians { get; }
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
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeleteVeterinarian(e.OldItems.OfType<Veterinarian>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdateVeterinarian(e.NewItems.OfType<Veterinarian>().ToList()[0]);
                    break;
            }
        }

        internal void Update(Veterinarian veterinarian) => Veterinarians[Veterinarians.IndexOf(veterinarian)] = veterinarian;
    }
}
