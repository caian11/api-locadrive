using api_teste.DataContexts;
using System.ComponentModel.DataAnnotations;

namespace api_teste.Validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not string email)
                return ValidationResult.Success;

            // recupera o seu DbContext a partir do ValidationContext
            var db = (AppDbContext)validationContext.GetService(typeof(AppDbContext))!;
            var exists = db.Pessoas.Any(p => p.Email == email);

            return exists
                ? new ValidationResult("E‑mail já cadastrado.", new[] { validationContext.MemberName! })
                : ValidationResult.Success;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UniqueCpfAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not string cpf)
                return ValidationResult.Success;

            var db = (AppDbContext)validationContext.GetService(typeof(AppDbContext))!;
            var exists = db.Pessoas.Any(p => p.Cpf == cpf);

            return exists
                ? new ValidationResult("CPF já cadastrado.", new[] { validationContext.MemberName! })
                : ValidationResult.Success;
        }
    }
}
