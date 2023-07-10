using CDEWeb.Data.Model;
using CDEWeb.Data;
using Microsoft.EntityFrameworkCore;
using Azure.Core;

namespace CDEWeb.Services
{
    public class EmpresaService : BaseService
    {
        //-------------------------------------------------------------
        #region construtor
        //-------------------------------------------------------------
        public EmpresaService( DataContext context )
            : base( context )
        {
        }
        //-------------------------------------------------------------
        #endregion construtor
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region public class
        //-------------------------------------------------------------
        public async Task<List<Empresa>> GetAll()
        {
            return ( await _context.Empresas.ToListAsync() );
        }

        //-------------------------------------------------------------
        public async Task<Empresa?> Find( int Id )
        {
            var empresa = await _context.Empresas.FindAsync( Id );

            if( empresa is null )
                return null;

            return ( empresa );
        }

        //-------------------------------------------------------------
        public async Task<List<Empresa>> Add( Empresa empresa )
        {
            _context.Empresas.Add( empresa );

            await _context.SaveChangesAsync();

            return ( await _context.Empresas.ToListAsync() );
        }

        //-------------------------------------------------------------
        public async Task<string> Delete( int IdEmpresa )
        {
            var empresa = await _context.Empresas.FindAsync( IdEmpresa );

            if( empresa is null )
                return ( "Não é possível excluir a Empresa porque já existe Funcionários associados a ela." );

            var funcionario = await _context.Funcionarios.Where( x => x.Empresa.Id.Equals( IdEmpresa ) ).FirstOrDefaultAsync();

            if( funcionario is not null )
                return ( "Não é possível excluir a Empresa porque já existe Funcionários associados a ela." );

            _context.Empresas.Remove( empresa );
            await _context.SaveChangesAsync();

            return ( string.Empty );
        }

        //-------------------------------------------------------------
        #endregion public class
        //-------------------------------------------------------------
    }
}
