namespace ArrayManipulations.Interfaces
{
    /// <summary>
    /// Interface represent method FilterByCondition
    /// </summary>
    public interface IPredicate
    {
        /// <summary>
        /// condition method
        /// </summary>
        /// <param name="number">input integer number</param>
        /// <returns>true if condition os correct, false otherwise</returns>
        bool IsPredicate(int number);
    }
}
