// Author       : Inde Panesar
// Date         : Feb 2017
// Description  : Extension methods 
 
using System.Collections.Generic;
using System.Linq;

namespace ListManipulation.ExtensionMethods
{
    internal static class MyExtensionsMethods
    {
        /// <summary>
        ///  An extension method on IEnumerable<int> to return sub list orderd integers 
        /// </summary>
        /// <param name="IntList"></param>
        /// <returns>Returns enumerable list of an ordered group of integer list</returns>
        public static IEnumerable<IEnumerable<int>> GetIntegerGroups(this IEnumerable<int> IntList)
        {
            var ilist = new List<int>();        // create an empty integers list

            // iterate through the list and yield the list of ordered numbers
            foreach (var number in IntList)
            {
                // We have a currently active list 
                if (ilist.Count == 0 || ilist.Last() < number)
                    ilist.Add(number);
                else
                {
                    // Yield this list and 
                    yield return ilist;
                    ilist = new List<int> { number };
                }
            }
            yield return ilist;
        }
    }
}
