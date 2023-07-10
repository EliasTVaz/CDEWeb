using CDEWeb.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace CDEWeb.Data
{
    public class DataContext : DbContext
    {
        public DataContext( DbContextOptions<DataContext> options ) : base( options ) { }

        public DbSet<Bem>           Bens            { get; set; }
        public DbSet<Contrato>      Contratos       { get; set; }
        public DbSet<Empresa>       Empresas        { get; set; }
        public DbSet<Funcionario>   Funcionarios    { get; set; }
        public DbSet<Pagamento>     Pagamentos      { get; set; }
        public DbSet<Vendedor>      Vendedores      { get; set; }
        public DbSet<SPC>           SPCs            { get; set; }
    }
}
