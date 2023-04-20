using PPPK_WPF2ndDelivery.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PPPK_WPF2ndDelivery.Models
{
    public class PetOwner
    {
        /*
         	IDPetOwner int primary key identity,
            FirstName nvarchar(20) not null,
            LastName nvarchar(20) not null,
            Email nvarchar(30) not null,
            Picture varbinary(max) null
         */
        public int IDPetOwner { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Picture { get; set; }

        public BitmapImage Image // ovo nam je samo da mozemo dobiti bitmap image iz byte arraya koji je spremljen u entitetu Picture, jer je byte[] isto u bazi 
        {
            get => ImageUtils.ByteArrayToBitmapImage(Picture);
        }
    }
}
