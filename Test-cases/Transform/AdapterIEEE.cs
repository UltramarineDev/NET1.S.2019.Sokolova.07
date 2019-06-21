using ArrayManipulations.Interfaces;

namespace Test_cases.Transform
{
    /// <summary>
    /// Class implements interface ITransformer
    /// </summary>
    public class AdapterIEEE : ITransformer
    {
        /// <summary>
        /// Transform double using external extension method 
        /// </summary>
        /// <param name="number">input number</param>
        /// <returns>string - result of transformation</returns>
        public string TransformDouble(double number)
        {
            return number.GetIEEEBinaryString();
        }
    }
}
