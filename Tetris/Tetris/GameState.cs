using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameState
    {
        private Block currentBlock;

        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();
            }
        }

        public GameGrid GameGrid { get; }
        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; private set; }

        public GameState()
        {
            GameGrid = new GameGrid(22,10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
        }

        public bool BlockFits()
        {
            foreach (Position p in CurrentBlock.TilePosition())
            {
                if (!GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }
            return true;
        }

        public void RotateBlockCW()
        {
            currentBlock.RotateCW();

            if(!BlockFits ())
            {
                currentBlock.RotateCCW();
            }
        }

        public void RotateBlockCCW()
        {
            currentBlock.RotateCCW();

            if (!BlockFits())
            {
                currentBlock.RotateCW();
            }
        }

        public void MoveBlockLeft()
        {
            currentBlock.Move(0,-1);

            if (!BlockFits())
            {
                currentBlock.Move(0, 1);
            }
        }

        public void MoveBlockRight()
        {
            currentBlock.Move(0, 1);

            if (!BlockFits())
            {
                currentBlock.Move(0, -1);
            }
        }

        private bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }

        private void PlaceBlock()
        {
            foreach(Position p in CurrentBlock.TilePosition())
            {
                GameGrid[p.Row, p.Column] = CurrentBlock.Id;
            }

            GameGrid.ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
        }

        public void MoveBlockDown()
        {
            currentBlock.Move(1, 0);

            if (!BlockFits())
            {
                currentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }


    }
}
