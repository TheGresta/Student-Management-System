using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Exceptions;
using Core.Utilities.Interceptors;
using FluentValidation;
using System.Diagnostics;

namespace Core.Aspects.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private readonly Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            WrongValidationTypeException.ThrowIfWrongType(typeof(IValidator), validatorType);

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            IValidator validator = (IValidator)Activator.CreateInstance(_validatorType);
            Type entityType = _validatorType.BaseType.GetGenericArguments()[0];

            var entities = invocation.Arguments.Where(x => x.GetType() == entityType).ToList();
            foreach (var entity in entities)
            {
                Debug.WriteLine($"Validation: {entity.GetType().Name}");
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
