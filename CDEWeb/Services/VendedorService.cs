using CDEWeb.Data.Model;
using CDEWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace CDEWeb.Services
{
    public class VendedorService : BaseService
    {
        //-------------------------------------------------------------
        #region construtor
        //-------------------------------------------------------------
        public VendedorService( DataContext context )
            : base( context )
        {
        }
        //-------------------------------------------------------------
        #endregion construtor
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region public class
        //-------------------------------------------------------------
        public async Task<List<Vendedor>> GetAll()
        {
            return ( await _context.Vendedores.ToListAsync() );
        }

        //-------------------------------------------------------------
        public async Task<Vendedor?> Find( int Id )
        {
            var vendedor = await _context.Vendedores.FindAsync( Id );

            if( vendedor is null )
                return null;

            return ( vendedor );
        }

        //-------------------------------------------------------------
        public async Task<List<Vendedor>> Add( Vendedor vendedor )
        {
            _context.Vendedores.Add( vendedor );

            await _context.SaveChangesAsync();

            return ( await _context.Vendedores.ToListAsync() );
        }
        //-------------------------------------------------------------
        #endregion public class
        //-------------------------------------------------------------
    }
}
