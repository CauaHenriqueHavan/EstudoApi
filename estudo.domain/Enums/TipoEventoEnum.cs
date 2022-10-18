using System.ComponentModel;

namespace estudo.domain.Enums
{
    public enum TipoEventoEnum
    {
        [Description("Usuario criado!")]
        UsuarioCriado = 0,

        [Description("Alterado dados usuario!")]
        AlteradoUsuario = 1,

        [Description("Situação do usuario alterada!")]
        SituacaoUsuario = 2
    }
}
