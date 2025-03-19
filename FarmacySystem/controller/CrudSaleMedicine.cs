using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmacySystem.model;
using FarmacySystem.data;

namespace FarmacySystem.controller
{
    public class CrudSaleMedicine
    {
        public void InsertSaleMedicine(int stockid, int medicineId, int quantity)
        {
            using (var db = new AppDbContext())
            {
                db.SaleMedicines.Add(new SaleMedicine { StockId = stockid, MedicineId = medicineId, Quantity = quantity });
                db.SaveChanges();
            }
        }
        public List<string> ListSaleMedicine()
        {
            List<string> SaleMedicinetList = new List<string>();

            using (var db = new AppDbContext())
            {
                var saleMedicine = db.SaleMedicines.ToList();
                foreach (var saleMedicines in saleMedicine)
                {
                    SaleMedicinetList.Add($"{saleMedicines.Id}{saleMedicines.StockId}{saleMedicines.MedicineId}{saleMedicines.Quantity}");
                }
            }
            return SaleMedicinetList;
        }
        public void SaleMedicineUpdate(int id, int? stockid = null, int? medicineId = null, int? quantity = null)
        {
            using (var db = new AppDbContext())
            {
                var saleMedicine = db.SaleMedicines.Find(id);
                if (saleMedicine != null)
                {
                    saleMedicine.StockId = stockid ?? saleMedicine.StockId;
                    saleMedicine.MedicineId = medicineId ?? saleMedicine.MedicineId;
                    saleMedicine.Quantity = quantity ?? saleMedicine.Quantity;
                    db.SaveChanges();
                    System.Console.WriteLine("Venda_Medicamento atualizado com sucesso");
                }
                else
                {
                    System.Console.WriteLine("Venda_Medicamento não encontrado");
                }
            }
        }
        public void SaleMedicineDelete(int id)
        {
            using (var db = new AppDbContext())
            {
                var saleMedicine = db.SaleMedicines.Find(id);
                if (saleMedicine != null)
                {
                    db.SaleMedicines.Remove(saleMedicine);
                    db.SaveChanges();
                    System.Console.WriteLine("Venda_Medicamento deletado com sucesso");
                }
                else
                {
                    System.Console.WriteLine("Venda_Medicamento não encontrado");
                }
            }
        }
    }
}