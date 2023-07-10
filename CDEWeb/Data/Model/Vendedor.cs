using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDEWeb.Data.Model
{
    public class Vendedor
    {
        //-------------------------------------------------------------
        #region Variáveis
        //-------------------------------------------------------------
        [Key]
        public int      Id      { get; set; }
        public string   Nome    { get; set; }
        [Column( TypeName = "decimal(18,4)" )]
        public decimal Comissao { get; set; }    
        //-------------------------------------------------------------
        #endregion Variáveis
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region Construtor
        //-------------------------------------------------------------
        public Vendedor() 
        {
            Nome = string.Empty;
        }
        //-------------------------------------------------------------
        #endregion Construtor
        //-------------------------------------------------------------
    }
}
