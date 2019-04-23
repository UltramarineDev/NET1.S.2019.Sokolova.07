using System.Collections.Generic;

namespace ArrayManipulations.Transform
{
    /// <summary>
    /// Class TransformatorEng
    /// </summary>
    public class TransformatorEng : Transformer
    {
        protected override Dictionary<char, string> GetWords() => new Dictionary<char, string>
        {
            ['0'] = "zero",
            ['1'] = "one",
            ['2'] = "two",
            ['3'] = "three",
            ['4'] = "four",
            ['5'] = "five",
            ['6'] = "six",
            ['7'] = "seven",
            ['8'] = "eight",
            ['9'] = "nine",
            ['-'] = "minus",
            ['+'] = "plus",
            ['.'] = "point",
            [','] = "comma",
            ['E'] = "exponent",
            ['e'] = "exponent"
        };

        protected override Dictionary<double, string> GetSpecialDoubles() => new Dictionary<double, string>
        {
            [double.NaN] = "not a number",
            [double.NegativeInfinity] = "negative infinity",
            [double.PositiveInfinity] = "positive infinity"
        };
    }
}
