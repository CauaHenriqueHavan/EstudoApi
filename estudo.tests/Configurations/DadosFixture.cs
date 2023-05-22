using estudo.domain.Entities;
using estudo.domain.Enums;

namespace estudo.tests.Configurations
{
    public static class DadosFixture
    {
        public static List<ClienteEntity> GerarClienteEntity()
             => new()
             {
                 new("caua", "henrique", DateTime.Now.AddYears(-20), "13111224945", SituacaoEnum.Ativo),
                 new("jose", "marcos", DateTime.Parse("2002-05-01"), "15462331242", SituacaoEnum.Ativo)
             };
    }
}
