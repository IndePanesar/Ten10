// Author       : Inde Panesar
// Date         : Feb 2017
// Description  : ListManipulation library

using ListManipulation.ExtensionMethods;
using System.Collections.Generic;
using System.Linq;

namespace ListManipulation.Library
{
    public class ListManipulation
    {
        /// <summary>
        /// Function to return largest orderd sublist from a list of random integers
        /// </summary>
        public List<int> GetLargestOrderList(int[] p_Type)
        {
            var largest_order = new List<int>();
            if (p_Type.Length == 0)
                return largest_order;

            var groupeditems = p_Type.GetIntegerGroups().ToList();
            var giOrdered = groupeditems.OrderByDescending(gg => gg.Count()).ToList();
            return (List<int>)giOrdered.FirstOrDefault();
        }
    }
}
