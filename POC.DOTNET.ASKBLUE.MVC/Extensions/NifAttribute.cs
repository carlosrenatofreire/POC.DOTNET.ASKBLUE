using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using POC.ASKBLUE.LIBRARY.CORE.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace POC.DOTNET.ASKBLUE.MVC.Extensions
{
    public class NifAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("NIF cannot be empty!");

            return Nif.IsValid(value.ToString()) ? ValidationResult.Success : new ValidationResult("Nif is invalid format!");
        }
    }

    public class NifAttributeAdapter : AttributeAdapterBase<NifAttribute>
    {

        public NifAttributeAdapter(NifAttribute attribute, IStringLocalizer stringLocalizer) : base(attribute, stringLocalizer)
        {

        }
        public override void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-Nif", GetErrorMessage(context));
        }
        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return "Nif in invalid format";
        }
    }

    public class NifValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
    {
        private readonly IValidationAttributeAdapterProvider _baseProvider = new ValidationAttributeAdapterProvider();

        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            if (attribute is NifAttribute CpfAttribute)
            {
                return new NifAttributeAdapter(CpfAttribute, stringLocalizer);
            }

            return _baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
}
