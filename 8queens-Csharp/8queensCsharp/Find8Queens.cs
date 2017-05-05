using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Find8Queens
    {
        private static int _BoardSize = 8;
        private static HashSet<int>[] _Occupieds = Enumerable.Range(0, 3).Select(i => new HashSet<int>()).ToArray();//vertical, a-/de-scending diagonal
        private static Func<int, int, int>[] _GetOccupyIds = new Func<int, int, int>[] {
         (x, y) => x,
         (x, y) => x + y,
         (x, y) => x - y };

        public static List<int[]> FindAll()
        {
            var queens = new Stack<int>();
            var output = new List<int[]>();
            Action recurse = null;
            recurse = () => {
                var row = queens.Count;
                if (row == _BoardSize)
                {
                    output.Add(queens.ToArray());
                    return;
                }
                for (var col = 0; col < _BoardSize; col++)
                {
                    if (Occupy(col, row))
                    {
                        queens.Push(col);
                        recurse();
                        queens.Pop();
                        DeOccupy(col, row);
                    }
                }
            };
            recurse();
            return output;
        }
        private static bool Occupy(int col, int row)
        {
            int[] tempIds = new int[3];
            for (var i = 3; i-- > 0;)
            {
                tempIds[i] = _GetOccupyIds[i](col, row); // temp store for evt. rollback
                if (!_Occupieds[i].Add(tempIds[i]))
                {
                    while (++i < 3) _Occupieds[i].Remove(tempIds[i]);  // rollback
                    return false;
                }
            }
            return true;
        }
        private static void DeOccupy(int col, int row)
        {
            for (var i = 3; i-- > 0;) _Occupieds[i].Remove(_GetOccupyIds[i](col, row));
        }
    }
}