namespace Tetris.Infrastructure
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
		public BlockStore BlockStore { get; }
		public bool GameOver { get; private set; }

		public GameState()
		{
			GameGrid = new GameGrid(22, 10);
			BlockStore = new BlockStore();
			CurrentBlock = BlockStore.GetAndUpdate();
		}

		private bool BlockFits()
		{
			foreach (Position p in CurrentBlock.TilePositions())
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
			CurrentBlock.RotateClockwise();

			if (!BlockFits())
			{
				CurrentBlock.RotateAntiClockwise();
			}
		}

		public void RotateBlockACW()
		{
			CurrentBlock.RotateAntiClockwise();

			if (!BlockFits())
			{
				CurrentBlock.RotateClockwise();
			}
		}

		public void MoveBlockLeft()
		{
			CurrentBlock.Move(0, -1);

			if (!BlockFits())
			{
				CurrentBlock.Move(0, 1);
			}
		}

		public void MoveBlockRight()
		{
			CurrentBlock.Move(0, 1);

			if (!BlockFits())
			{
				CurrentBlock.Move(0, -1);
			}
		}
	}
}
