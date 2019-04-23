using ArrayManipulations.Interfaces;

namespace ArrayManipulations.JaggedSort
{
    public class AscendingByMaxSorter : MaxMinElement, IIntComparer
    {
        public int Compare(int[] first, int[] second)
        {
            if (FindMax(first) == FindMax(second))
            {
                return 0;
            }

            return FindMax(first) > FindMax(second) ? 1 : -1;
        }
    }
}
