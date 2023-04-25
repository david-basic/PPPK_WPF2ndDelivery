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
    public class PetViewModel
    {
        public ObservableCollection<Pet> Pets { get; } // readonly observable

        public PetViewModel()
        {
            Pets = new ObservableCollection<Pet>(RepositoryFactory.GetRepository().GetAllPets());
            Pets.CollectionChanged += Pets_CollectionChanged;
        }

        private void Pets_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().AddPet(Pets[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeletePet(e.OldItems.OfType<Pet>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdatePet(e.NewItems.OfType<Pet>().ToList()[0]);
                    break;
            }
        }

        public void Update(Pet pet) => Pets[Pets.IndexOf(pet)] = pet;
    }
}
