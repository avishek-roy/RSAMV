using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RSAMV_Utility.DataAnnotations
{
    public sealed class GreaterThan : ValidationAttribute, IClientValidatable
    {
        private readonly string CompareWith;
        private readonly bool AllowEqual;

        public GreaterThan(string compareWith, bool allowEqual = false)
        {
            this.CompareWith = compareWith;
            this.AllowEqual = allowEqual;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyTestedInfo = validationContext.ObjectType.GetProperty(this.CompareWith);
            if (propertyTestedInfo == null)
            {
                return new ValidationResult(string.Format("unknown property {0}", this.CompareWith));
            }

            var propertyTestedValue = propertyTestedInfo.GetValue(validationContext.ObjectInstance, null);

            if (value == null || !(value is DateTime))
            {
                return ValidationResult.Success;
            }

            if (propertyTestedValue == null || !(propertyTestedValue is DateTime))
            {
                return ValidationResult.Success;
            }

            // Compare values 
            if (propertyTestedValue.GetType() == typeof(DateTime))
                return Compare((DateTime)value, (DateTime)propertyTestedValue, validationContext);
            else if (propertyTestedValue.GetType() == typeof(int))
                return Compare((int)value, (int)propertyTestedValue, validationContext);
            else if (propertyTestedValue.GetType() == typeof(decimal))
                return Compare((decimal)value, (decimal)propertyTestedValue, validationContext);


            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }



        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = this.ErrorMessageString,
                ValidationType = "greaterthan"
            };
            rule.ValidationParameters["comparewith"] = this.CompareWith;
            rule.ValidationParameters["allowequal"] = this.AllowEqual;
            yield return rule;
        }

        #region Compare
        private ValidationResult Compare(DateTime value, DateTime propertyTestedValue, ValidationContext validationContext)
        {
            // Compare values 
            if (value >= propertyTestedValue)
            {
                if (this.AllowEqual)
                {
                    return ValidationResult.Success;
                }
                if (value > propertyTestedValue)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        private ValidationResult Compare(int value, int propertyTestedValue, ValidationContext validationContext)
        {
            // Compare values 
            if (value >= propertyTestedValue)
            {
                if (this.AllowEqual)
                {
                    return ValidationResult.Success;
                }
                if (value > propertyTestedValue)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        private ValidationResult Compare(decimal value, decimal propertyTestedValue, ValidationContext validationContext)
        {
            // Compare values 
            if (value >= propertyTestedValue)
            {
                if (this.AllowEqual)
                {
                    return ValidationResult.Success;
                }
                if (value > propertyTestedValue)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
        #endregion
    }

}