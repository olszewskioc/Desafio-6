using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FarmacySystem.data;
using FarmacySystem.model;
using Npgsql;

namespace FarmacySystem.controller
{
    public class CrudUser
    {
        public void InsertUser(int id, string name, string role, string cpf, string password)
        {
           try
            {
                if (role != "farmaceutico" || role != "gerente" || role != "atendente")
                    throw new Exception($"Invalid Role for User: {role}\nOnly can be: farmaceutico, gerente or atendente");
                using (var db = new AppDbContext())
                {
                    db.Users.Add(new User {Id = id, Name = name, Role = role, Cpf = cpf, Password = password});
                    db.SaveChanges();
                    Console.WriteLine($"User {name} sucessfully created!\n");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"ERROR DB: {ex.Message}");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            } 
        }

        public List<string>? ListUser(int? id = null, string? name = null, string? role = null, string? cpf = null)
        {
            try
            {
                List<string> result = new List<string>();
                var users = new List<User>();
                using (var db = new AppDbContext())
                {
                    if (id == null && name == null && role == null && cpf == null)   // GET ALL
                    {
                        users = [.. db.Users];
                    } else if (id != null && name == null && role == null && cpf == null)    // GET BY ID
                    {
                        users = [.. db.Users.Where(u => u.Id == id)];
                    } else if (id == null && name != null && role == null && cpf == null)   // GET BY NAME
                    {
                        users = [.. db.Users.Where(u => u.Name == name)];
                    }
                    else
                    {
                        throw new Exception("ERRO: Invalid parameters");
                    }
                    
                    foreach (var user in users)
                    {
                        string linha  = $"ID: {user.Id} | NAME: {user.Name} | ROLE: {user.Role} | CPF: {user.Cpf} | PASSWORD: {user.Password}";
                        result.Add(linha);
                    }
                    return result;
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"ERROR DB: {ex.Message}");
                return null;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                return null;
            }
        }

        public void UpdateUser(int id, string name, string role, string cpf, string password)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var user = db.Users.Find(id) ?? throw new Exception($"Unable to find user {id}");
                    
                    user.Name = name ?? user.Name;
                    user.Password = password ?? user.Password;
                    user.Role = role ?? user.Role;
                    user.Cpf = cpf ?? user.Cpf;

                    db.SaveChanges();
                    Console.WriteLine($"User {id} updated sucessfully\n");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"ERROR DB: {ex.Message}");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var user = db.Users.Find(id) ?? throw new Exception($"Unable to find user {id}");

                    db.Users.Remove(user);
                    db.SaveChanges();
                    Console.WriteLine($"User {id} deleted sucessfully\n");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"ERROR DB: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }
}