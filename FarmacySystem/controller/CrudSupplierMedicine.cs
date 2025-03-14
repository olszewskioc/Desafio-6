using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmacySystem.model;
using FarmacySystem.data;

namespace FarmacySystem.controller
{
    public class CrudSupplierMedicine
    {
        public void InsertSupplierMedicine(int id, int supplierId, int medicineId)
        {
            using (var db = new AppDbContext())
            {
                db.SupplierMedicines.Add(new SupplierMedicine { Id = id, SupplierId = supplierId, MedicineId = medicineId });
                db.SaveChanges();
            }
        }
        public List<string> ListSupplierMedicine()
        {
            List<string> SupplierMedicineList = new List<string>();

            using (var db = new AppDbContext())
            {
                var SupplierMedicine = db.SupplierMedicines.ToList();
                foreach (var supplierMedicines in SupplierMedicine)
                {
                    SupplierMedicineList.Add($"Id: {supplierMedicines.Id} Id do fornecedor: {supplierMedicines.SupplierId} Id do Medicamento: {supplierMedicines.MedicineId} ");
                }
            }
            return SupplierMedicineList;
        }
        public void SupplierMedicineUpdate(int id, int? supplierId = null, int? medicineId = null)
        {
            using (var db = new AppDbContext())
            {
                var supplierMedicine = db.SupplierMedicines.Find(id);
                if (supplierMedicine != null)
                {
                    supplierMedicine.SupplierId = supplierId ?? supplierMedicine.SupplierId;
                    supplierMedicine.MedicineId = medicineId ?? supplierMedicine.MedicineId;
                    db.SaveChanges();
                    System.Console.WriteLine("Fornecedor_medicamento atualizado com sucesso");
                }
                else
                {
                    System.Console.WriteLine("Fornecedor_medicamento não encontrado");
                }
            }
        }
        public void SupplierMedicineDelete(int id)
        {
            using (var db = new AppDbContext())
            {
                var supplierMedicine = db.SupplierMedicines.Find(id);
                if (supplierMedicine != null)
                {
                    db.SupplierMedicines.Remove(supplierMedicine);
                    db.SaveChanges();
                    System.Console.WriteLine("Fornecedor_medicamento deletado com sucesso");
                }
                else
                {
                    System.Console.WriteLine("Fornecedor_medicamento não encontrado");
                }
            }
        }
    }
}