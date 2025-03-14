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
                    MedicineList.Add($"Id: {medicine.Id} Nome: {medicine.Name} Descrição: {medicine.Description} Tipo: {medicine.Type} Preço: {medicine.Price} Data de validade: {medicine.ExpirationDate}");
                }
            }
            return MedicineList;
        }
        public void MedicinesUpdate(int id, string Newname, string Newdescription, string Newtype, decimal Newprice, DateTime Newexpiration_date)
        {
            using (var db = new AppDbContext())
            {
                var medicine = db.Medicines.Find(id);
                if (medicine != null)
                {
                    medicine.Name = Newname;
                    medicine.Description = Newdescription;
                    medicine.Type = Newtype;
                    medicine.Price = Newprice;
                    medicine.ExpirationDate = Newexpiration_date;
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