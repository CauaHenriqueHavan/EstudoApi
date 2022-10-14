﻿using estudo.domain.DTO_s;
using estudo.domain.DTO_s.InputModels;
using estudo.domain.Entities;
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

        public async Task<List<ClienteOutputModel>> BuscarClientesAsync()
            => await _context.Cliente.Select(x => new ClienteOutputModel
            {
                Cpf = x.Cpf,
                DataCriação = DateTime.Now,
                DataNascimento = x.DataNascimento,
                Nome = x.Nome,
                Sobrenome = x.Sobrenome
            })
            .ToListAsync();

        public async Task<ClienteOutputModel> BuscarClientesIdAsync(short id)
            => await _context.Cliente
                            .Where(x => x.Id == id)
                            .Select(x => new ClienteOutputModel
                            {
                                Cpf = x.Cpf,
                                DataCriação = DateTime.Now,
                                DataNascimento = x.DataNascimento,
                                Nome = x.Nome,
                                Sobrenome = x.Sobrenome
                            })
                            .FirstOrDefaultAsync();

        public async Task<bool> CriarClienteAsync(CadastrarClienteInputModel model)
        {
            var context = _context.Cliente;

            var clienteExiste = context.Where(x => x.Cpf.Contains(model.Cpf.ToLower())).FirstOrDefault();

            if (clienteExiste is not null)
                return false;

            var id = context.Select(x => x.Id).Count() + 1;

            await context.AddAsync(new ClienteEntity((short)id, model.Nome, model.Sobrenome, model.DataNascimento, model.Cpf));

            await _context.SaveChangesAsync();

            return true;
        }
    
    }
}