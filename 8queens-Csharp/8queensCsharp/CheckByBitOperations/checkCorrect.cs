using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class checkCorrect
    {
        private ulong[] _positionVectors;
        private ulong[] _attackVectors;

        const bool foundSolution = true;    //set to false to see all solutions

        public void Find()
        {
            setupQueens();
        }

        private void displayVector(ulong queens)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++) Console.Write((queens & _positionVectors[row * 8 + col]) != 0 ? " Q " : " * ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Populate up all the possible queen's position vectors and attack vectors
        /// </summary>
        private void setupQueens()
        {
            ulong position = 0x8000000000000000;
            _positionVectors = new ulong[64];
            _attackVectors = new ulong[64];
            //-- define a position of a queen for each possible square on the board
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    _positionVectors[row * 8 + col] = position;
                    position >>= 1;
                }
            }
            //-- now compute the attack vector for a queen placed on each position on the board
            for (int row = 0; row < 8; row++)
            {
                //-- mark each square in the same row as 'attacked'
                for (int col = 0; col < 8; col++)
                {
                    //-- compute attack vector for queen placed at square: [row, col]
                    ulong attackVector = 0;

                    for (int col2 = 0; col2 < 8; col2++) attackVector |= _positionVectors[row * 8 + col2];

                    //-- mark each square in the same column as 'attacked'
                    for (int row2 = 0; row2 < 8; row2++)
                        attackVector |= _positionVectors[row2 * 8 + col];

                    //-- mark the diagonals
                    for (int i = 1; i <= 7; i++)
                    {
                        //-- do diagonals going to lower row numbers (top row is row 0)
                        if (row >= i)
                        {
                            int row1 = row - i;

                            if (col >= i)
                            {
                                int col1 = col - i;
                                attackVector |= _positionVectors[row1 * 8 + col1];
                            }
                            if (col + i < 8)
                            {
                                int col1 = col + i;
                                attackVector |= _positionVectors[row1 * 8 + col1];
                            }
                        }
                        //-- do diagonals going to higher row number (last row is row 7)
                        if (row + i < 8)
                        {
                            int row1 = row + i;
                            if (col >= i)
                            {
                                int col1 = col - i;
                                attackVector |= _positionVectors[row1 * 8 + col1];
                            }
                            if (col + i < 8)
                            {
                                int col1 = col + i;
                                attackVector |= _positionVectors[row1 * 8 + col1];
                            }
                        }
                    }
                    //-- save the attack vector for [row, col]
                    _attackVectors[row * 8 + col] = attackVector;
                }
            }
            //for (var i = 0; i < _attackVectors.Length; i++) displayVector(i.ToString(), _attackVectors[i]);
        }
    }
}