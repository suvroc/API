using System.ComponentModel.DataAnnotations;

namespace AnyStatus.API
{
    public interface IValidator<in T>
    {
        ValidationResult Validate(T instance);
    }
}
