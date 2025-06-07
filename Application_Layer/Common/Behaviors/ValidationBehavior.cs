using Application_Layer.Common.Results;
using FluentValidation;
using MediatR;

namespace Application_Layer.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    // ❌ Returnera ett fail-svar om vi använder OperationResult som TResponse
                    var errorMessages = failures.Select(f => f.ErrorMessage).ToList();

                    // Här gör vi antagandet att TResponse är OperationResult<T>
                    var resultType = typeof(TResponse);
                    if (resultType.IsGenericType && resultType.GetGenericTypeDefinition() == typeof(OperationResult))
                    {
                        var failMethod = resultType.GetMethod("Fail", new[] { typeof(List<string>) });
                        if (failMethod != null)
                        {
                            return (TResponse)failMethod.Invoke(null, new object[] { errorMessages })!;
                        }
                    }

                    throw new ValidationException(failures); // fallback
                }
            }

            return await next();
        }
    }
}
