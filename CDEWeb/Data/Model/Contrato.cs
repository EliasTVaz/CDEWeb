using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDEWeb.Data.Model
{
    public class Contrato
    {
        //-------------------------------------------------------------
        #region Variáveis
        //-------------------------------------------------------------
        [Key]
        public int              Id              { get; set; }
        public Funcionario?     Funcionario     { get; set; }
        public Vendedor?        Vendedor        { get; set; }
        public Bem?             Bem             { get; set; }

        [Column( TypeName = "decimal(18,4)" )]
        public decimal          ValorEmprestimo { get; set; }   
        public List<Pagamento>  Pagamentos      { get; set; }
        
        public DateTime         dataInicio      { get; set; }
        
        public DateTime         dataFim         { get; set; }
        //-------------------------------------------------------------
        #endregion Variáveis
        //-------------------------------------------------------------

        //-------------------------------------------------------------
        #region Construtor
        //-------------------------------------------------------------
        public Contrato()
        {
            Funcionario = new Funcionario();
            Vendedor = new Vendedor();
            Pagamentos = new List<Pagamento>();
            Bem = new Bem();
        }
        //-------------------------------------------------------------
        #endregion Construtor
        //-------------------------------------------------------------
    }
}
