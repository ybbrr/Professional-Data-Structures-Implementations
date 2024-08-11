using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Benin Shared Özelliklerimin dizini. (Buradaki özelliği Heap için kullandım.)
using DataStructures.Shared;
//Benim Set'imin dizini
using DataStructures.Set;

namespace Apps
{
    public class SetExamples
    {
        public static void SetExample_01()
        {
            var disjointset = new DisjointSet<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, });

            disjointset.Union(5, 6);
            disjointset.Union(1, 2);
            disjointset.Union(0, 2);

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Find({i}) = {disjointset.FindSet(i)}");
            }
        }
    }
}
