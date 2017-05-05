using System;

namespace WindowsFormsApplication1
{
    public class Position
    {
        public static int NumberOfAttempts, NumberOfNodes, NumberOfSolutions, NumberOfQueens = 8; // n queens
        public static string AllSolution = "";
        private static Position queenAbove;
        private int line, row;
        private Position parent;

        public Position(int Line, int Row, Position Parent)
        {
            line = Line;
            row = Row;
            parent = Parent;
            NumberOfNodes++;
        }

        public void WalkThroughTree()
        {
            if (line == NumberOfQueens) // last line (=number of queens) reached: solution
            {
                //NumberOfSolutions++; // count only
                PrintSolution(this); // print solutions
                return;
            }
            for (var r = 0; r < NumberOfQueens; r++) // try all rows in next line
            {
                NumberOfAttempts++;
                queenAbove = this;
                while (queenAbove.row >= 0 && r != queenAbove.row // vertical threat?
                        && r - queenAbove.row != line + 1 - queenAbove.line // diagonal threat left?
                        && queenAbove.row - r != line + 1 - queenAbove.line) // diagonal threat right?
                    queenAbove = queenAbove.parent; // repeat check for all queens in previous lines
                if (queenAbove.line == 0) // no threat found
                    new Position(line + 1, r, this).WalkThroughTree(); // put queen on next line
            }
        }
        private static void PrintSolution(Position Node)
        {
            NumberOfSolutions++;
            while (Node.row >= 0)
            {
                AllSolution += (((char)('a' + Node.row)).ToString());
                Node = Node.parent;
            }
            AllSolution += Environment.NewLine;
        }
    }
}
