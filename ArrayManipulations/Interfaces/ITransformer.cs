namespace ArrayManipulations.Interfaces
{
    /// <summary>
    /// Interface represents method TransformDouble
    /// </summary>
    public interface ITransformer
    {
        /// <summary>
        /// Transforms the double.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>string - result of tranformation</returns>
        string TransformDouble(double number);
    }
}
