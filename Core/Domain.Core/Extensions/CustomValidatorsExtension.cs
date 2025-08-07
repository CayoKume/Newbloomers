using FluentValidation;

namespace Application.Core.Validations.Extensions
{
    public static class CustomValidatorsExtension
    {
        public static IRuleBuilderOptions<T, string?> MustBeValidInt32<T>(this IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => int.TryParse(value, out _))
                .WithMessage($"O valor [0] deve ser um número inteiro (Int32) válido.");
        }

        public static IRuleBuilderOptions<T, string?> MustBeValidInt64<T>(this IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => Int64.TryParse(value, out _))
                .WithMessage($"O valor [0] deve ser um número inteiro (Int64) válido.");
        }

        public static IRuleBuilderOptions<T, string?> MustBeValidDecimal<T>(this IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => !string.IsNullOrEmpty(value) && decimal.TryParse(value, out _))
                .WithMessage($"O valor [0] deve ser um número decimal válido.");
        }

        public static IRuleBuilderOptions<T, string?> MustBeValidDateTime<T>(this IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => !string.IsNullOrEmpty(value) && DateTime.TryParse(value, out _))
                .WithMessage($"O valor [0] deve ser uma data válida.");
        }

        public static IRuleBuilderOptions<T, string?> MustBeValidBoolean<T>(this IRuleBuilder<T, string?> ruleBuilder)
        {
            return ruleBuilder
                .Must(value => !string.IsNullOrEmpty(value) && bool.TryParse(value, out _))
                .WithMessage($"O valor [0] deve ser um booleano válido (true/false).");
        }
    }
}
