using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Blocks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tetris
{
    public class BlockQueue
    {

        //The selected code initializes a private readonly array named blocks with instances of different block
        //types used in the Tetris game.
        //These block types represent different shapes that can be used in the game.
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        };

        private readonly Random random = new Random();

        public Block NextBlock { get; private set; }

        //     Initializes a new instance of the BlockQueue class.
        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }

        //     Gets a random block from the blocks array.
        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        //     Gets the next block in the queue and updates the queue with a new block.
        public Block GetAndUpdate()
        {
            Block block = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            }
            while (NextBlock.Id == block.Id);
            return block;
        }
    }
}
