namespace Tetris
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffSet { get; }
        public abstract int Id { get; }

        private int rotationState;
        private Position offSet;

        // Rotate the block.
        public Block()
        {
            offSet = new Position(StartOffSet.Row, StartOffSet.Column);
        }

        // Rotate the block.
        // The block is rotated based on certain degrees
        public IEnumerable<Position> TilePosition()
        {
            foreach(Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offSet.Row, p.Column + offSet.Column);
            }
        }

        // Making sure to move the block to the 90% degree clockwise
        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        // Making sure to move the block to the 90% degree counter clockwise
        public void RotateCCW()
        {
            if(rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        // Move the block to the given row and column
        public void Move(int rows, int columns)
        {
            offSet.Row += rows;
            offSet.Column += columns;   
        }

        public void Reset()
        {
            rotationState = 0;
            offSet.Row = StartOffSet.Row;
            offSet.Column = StartOffSet.Column;
        }
    }
}
