﻿using ArrayManipulations.Interfaces;

namespace Test_cases.JaggedSort
{
    public class DescendingByMinSorter : MaxMinElement, IIntComparer
    {
        public int Compare(int[] first, int[] second)
        {
            if (FindMin(first) == FindMin(second))
            {
                return 0;
            }

            return FindMin(first) > FindMin(second) ? -1 : 1;
        }
    }
}
