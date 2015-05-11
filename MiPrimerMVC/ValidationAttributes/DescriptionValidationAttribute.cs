using System.ComponentModel.DataAnnotations;

namespace MiPrimerMVC.ValidationAttributes
{
    public class DescriptionValidationAttribute : ValidationAttribute
    {
        public int MinimumAmountOfWords { get; set; }
        public int MaximumAmountOfCharacters { get; set; }
        public int MinimumAmountOfCharacters { get; set; }

        public DescriptionValidationAttribute()
        {
            MinimumAmountOfWords = -1;
            MaximumAmountOfCharacters = -1;
            MinimumAmountOfCharacters = -1;
        }

        public override bool IsValid(object value)
        {
            var strValue = (string) value;
            var wordsInStrValue = strValue.Split(' ');
            return (MinimumAmountOfWords == -1 || wordsInStrValue.Length >= MinimumAmountOfWords) && 
                (MaximumAmountOfCharacters == -1 || strValue.Length <= MaximumAmountOfCharacters) && 
                (MinimumAmountOfWords == -1 || strValue.Length >= MinimumAmountOfCharacters);
        }
    }
}