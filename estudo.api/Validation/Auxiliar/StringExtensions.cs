using System.Text.RegularExpressions;

namespace estudo.api.Validation.Auxiliar
{
    public static class StringExtensions
    {
        public static bool ValidarCpf(this string input)
            =>  new Regex("[0-9]{3}[\\.][0-9]{3}[\\.][0-9]{3}[\\-][0-9]{2}").IsMatch(input);
             
    }
}
