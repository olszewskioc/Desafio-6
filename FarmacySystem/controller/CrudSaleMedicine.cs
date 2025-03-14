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
        public void InsertSaleMedicine(int id, int stockid, int medicineId, int quantity)
        {
            using (var db = new AppDbContext())
            {
                db.SaleMedicines.Add(new SaleMedicine { Id = id, StockId = stockid, MedicineId = medicineId, Quantity = quantity });
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
                    SaleMedicinetList.Add($"Id: {saleMedicines.Id} Id do estoque: {saleMedicines.StockId} Id da venda: {saleMedicines.MedicineId} Quantidade: {saleMedicines.Quantity}");
                }
            }
            return SaleMedicinetList;
        }
        public void SaleMedicineUpdate(int id, int stockid, int medicineId, int quantity)
        {
            using (var db = new AppDbContext())
            {
                var saleMedicine = db.SaleMedicines.Find(id);
                if (saleMedicine != null)
                {
                    saleMedicine.StockId = stockid;
                    saleMedicine.MedicineId = medicineId;
                    saleMedicine.Quantity = quantity;
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