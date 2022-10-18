using estudo.domain.Common.Interfaces;
using estudo.service.Events.Notification;
using MediatR;

namespace estudo.service.Events.Handler
{
    public class LogUsuarioHandler : INotificationHandler<LogUsuarioNotification>
    {
        private readonly ILogService _logService;

        public LogUsuarioHandler(ILogService logService)
            => _logService = logService;


        public async Task Handle(LogUsuarioNotification notification, CancellationToken cancellationToken)
        {
            if(notification.Id <= 0)
                return;

            await _logService.GravarLogAsync(notification.Id, notification.TipoEvento);
        }
    }
}
