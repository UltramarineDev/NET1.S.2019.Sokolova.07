namespace ArrayManipulations.Interfaces
{
    /// <summary>
    /// Interface represents method FilterByCondition
    /// </summary>
    public interface IPredicate
    {
        /// <summary>
        /// Condition method
        /// </summary>
        /// <param name="number">input integer number</param>
        /// <returns>true if condition is correct, false otherwise</returns>
        bool IsPredicate(int number);
    }
}
