using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayManipulations.Interfaces
{
    /// <summary>
    /// Interface represent method FilterByCondition
    /// </summary>
    public interface IPredicate
    {
        bool IsPredicate(int number);
    }
}
