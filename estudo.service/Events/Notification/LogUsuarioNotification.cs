using estudo.domain.Enums;
using MediatR;

namespace estudo.service.Events.Notification
{
    public class LogUsuarioNotification : INotification
    {
        public short Id { get; set; }
        public TipoEventoEnum TipoEvento { get; set; }

        public LogUsuarioNotification(short id, TipoEventoEnum tipoEvento)
        => (Id, TipoEvento) = (id, tipoEvento);
    }
}
