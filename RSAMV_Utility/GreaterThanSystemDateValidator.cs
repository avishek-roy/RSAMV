using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RSAMV_Utility.DataAnnotations
{
    public sealed class GreaterThanSystemDate : ValidationAttribute, IClientValidatable
    {
        public DateTime CompareWith;
        private readonly bool AllowEqual;

        public GreaterThanSystemDate(bool allowEqual = false)
        {
            this.CompareWith = DateTime.Now.Date;
            this.AllowEqual = allowEqual;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (CompareWith == null)
            {
                return new ValidationResult(string.Format("Value not set properly", this.CompareWith));
            }

            if (value == null || !(value is DateTime))
            {
                return ValidationResult.Success;
            }


            // Compare values 
            if (CompareWith.GetType() == typeof(DateTime))
                return Compare((DateTime)value, Convert.ToDateTime(CompareWith), validationContext);


            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }



        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = this.ErrorMessageString,
                ValidationType = "greaterthansystemdate"
            };
            rule.ValidationParameters["comparewith"] = this.CompareWith.ToString("dd/MM/yyyy");
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
        #endregion
    }

}