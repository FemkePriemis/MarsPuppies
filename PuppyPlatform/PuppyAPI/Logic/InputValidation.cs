using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace PuppyAPI.Logic
{
    public class InputValidation
    {
        public HashSet<String> badWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase) {
                "bad",
                "words",
            };
        public bool findBadWords(string text)
        {
            bool result;

            if (text.Contains(" "))
            {
                result = text
                .Split(' ')
                .Any(line => Regex
                    .Split(line, @"\W")
                    .Any(word => badWords.Contains(word)));
            }

            else
            {
                result = badWords.Any(word => text.Contains(word));
            }
            
            return result;
        }
    }
}
