using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmacySystem.model;
using FarmacySystem.data;

namespace FarmacySystem.controller
{
    public class CrudStock
    {
        public void InsertStock(int id, int quantity, DateTime updatedAt, int medicineId)
        {
            using (var db = new AppDbContext())
            {
                db.Stocks.Add(new Stock { Id = id, Quantity = quantity, UpdatedAt = updatedAt, MedicineId = medicineId });
                db.SaveChanges();
            }
        }
        public List<string> ListStock()
        {
            List<string> StockList = new List<string>();

            using (var db = new AppDbContext())
            {
                var Stock = db.Stocks.ToList();
                foreach (var stocks in Stock)
                {
                    StockList.Add($"Id: {stocks.Id} Quatidade: {stocks.Quantity} Data de criação: {stocks.UpdatedAt} Id do medicamento: {stocks.MedicineId} ");
                }
            }
            return StockList;
        }
        public void StockUpdate(int id, int? quantity = null, DateTime? updatedAt = null, int? medicineId = null)
        {
            using (var db = new AppDbContext())
            {
                var stock = db.Stocks.Find(id);
                if (stock != null)
                {
                    stock.Quantity = quantity ?? stock.Quantity;
                    stock.UpdatedAt = updatedAt ?? stock.UpdatedAt;
                    stock.MedicineId = medicineId ?? stock.MedicineId;
                    db.SaveChanges();
                    System.Console.WriteLine("Estoque atualizado com sucesso");
                }
                else
                {
                    System.Console.WriteLine("Estoque não encontrado");
                }
            }
        }
        public void StockDelete(int id)
        {
            using (var db = new AppDbContext())
            {
                var stock = db.Stocks.Find(id);
                if (stock != null)
                {
                    db.Stocks.Remove(stock);
                    db.SaveChanges();
                    System.Console.WriteLine("Estoque deletado com sucesso");
                }
                else
                {
                    System.Console.WriteLine("Estoque não encontrado");
                }
            }
        }
    }
}