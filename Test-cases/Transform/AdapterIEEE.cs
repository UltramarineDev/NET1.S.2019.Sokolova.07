using ArrayManipulations.Interfaces;

namespace Test_cases.Transform
{
    /// <summary>
    /// 
    /// </summary>
    public class AdapterIEEE : ITransformer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string TransformDouble(double number)
        {
            return number.GetIEEEBinaryString();
        }
    }
}
