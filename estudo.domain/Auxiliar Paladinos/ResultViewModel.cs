namespace estudo.domain.Auxiliar
{
    public class ResultViewModel<T> : ResultViewBaseModel
    {
        public T Result { get; set; }

        public ResultViewModel()
        {
        }

        public ResultViewModel(T value)
        {
            BaseResult = value;
            Result = value;
        }

        public new ResultViewModel<T> AddErros(string erro)
        {
            base.AddErros(erro);
            return this;
        }

        public new ResultViewModel<T> AddErros(List<string> erros)
        {
            base.AddErros(erros);
            return this;
        }

        public ResultViewModel<T> AddResult(T valor)
        {
            BaseResult = valor;
            Result = valor;
            return this;
        }
    }
}
