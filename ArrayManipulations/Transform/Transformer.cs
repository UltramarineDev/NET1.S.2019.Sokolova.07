using ArrayManipulations.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ArrayManipulations.Transform
{
    /// <summary>
    /// abstract class Transformer
    /// </summary>
    public abstract class Transformer : ITransformer
    {
        /// <summary>
        /// Method of Transforming double
        /// </summary>
        /// <param name="number">input double</param>
        /// <returns>string representation</returns>
        public string TransformDouble(double number)
        {
            Dictionary<double, string> specialCases = GetSpecialDoubles();

            if (specialCases.TryGetValue(number, out string result))
            {
                return result;
            }

            Dictionary<char, string> words = GetWords();

            return GetWordRepresentation(number, words);
        }

        protected abstract Dictionary<char, string> GetWords();

        protected abstract Dictionary<double, string> GetSpecialDoubles();

        private static string GetWordRepresentation(double number, Dictionary<char, string> dictionary)
        {
            string stringRepresentation = number.ToString(CultureInfo.InvariantCulture);
            var verbalPresentation = new StringBuilder();

            foreach (var s in stringRepresentation)
            {
                verbalPresentation.Append($"{dictionary[s]} ");
            }

            return verbalPresentation.ToString().TrimEnd();
        }
    }

}
