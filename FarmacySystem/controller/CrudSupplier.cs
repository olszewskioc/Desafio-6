using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmacySystem.model;
using FarmacySystem.data;

namespace FarmacySystem.controller
{
    public class CrudSupplier
    {
        public void InsertSuppliers(int idS, string nameS, string cnpjS, string phoneS, string zip_codeS, int numberS)
        {
            using (var db = new AppDbContext())
            {
                db.Suppliers.Add(new Supplier { Id = idS, Name = nameS, Cnpj = cnpjS, Phone = phoneS, ZipCode = zip_codeS, Number = numberS });
                db.SaveChanges();
            }
        }
        public List<string> ListSuppliers()
        {
            List<string> SuppliersList = new List<string>();

            using (var db = new AppDbContext())
            {
                var suppliers = db.Suppliers.ToList();
                foreach (var supplier in suppliers)
                {
                    SuppliersList.Add($"Id: {supplier.Id} Nome: {supplier.Name} Cnpj: {supplier.Cnpj} Telefone: {supplier.Phone} Cep: {supplier.ZipCode} numero: {supplier.Number}");
                }
            }
            return SuppliersList;
        }
        public void SuppliersUpdate(int id, string? name = null, string? cnpj = null, string? phone = null, string? zip_code = null, int? number = null)
        {
            using (var db = new AppDbContext())
            {
                var supplier = db.Suppliers.Find(id);
                if (supplier != null)
                {
                    supplier.Name = name ?? supplier.Name;
                    supplier.Cnpj = cnpj ?? supplier.Cnpj;
                    supplier.Phone = phone ?? supplier.Phone;
                    supplier.ZipCode = zip_code ?? supplier.ZipCode;
                    supplier.Number = number ?? supplier.Number;
                    db.SaveChanges();
                    System.Console.WriteLine("Fornecedor atualizado com sucesso");
                }
                else
                {
                    System.Console.WriteLine("Fornecedor não encontrado");
                }
            }
        }
        public void SupplierDelete(int id)
        {
            using (var db = new AppDbContext())
            {
                var supplier = db.Sales.Find(id);
                if (supplier != null)
                {
                    db.Sales.Remove(supplier);
                    db.SaveChanges();
                    System.Console.WriteLine("Fornecedor deletado com sucesso");
                }
                else
                {
                    System.Console.WriteLine("supplier não encontrado");
                }
            }
        }
    }
}