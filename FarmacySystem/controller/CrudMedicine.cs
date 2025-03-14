using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmacySystem.model;
using FarmacySystem.data;

namespace FarmacySystem.controller
{
    public class CrudMedicine
    {
        public void InsertMedicine(int idM, string nameM, string descriptionM, string typeM, decimal priceM, DateTime expiration_dateM)
        {
            using (var db = new AppDbContext())
            {
                db.Medicines.Add(new Medicine { Id = idM, Name = nameM, Description = descriptionM, Type = typeM, Price = priceM, ExpirationDate = expiration_dateM });
                db.SaveChanges();
            }
        }
        public List<string> ListMedicines()
        {
            List<string> MedicineList = new List<string>();

            using (var db = new AppDbContext())
            {
                var medicines = db.Medicines.ToList();
                foreach (var medicine in medicines)
                {
                    MedicineList.Add($"{medicine.Id}{medicine.Name}{medicine.Description}{medicine.Type}{medicine.Price}{medicine.ExpirationDate}");
                }
            }
            return MedicineList;
        }
        public void MedicinesUpdate(int id, string? Newname = null, string? Newdescription = null, string? Newtype = null, decimal? Newprice = null, DateTime? Newexpiration_date = null)
        {
            using (var db = new AppDbContext())
            {
                var medicine = db.Medicines.Find(id);
                if (medicine != null)
                {
                    medicine.Name = Newname ?? medicine.Name;
                    medicine.Description = Newdescription ?? medicine.Description;
                    medicine.Type = Newtype ?? medicine.Type;
                    medicine.Price = Newprice ?? medicine.Price;
                    medicine.ExpirationDate = Newexpiration_date ?? medicine.ExpirationDate;
                    db.SaveChanges();
                    System.Console.WriteLine("Medicamento atualizado com sucesso");
                }
                else
                {
                    System.Console.WriteLine("Medicamento não encontrado");
                }
            }
        }
        public void MedicinesDelete(int id)
        {
            using (var db = new AppDbContext())
            {
                var medicine = db.Medicines.Find(id);
                if (medicine != null)
                {
                    db.Medicines.Remove(medicine);
                    db.SaveChanges();
                    System.Console.WriteLine("Medicamento deletado com sucesso");
                }
                else
                {
                    System.Console.WriteLine("Medicamento não encontrado");
                }
            }
        }
    }
}