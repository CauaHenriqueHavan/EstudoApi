using estudo.domain.Enums;

namespace estudo.domain.Common
{
    public class LogRequestModel
    {
        public short Id { get; set; }
        public TipoEventoEnum TipoEvento { get; set; }

        public LogRequestModel(short id, TipoEventoEnum tipoEvento)
        {
            Id = id;
            TipoEvento = tipoEvento;
        }
    }
}
