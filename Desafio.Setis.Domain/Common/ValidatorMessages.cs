namespace Desafio.Setis.Domain.Common
{
    public static class ValidatorMessages
    {
        public static string IdGreaterThanZero = "Objeto: {0}, Id:{1}: Campo {2} precisa ser maior que 0";
        public static string IdDuplicated = "Objeto: {0}, Id:{1}: Entidade {2} Duplicada";
        public static string FieldRequired = "Objeto: {0}, Id:{1}: Campo {2} é obrigatório";
        public static string ResponsibleNameLength = "Objeto: {0}, Id:{1}: Campo {2} precisa ser menor que {3} caracteres";
        public static string IdNotFound = "Objeto: {0}, Id:{1}: Entidade {2} não encontrada";
    }
}
