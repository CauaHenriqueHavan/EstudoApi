namespace estudo.domain.DTO_s.OutPutModelAuxiliar
{
    public class PaginadoOutputModel<T>
    {
        public IEnumerable<T> Itens { get; set; }

        public int TotalItens { get; set; }

        public int PaginaAtual { get; set; }

        public int TotalPaginas { get; set; }

        public PaginadoOutputModel()
        {
            Itens = new List<T>();
        }

        public PaginadoOutputModel(IEnumerable<T> itens, int totalItens, int paginaAtual, int itensPorPagina)
        {
            Itens = itens;
            TotalItens = totalItens;
            PaginaAtual = paginaAtual;
            TotalPaginas = (int)Math.Ceiling((double)totalItens / (double)itensPorPagina);
        }
    }
}
