using PPPK_WPF2ndDelivery.Models;
using PPPK_WPF2ndDelivery.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_WPF2ndDelivery.Dal
{
    internal class SqlRepository : IRepository
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        #region Veterinarian
        public void AddVeterinarian(Veterinarian veterinarian)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Veterinarian.FirstName), veterinarian.FirstName);
                    cmd.Parameters.AddWithValue(nameof(Veterinarian.LastName), veterinarian.LastName);
                    cmd.Parameters.AddWithValue(nameof(Veterinarian.Email), veterinarian.Email);

                    cmd.Parameters.Add(new SqlParameter(nameof(Veterinarian.Picture), System.Data.SqlDbType.Binary, veterinarian.Picture.Length)
                    {
                        Value = veterinarian.Picture
                    });

                    SqlParameter id = new SqlParameter(nameof(veterinarian.IDVeterinarian), System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(id);
                    cmd.ExecuteNonQuery();

                    veterinarian.IDVeterinarian = (int)id.Value;
                }
            }
        }
        public void UpdateVeterinarian(Veterinarian veterinarian)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Veterinarian.FirstName), veterinarian.FirstName);
                    cmd.Parameters.AddWithValue(nameof(Veterinarian.LastName), veterinarian.LastName);
                    cmd.Parameters.AddWithValue(nameof(Veterinarian.Email), veterinarian.Email);

                    cmd.Parameters.Add(new SqlParameter(nameof(Veterinarian.Picture), System.Data.SqlDbType.Binary, veterinarian.Picture.Length)
                    {
                        Value = veterinarian.Picture
                    });

                    cmd.Parameters.AddWithValue(nameof(Veterinarian.IDVeterinarian), veterinarian.IDVeterinarian);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeleteVeterinarian(Veterinarian veterinarian)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Veterinarian.IDVeterinarian), veterinarian.IDVeterinarian);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public IList<Veterinarian> GetAllVeterinarians()
        {
            IList<Veterinarian> list = new List<Veterinarian>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(ReadVeterinarian(dr));
                        }
                    }

                }
            }

            return list;
        }
        public Veterinarian GetVeterinarian(int idVeterinarian)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Veterinarian.IDVeterinarian), idVeterinarian);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ReadVeterinarian(dr);
                        }
                    }

                }
            }
            throw new Exception("Wrong id");
        }
        private Veterinarian ReadVeterinarian(SqlDataReader dr)
            => new Veterinarian
            {
                IDVeterinarian = (int)dr[nameof(Veterinarian.IDVeterinarian)],
                FirstName = dr[nameof(Veterinarian.FirstName)].ToString(),
                LastName = dr[nameof(Veterinarian.LastName)].ToString(),
                Email = dr[nameof(Veterinarian.Email)].ToString(),
                Picture = ImageUtils.ByteArrayFromSqlDataReader(dr, 4)
            };
        #endregion

        #region PetOwner
        public void AddPetOwner(PetOwner petOwner)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(PetOwner.FirstName), petOwner.FirstName);
                    cmd.Parameters.AddWithValue(nameof(PetOwner.LastName), petOwner.LastName);
                    cmd.Parameters.AddWithValue(nameof(PetOwner.Email), petOwner.Email);

                    cmd.Parameters.Add(new SqlParameter(nameof(PetOwner.Picture), System.Data.SqlDbType.Binary, petOwner.Picture.Length)
                    {
                        Value = petOwner.Picture
                    });

                    SqlParameter id = new SqlParameter(nameof(petOwner.IDPetOwner), System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(id);
                    cmd.ExecuteNonQuery();

                    petOwner.IDPetOwner = (int)id.Value;
                }
            }
        }
        public void UpdatePetOwner(PetOwner petOwner)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(PetOwner.FirstName), petOwner.FirstName);
                    cmd.Parameters.AddWithValue(nameof(PetOwner.LastName), petOwner.LastName);
                    cmd.Parameters.AddWithValue(nameof(PetOwner.Email), petOwner.Email);

                    cmd.Parameters.Add(new SqlParameter(nameof(PetOwner.Picture), System.Data.SqlDbType.Binary, petOwner.Picture.Length)
                    {
                        Value = petOwner.Picture
                    });

                    cmd.Parameters.AddWithValue(nameof(PetOwner.IDPetOwner), petOwner.IDPetOwner);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeletePetOwner(PetOwner petOwner)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(PetOwner.IDPetOwner), petOwner.IDPetOwner);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public IList<PetOwner> GetAllPetOwners()
        {
            IList<PetOwner> list = new List<PetOwner>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(ReadPetOwner(dr));
                        }
                    }

                }
            }

            return list;
        }
        public PetOwner GetPetOwner(int idPetOwner)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(PetOwner.IDPetOwner), idPetOwner);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ReadPetOwner(dr);
                        }
                    }

                }
            }
            throw new Exception("Wrong id");
        }
        private PetOwner ReadPetOwner(SqlDataReader dr)
            => new PetOwner
            {
                IDPetOwner = (int)dr[nameof(PetOwner.IDPetOwner)],
                FirstName = dr[nameof(PetOwner.FirstName)].ToString(),
                LastName = dr[nameof(PetOwner.LastName)].ToString(),
                Email = dr[nameof(PetOwner.Email)].ToString(),
                Picture = ImageUtils.ByteArrayFromSqlDataReader(dr, 4)
            };
        #endregion

        #region Pet
        public void AddPet(Pet pet)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Pet.PetName), pet.PetName);
                    cmd.Parameters.AddWithValue(nameof(Pet.Species), pet.Species);
                    cmd.Parameters.AddWithValue(nameof(Pet.Age), pet.Age);

                    cmd.Parameters.Add(new SqlParameter(nameof(Pet.Picture), System.Data.SqlDbType.Binary, pet.Picture.Length)
                    {
                        Value = pet.Picture
                    });

                    cmd.Parameters.AddWithValue(nameof(Pet.PetOwnerID), pet.PetOwnerID);
                    cmd.Parameters.AddWithValue(nameof(Pet.VeterinarianID), pet.VeterinarianID);

                    SqlParameter id = new SqlParameter(nameof(pet.IDPet), System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(id);
                    cmd.ExecuteNonQuery();

                    pet.IDPet = (int)id.Value;
                }
            }
        }
        public void UpdatePet(Pet pet)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Pet.PetName), pet.PetName);
                    cmd.Parameters.AddWithValue(nameof(Pet.Species), pet.Species);
                    cmd.Parameters.AddWithValue(nameof(Pet.Age), pet.Age);

                    cmd.Parameters.Add(new SqlParameter(nameof(Pet.Picture), System.Data.SqlDbType.Binary, pet.Picture.Length)
                    {
                        Value = pet.Picture
                    });

                    cmd.Parameters.AddWithValue(nameof(Pet.PetOwnerID), pet.PetOwnerID);
                    cmd.Parameters.AddWithValue(nameof(Pet.VeterinarianID), pet.VeterinarianID);

                    cmd.Parameters.AddWithValue(nameof(Pet.IDPet), pet.IDPet);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void DeletePet(Pet pet)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(pet.IDPet), pet.IDPet);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public IList<Pet> GetAllPets()
        {
            IList<Pet> list = new List<Pet>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(ReadPet(dr));
                        }
                    }

                }
            }

            return list;
        }
        public Pet GetPet(int idPet)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Pet.IDPet), idPet);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ReadPet(dr);
                        }
                    }

                }
            }
            throw new Exception("Wrong id");
        }
        private Pet ReadPet(SqlDataReader dr)
            => new Pet
            {
                IDPet = (int)dr[nameof(Pet.IDPet)],
                PetName = dr[nameof(Pet.PetName)].ToString(),
                Species = dr[nameof(Pet.Species)].ToString(),
                Age = (int)dr[nameof(Pet.Age)],
                Picture = ImageUtils.ByteArrayFromSqlDataReader(dr, 4),
                PetOwnerID = (int)dr[nameof(Pet.PetOwnerID)],
                VeterinarianID = (int)dr[nameof(Pet.VeterinarianID)]
            };
        #endregion
    }
}
