namespace estudo.domain.Auxiliar
{
    public class ResultViewBaseModel
    {
        public List<string> Errors { get; }

        public bool Success => !Errors.Any();

        internal object BaseResult { get; set; }

        public ResultViewBaseModel()
        {
            Errors = new List<string>();
        }

        public ResultViewBaseModel AddErros(string erro)
        {
            Errors.Add(erro);
            return this;
        }

        public ResultViewBaseModel AddErros(List<string> erros)
        {
            Errors.AddRange(erros);
            return this;
        }

        public List<T> RetornoResult<T>() where T : class
        {
            object result;
            if (BaseResult is List<T>)
            {
                result = BaseResult as List<T>;
            }
            else
            {
                List<T> list = new List<T>();
                list.Add(BaseResult as T);
                result = list;
            }

            return (List<T>)result;
        }

        public T RetornoResult<T>(int index) where T : class
        {
            return !(BaseResult is List<T>) ? BaseResult as T : (BaseResult as List<T>)[index];
        }

        public object RetornoResult()
        {
            return BaseResult;
        }
    }
}
