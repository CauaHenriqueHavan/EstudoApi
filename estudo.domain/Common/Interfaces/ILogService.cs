using estudo.domain.Enums;

namespace estudo.domain.Common.Interfaces
{
    public interface ILogService
    {
        Task GravarLogAsync(short id, TipoEventoEnum tipoEvento);
    }
}
