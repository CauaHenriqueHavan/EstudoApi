using estudo.domain.DTO_s;
using estudo.domain.DTO_s.InputModels;
using estudo.domain.Enums;

namespace estudo.tests.Configurations
{
    public static  class DadosFixture
    {
        #region GerarObjeto

        public static CadastrarClienteInputModel GerarObjeto_CadastrarClienteInputModelSucesso()
            => new("jose", "costa", DateTime.Now.AddYears(-18), "122.114.442-12");

        public static CadastrarClienteInputModel GerarObjeto_CadastrarClienteInputModelInSucesso()
           => new("jose", "costa", DateTime.Now.AddYears(-18), "12211444212");

        #endregion

        #region GerarLista

        public static List<ClienteOutputModel> GerarLista_ObterClientes()
            => new()
            {
                new(1,"carlos", "alberto",DateTime.Now.AddYears(-18), "114.212.111-48", SituacaoEnum.Ativo),
                new(2,"pericles", "araujo",DateTime.Now.AddYears(-23), "134.612.121-18", SituacaoEnum.Ativo),
                new(3,"jojo", "todynho",DateTime.Now.AddYears(-48), "224.242.321-45", SituacaoEnum.Ativo)
            };

        #endregion
    }
}
