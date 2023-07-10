namespace CDEWeb.DTOs
{
    public record struct ContratoDto( int IdFuncionario, int IdVendedor, int IdBem, decimal ValorEmprestimo, DateTime DataInicio, DateTime DataFim );
}
