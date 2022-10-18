namespace estudo.domain.Auxiliar
{
    public abstract class BaseService
    {
        private readonly List<string> _erros;

        public BaseService()
        {
            _erros = new List<string>();
        }

        protected void AddErrosApenas(string erro)
        {
            _erros.Add(erro);
        }

        protected void AddErrosApenas(List<string> erros)
        {
            _erros.AddRange(erros);
        }

        protected ResultViewBaseModel AddErros(string erro)
        {
            _erros.Add(erro);
            return Retorno();
        }

        protected ResultViewBaseModel AddErros(List<string> erros)
        {
            _erros.AddRange(erros);
            return Retorno();
        }

        protected ResultViewModel<T> AddErros<T>(List<string> erros, T result = default)
        {
            _erros.AddRange(erros);
            return AddResult(result);
        }

        protected ResultViewModel<T> AddErros<T>(string erro, T result = default)
        {
            _erros.Add(erro);
            return AddResult(result);
        }

        protected ResultViewModel<T> Retorno<T>()
        {
            ResultViewModel<T> resultViewModel = new ResultViewModel<T>(default);
            return resultViewModel.AddErros(_erros);
        }

        protected ResultViewModel<T> AddResult<T>(T result)
        {
            ResultViewModel<T> resultViewModel = new ResultViewModel<T>(result);
            return resultViewModel.AddErros(_erros);
        }

        protected ResultViewBaseModel Retorno()
        {
            ResultViewBaseModel resultViewBaseModel = new ResultViewBaseModel();
            return resultViewBaseModel.AddErros(_erros);
        }
    }
}
