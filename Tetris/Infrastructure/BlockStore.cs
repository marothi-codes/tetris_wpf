using System;

using Tetris.ViewModels;

namespace Tetris.Infrastructure
{
	public class BlockStore
	{
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

		public BlockStore()
		{
			NextBlock = RandomBlock();
		}

		private readonly Random random = new();

		public Block NextBlock { get; private set; }

		private Block RandomBlock()
		{
			return blocks[random.Next(blocks.Length)];
		}

		public Block GetAndUpdate()
		{
			Block block = NextBlock;

			do
			{
				NextBlock = RandomBlock();
			}
			while (block.Id == NextBlock.Id);

			return block;
		}
	}
}
