using ArrayManipulations.Interfaces;

namespace ArrayManipulations.JaggedSort
{
    public class DescendingBySumSorter : SumOfElements, IIntComparer
    {
        public int Compare(int[] first, int[] second)
        {
            if (Sum(first) == Sum(second))
            {
                return 0;
            }

            return Sum(first) > Sum(second) ? -1 : 1;
        }
    }
}
