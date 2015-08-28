namespace Playground.CQRS.Infrastructure.CommandValidators
{
    public class ValidationError
    {
        public string Expression { get; private set; }

        public string ErrorMessage { get; private set; }

        public ValidationError(string expression, string errorMessage)
        {
            this.Expression = expression;
            this.ErrorMessage = errorMessage;
        }
    }
}
