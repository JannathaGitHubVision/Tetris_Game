
namespace Tetris
{
    public class Position
    {
        // Position class to store the row and column of a block
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }


    }
}
