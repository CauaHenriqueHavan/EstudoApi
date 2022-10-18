namespace estudo.domain.DTO_s.InputModelAuxiliar
{
    public abstract class BaseFilterInputModel
    {
        private int _totalItens = 25;

        private int? _pagina;

        public int? Pagina
        {
            get
            {
                if (!_pagina.HasValue)
                {
                    return null;
                }

                return _pagina * _totalItens;
            }
            set
            {
                if (value.HasValue && value > 0)
                {
                    _pagina = value - 1;
                }
            }
        }

        public void AlterarTotalItensPaginacao(int totalItens)
        {
            _totalItens = totalItens;
        }

        public int ObterTotalItens()
        {
            return _totalItens;
        }

        public int PaginaAtual()
        {
            return _pagina.GetValueOrDefault() + 1;
        }
    }
}
