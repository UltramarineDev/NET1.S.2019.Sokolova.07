using System.Runtime.InteropServices;

namespace Test_cases.Transform
{
    /// <summary>
    /// Initial Transform class (from day 4)
    /// </summary>
    public static class TransformerIEEE
    {
        // <summary>
        /// Gets string of bits according to IEEE 754
        /// </summary>
        /// <param name="number">input number</param>
        /// <returns>string with number in binary format</returns>
        public static string GetIEEEBinaryString(this double number)
        {
            var convertion = new ConversionDoubleToLong { DoubleBitsForm = number };
            long numberLong = convertion.LongBitsForm;
            int countOfBit = sizeof(double) * 8;
            char[] resultArray = new char[countOfBit];
            resultArray[0] = numberLong < 0 ? '1' : '0';

            for (int i = countOfBit - 2, j = 1; i >= 0; i--, j++)
            {
                resultArray[j] = (numberLong & (1L << i)) != 0 ? '1' : '0';
            }

            return new string(resultArray);
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct ConversionDoubleToLong
        {
            [FieldOffset(0)]
            private readonly long long64bit;

            [FieldOffset(0)]
            private double double64bit;

            public long LongBitsForm => long64bit;
            
            public double DoubleBitsForm
            {
                set => double64bit = value;
            }
        }
    }
}
