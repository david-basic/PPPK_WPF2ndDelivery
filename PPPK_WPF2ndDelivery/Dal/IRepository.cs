using PPPK_WPF2ndDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_WPF2ndDelivery.Dal
{
    public interface IRepository
    {
        void AddVeterinarian(Veterinarian veterinarian);
        void UpdateVeterinarian(Veterinarian veterinarian);
        void DeleteVeterinarian(Veterinarian veterinarian);
        IList<Veterinarian> GetAllVeterinarians();
        Veterinarian GetVeterinarian(int idVeterinarian);

        void AddPetOwner(PetOwner petOwner);
        void UpdatePetOwner(PetOwner petOwner);
        void DeletePetOwner(PetOwner petOwner);
        IList<PetOwner> GetAllPetOwners();
        PetOwner GetPetOwner(int idPetOwner);

        void AddPet(Pet pet);
        void UpdatePet(Pet pet);
        void DeletePet(Pet pet);
        IList<Pet> GetAllPets();
        Pet GetPet(int idPet);
    }
}
