namespace Desafio.Setis.Domain.Common
{
    public class ValidatorResult
    {
        public bool IsValid { get; }
        public string Log { get; }

        public ValidatorResult(bool isValid, string log)
        {
            IsValid = isValid;
            Log = log;
        }

        public static ValidatorResult Success => new(true, string.Empty);

        public static ValidatorResult Fail(string log) => new(false, log);

    }
}
