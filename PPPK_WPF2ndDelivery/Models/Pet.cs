using PPPK_WPF2ndDelivery.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PPPK_WPF2ndDelivery.Models
{
    public class Pet
    {
        /*
            IDPet int primary key identity,
            PetName nvarchar(20) not null,
            Species nvarchar(50) not null,
            Age int not null,
            Picture varbinary(max) null,
            PetOwnerID int foreign key references PetOwner(IDPetOwner) not null,
            VeterinarianID int foreign key references Veterinarian(IDVeterinarian) not null
         */
        public int IDPet { get; set; }
        public string PetName { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public byte[] Picture { get; set; }
        public int PetOwnerID { get; set; }
        public int VeterinarianID { get; set; }

        public BitmapImage Image // ovo nam je samo da mozemo dobiti bitmap image iz byte arraya koji je spremljen u entitetu Picture, jer je byte[] isto u bazi 
        {
            get => ImageUtils.ByteArrayToBitmapImage(Picture);
        }
    }
}
