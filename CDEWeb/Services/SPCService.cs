using CDEWeb.Data.Model;
using CDEWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace CDEWeb.Services
{
    public class SPCService : BaseService
    {
        //-------------------------------------------------------------
        #region construtor
        //-------------------------------------------------------------
        public SPCService( DataContext context )
            : base( context )
        {
        }
        //-------------------------------------------------------------
        #endregion construtor
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region public class
        //-------------------------------------------------------------
        public async Task<List<SPC>> GetAll()
        {
            return ( await _context.SPCs.ToListAsync() );
        }

        //-------------------------------------------------------------
        public async Task<SPC?> Find( int Id )
        {
            var spc = await _context.SPCs.FindAsync( Id );

            if( spc is null )
                return null;

            return ( spc );
        }

        //-------------------------------------------------------------
        public async Task<List<SPC>> Add( SPC spc )
        {
            _context.SPCs.Add( spc );

            await _context.SaveChangesAsync();

            return ( await _context.SPCs.ToListAsync() );
        }

        //-------------------------------------------------------------
        public async Task<List<SPC>?> Delete( int Id )
        {
            var spc = await _context.SPCs.FindAsync( Id );

            if( spc is null )
                return null;

            _context.SPCs.Remove( spc );
            await _context.SaveChangesAsync();

            return ( await _context.SPCs.ToListAsync() );
        }

        //-------------------------------------------------------------
        #endregion public class
        //-------------------------------------------------------------
    }
}
