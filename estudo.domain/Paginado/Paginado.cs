namespace estudo.domain.Paginado
{
    public sealed class Paginado<T>
    {
        public int TotalItensCount { get; set; }
        public int PaginaNumero { get; set; }
        public int PaginaTamanho { get; set; }
        public IQueryable<T> Itens { get; set; }

        public Paginado(IQueryable<T> entidadeSet, int pagNumero, int pagTamanho = 7)
        {
            if(pagNumero < 1)
               pagNumero = 1;

            if (pagTamanho < 1 )
                pagTamanho = 1;

            TotalItensCount = entidadeSet is null ? 0 : entidadeSet.Count();
            PaginaTamanho = pagTamanho;
            PaginaNumero = pagNumero;

            Itens = pagNumero == 1
                        ? entidadeSet.Skip(0).Take(pagTamanho)
                        : entidadeSet.Skip(0).Take(pagTamanho);
        }

        public Paginado(IEnumerable<T> entidadeSet, int pagNumero, int pagTamanho = 7) : this(entidadeSet.AsQueryable(), pagNumero, pagTamanho) { }
    }
}
