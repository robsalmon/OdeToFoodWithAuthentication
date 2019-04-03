using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFoodWithAuthentication.Models
{
  /*  public class MaxWordsAttribute : ValidationAttribute
    {
        public MaxWordsAttribute(int maxWords)
            : base("{0} has too many words.")
        {
            _maxWords = maxWords;
        }

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
           if (value != null)
            {
                var ValueAsString = value.ToString();

                if (ValueAsString.Split(' ').Length > _maxWords)
                {

                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);

                        return new ValidationResult(errorMessage);
                    

                }
            }
            return ValidationResult.Success;
        }

        private readonly int _maxWords;
    } */

    public class RestaurantReview : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1024)]
        public string Body { get; set; }

        //[Display(Name = "User name")]
        // [DisplayFormat(NullDisplayText = "anonymous")]
        //[MaxWords(1)]
        public string ReviewerName { get; set; } = "Rob";

        [Range(1,10)]
        [Required]
        public int Rating { get; set; }

        public int RestaurantId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
          if (Rating < 2 && ReviewerName.ToLower().StartsWith("rob"))
            {
                yield return new ValidationResult("Sorry Rob, you cannot do this.");
            }
        }
    }
}