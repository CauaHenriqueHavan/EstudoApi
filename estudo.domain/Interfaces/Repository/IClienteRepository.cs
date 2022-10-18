namespace estudo.domain.Interfaces.Repository
{
    public interface IClienteRepository
    {
        Task<ClienteEntity> CriarClienteAsync(CadastrarClienteInputModel model);
        Task<PaginadoOutputModel<ClienteOutputModel>> BuscarClientesAsync(BuscarClientesInputModel model);
        Task<ClienteOutputModel> BuscarClientesIdAsync(short id);
        Task<ClienteEntity> AlterarCadastroClienteAsync(AlterarCadastroClienteInputModel model);

        Task<ClienteEntity> AlterarSituacaoClientesAsync(short id);
    }
}
