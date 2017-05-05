using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class CheckByBitOperations
    {
        private ulong[,] _attackMaps = new ulong[8, 8];
        private List<ulong> _solutions = new List<ulong>();

        const bool foundSolution = false;//set to false to see all solutions

        public void Find()
        {
            setupAttackMaps();
            var b = solve(0, 0, 0);
            //for (var i = 0; i < _solutions.Count; i++) displayVector(_solutions[i]);
            Console.WriteLine(_solutions.Count.ToString());
        }

        private void displayMap(ulong map, string header = "")
        {
            Console.WriteLine(header);
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++) Console.Write((map & bitPosition(row, col)) != 0 ? " Q " : " * ");
                Console.WriteLine();
            }
        }
        /// <summary> returns a 64-bit-int, with one bit set, representing the choosen square on chessboard </summary>
        private ulong bitPosition(int row, int col) { return 0x8000000000000000 >> (row << 3) + col; }

        private bool solve(int row, ulong queens, ulong attacks)
        {
            if (row == 8) { _solutions.Add(queens); return foundSolution; }
            for (var col = 0; col < 8; col++)
            {
                ulong tryal = bitPosition(row, col);
                if ((attacks & tryal) == 0)
                { // check tryal against attacks
                    if (solve(row + 1, queens | tryal, attacks | _attackMaps[row, col])) return foundSolution;
                }
            }
            return false;   //-- no tryal succeeded on this row; backup
        }

        //-- compute the attack-Maps for each position a queen may be placed
        private void setupAttackMaps()
        {
            // the 4 lines a queen attacks can be identified by either row, column, Sum of both, Difference of both is constant
            Func<int, int, int[]> getLineIds = (row, col) => new int[] { row, col, row + col, row - col };
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    ulong map = 0;
                    var keyIds = getLineIds(row, col);
                    for (var y = 8; y-- > 0;) for (var x = 8; x-- > 0;)
                        {
                            if (getLineIds(y, x).Where((id, i) => keyIds[i] == id).Any())
                            {
                                map |= bitPosition(y, x);
                            }
                        }
                    _attackMaps[row, col] = map;
                }
            }
            //for (var i = 0; i < _attackVectors.Length; i++) displayVector(_attackVectors[i], i.ToString());
        }


    }
}