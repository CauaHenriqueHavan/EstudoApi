using estudo.domain.DTO_s;
using estudo.domain.DTO_s.InputModels;
using estudo.domain.DTO_s.OutPutModelAuxiliar;
using estudo.domain.Entities;
using estudo.domain.Enums;
using estudo.domain.Interfaces.Repository;
using estudo.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace estudo.infra.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
            => _context = context;

        public async Task<PaginadoOutputModel<ClienteOutputModel>> BuscarClientesAsync(BuscarClientesInputModel model)
        {
            var pagina = model.Pagina ?? 0;

            var query = _context.Cliente.Where(x => x.Situacao == SituacaoEnum.Ativo);

            var dados = await query.Select(x => new ClienteOutputModel
            {
                Cpf = x.Cpf,
                DataCriação = DateTime.Now,
                DataNascimento = x.DataNascimento,
                Nome = x.Nome,
                Sobrenome = x.Sobrenome,
                Situacao = x.Situacao
            })
            .Skip(pagina)
            .Take(model.ObterTotalItens())
            .ToListAsync();

            return new PaginadoOutputModel<ClienteOutputModel>
                (dados, query.Count(), model.PaginaAtual(), model.ObterTotalItens());
        }


        public async Task<ClienteOutputModel> BuscarClientesIdAsync(short id)
            => await _context.Cliente
                            .Where(x => x.Id == id)
                            .Select(x => new ClienteOutputModel
                            {
                                Cpf = x.Cpf,
                                DataCriação = DateTime.Now,
                                DataNascimento = x.DataNascimento,
                                Nome = x.Nome,
                                Sobrenome = x.Sobrenome,
                                Situacao = x.Situacao
                            })
                            .FirstOrDefaultAsync();

        public async Task<bool> CriarClienteAsync(CadastrarClienteInputModel model)
        {
            var context = _context.Cliente;

            var clienteExiste = context.Where(x => x.Cpf.Contains(model.Cpf.ToLower())).FirstOrDefault();

            if (clienteExiste is not null)
                return false;

            var id = context.Select(x => x.Id).Count() + 1;

            await context.AddAsync(new ClienteEntity((short)id, model.Nome, model.Sobrenome, model.DataNascimento, model.Cpf, SituacaoEnum.Ativo));

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AlterarCadastroClienteAsync(AlterarCadastroClienteInputModel model)
        {
            var context = _context.Cliente;

            var cliente = await context.Where(x => x.Cpf == model.Cpf).FirstOrDefaultAsync();

            if (cliente is null)
                return false;

            cliente.AlterarCadastro(model.Nome, model.Sobrenome);;

            return true;
        }

        public async Task<ClienteEntity> AlterarSituacaoClientesAsync(short id)
        {
            var teste = _context.Cliente;

            var cliente =  await teste.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (cliente is null)
                return null;

            cliente.AlterarSituacao();

            return cliente;
        }

    }
}
