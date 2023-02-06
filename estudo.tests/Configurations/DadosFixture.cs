using estudo.domain.Entities;

namespace estudo.tests.Configurations
{
    public static class DadosFixture
    {
        public static ClienteEntity GerarClienteEntity()
             => new(1,"caua", "henrique", DateTime.Now.AddYears(-20), "13111224945", domain.Enums.SituacaoEnum.Ativo);
    }
}
