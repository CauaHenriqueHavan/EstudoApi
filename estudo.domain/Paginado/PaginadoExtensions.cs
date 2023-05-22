using System.Linq.Expressions;

namespace estudo.domain.Paginado
{
    public static class PaginadoExtensions
    {
        public delegate TSaida Converter<in TEntrada, out TSaida>(TEntrada entidadeSet);

        public static PaginadoOutput<TOutput> WithPaginationAsync<TEntidade, TOutput>(this IQueryable<TEntidade> entidades, Expression<Func<TEntidade, TOutput>> select, int pagNumero, int pagTamanho = 7)
        {
            var paginado = Task.Run(() => new Paginado<TEntidade>(entidades, pagNumero)).Result;

            var itens = paginado.Itens.Select(select).ToList();

            return new PaginadoOutput<TOutput>(itens, paginado.PaginaNumero, paginado.TotalItensCount, paginado.PaginaTamanho);
        }
    }
}