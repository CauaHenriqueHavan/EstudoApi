namespace estudo.domain.Paginado
{
    public class PaginadoOutput<T>
    {
        public IEnumerable<T> Dados  { get; set; }
        public int PaginaAtual { get; set; }
        public int Paginas { get; set; }
        public int TotalItens { get; set; }

        public PaginadoOutput(IEnumerable<T> dados, int paginaAtual, int totalItens, int itensPorPagina = 7)
        {
            Dados = dados;
            Paginas = (int)Math.Ceiling((double)totalItens / itensPorPagina);
            PaginaAtual = paginaAtual;
            TotalItens = totalItens;
        }
    }
}
