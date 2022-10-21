﻿using estudo.domain.DTO_s.InputModels;
using estudo.domain.DTO_s.OutPutModelAuxiliar;
using estudo.domain.DTO_s.OutputModels;
using estudo.domain.DTO_s.OutputModels.Auxiliares;
using estudo.domain.Entities;
using estudo.domain.Interfaces.Repository;
using estudo.infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace estudo.infra.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
            => _context = context;


        public async Task <PaginadoOutputModel<ProdutosOutputModel>> BuscarProdutosAsync(BuscarProdutosInputModel model)
        {
            var pagina = model.Pagina ?? 0;

            var query = from f in _context.Fornecedor
                              join p in _context.Produto on f.Id equals p.Fornecedor
                              select new ProdutosOutputModel
                              {
                                  Id = p.Id,
                                  Fornecedor = new FornecedorOutputModel
                                  {
                                      Id = f.Id,
                                      Nome = f.Nome,
                                      Situacao = f.Situacao
                                  },
                                  Situacao = p.Situacao,
                                  Nome = p.Nome,
                                  Preco = p.Preco
                              };

            if (model.Id != null)
                query = query.Where(x => x.Id == model.Id);

            if (model.Nome != null)
                query = query.Where(x => x.Nome.ToLower().Contains(model.Nome.ToLower()));

            if (model.Fornecedor != null)
                query = query.Where(x => x.Fornecedor.Id == model.Fornecedor);


            var result =  await query.Skip(pagina)
            .Take(model.ObterTotalItens())
            .ToListAsync();

            return new PaginadoOutputModel<ProdutosOutputModel> (result, result.Count, model.PaginaAtual(), model.ObterTotalItens());
        }
    }
}
