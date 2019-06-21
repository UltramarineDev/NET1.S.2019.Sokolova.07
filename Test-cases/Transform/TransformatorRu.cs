using System.Collections.Generic;

namespace Test_cases.Transform
{
    /// <summary>
    /// Class TransformatorRu
    /// </summary>
    public class TransformatorRu : Transformer
    {
        protected override Dictionary<char, string> GetWords() => new Dictionary<char, string>
        {
            ['0'] = "ноль",
            ['1'] = "один",
            ['2'] = "два",
            ['3'] = "три",
            ['4'] = "четыре",
            ['5'] = "пять",
            ['6'] = "шесть",
            ['7'] = "семь",
            ['8'] = "восемь",
            ['9'] = "девять",
            ['-'] = "минус",
            ['+'] = "плюс",
            ['.'] = "точка",
            [','] = "запятая",
            ['E'] = "экспонента",
            ['e'] = "экспонента"
        };

        protected override Dictionary<double, string> GetSpecialDoubles() => new Dictionary<double, string>
        {
            [double.NaN] = "не число",
            [double.NegativeInfinity] = "минус бесконечность",
            [double.PositiveInfinity] = "плюс бесконечность"
        };
    }
}
