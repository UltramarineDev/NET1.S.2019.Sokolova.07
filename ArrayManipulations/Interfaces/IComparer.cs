namespace ArrayManipulations.Interfaces
{
    /// <summary>
    /// Interface represents method compare
    /// </summary>
    public interface IComparer
    {
        /// <summary>
        /// Compares two integers.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>integer (0,1,-1) depending on the value of input parametes and implementation details.</returns>
        int Compare(string first, string second);
    }
}
