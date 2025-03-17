using Microsoft.EntityFrameworkCore;
namespace FarmacySystem.model
{
    public class YourDbContext : DbContext
    {
        // Defina a tabela Sales no DbContext
        public DbSet<Sale> Sales { get; set; }
    
        // Adicione outros DbSet se tiver outras tabelas no banco de dados, como:
        // public DbSet<Customer> Customers { get; set; }

        // Construa a string de conexão para o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Aqui você configura sua string de conexão para o banco de dados
                optionsBuilder.UseNpgsql("YourConnectionString"); // Substitua com sua string de conexão
            }
        }

        // (Opcional) Configurações adicionais, como chave primária, mapeamento de tabelas, etc.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Defina mapeamentos adicionais, se necessário
        }
    }

}
