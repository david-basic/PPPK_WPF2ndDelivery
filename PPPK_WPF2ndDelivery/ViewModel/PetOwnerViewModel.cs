using PPPK_WPF2ndDelivery.Dal;
using PPPK_WPF2ndDelivery.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace PPPK_WPF2ndDelivery.ViewModel
{
    public class PetOwnerViewModel
    {
        public ObservableCollection<PetOwner> PetOwners { get; } // readonly observable

        public PetOwnerViewModel()
        {
            PetOwners = new ObservableCollection<PetOwner>(RepositoryFactory.GetRepository().GetAllPetOwners());
            PetOwners.CollectionChanged += PetOwners_CollectionChanged;
        }

        private void PetOwners_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().AddPetOwner(PetOwners[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeletePetOwner(e.OldItems.OfType<PetOwner>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdatePetOwner(e.NewItems.OfType<PetOwner>().ToList()[0]);
                    break;
            }
        }

        public void Update(PetOwner petOwner) => PetOwners[PetOwners.IndexOf(petOwner)] = petOwner;
    }
}
