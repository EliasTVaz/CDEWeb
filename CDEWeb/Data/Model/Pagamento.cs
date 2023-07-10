using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDEWeb.Data.Model
{
    public class Pagamento
    {
        //-------------------------------------------------------------
        #region Variáveis
        //-------------------------------------------------------------
        [Key]
        public int          Id          { get; set; }
        public Contrato     Contrato    { get; set; }
        
        [Column( TypeName = "decimal(18,4)" )]
        public decimal      ValorPago   { get; set; }
        //-------------------------------------------------------------
        #endregion Variáveis
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region Construtor
        //-------------------------------------------------------------
        public Pagamento() 
        {
            Contrato = new Contrato();
        }
        //-------------------------------------------------------------
        #endregion Construtor
        //-------------------------------------------------------------
    }
}
