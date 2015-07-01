using System;
using Galaxy_Runner.EngineNS;

namespace Galaxy_Runner.GameObjects
{
	public abstract class GameObject
	{
		private Position position;
        private Position oldPosition;

        private bool isDestroyed = false;

		public GameObject (Position position)
		{
			this.Position = position;
            this.OldPosition = position;
		}

        public bool IsDestroyed
        { 
            get 
            { 
                return isDestroyed; 
            }
            set
            {
                isDestroyed = value;
            }
        }

		public Position Position 
		{
			get 
			{
				return this.position;
			}
			set 
			{
                if (position.X < 0 || position.X > Galaxy_Runner.EngineNS.Engine.width || position.Y < 0 || position.Y > Galaxy_Runner.EngineNS.Engine.height)
                {
                    //throw new PositionOutOfRangeException("value", "The position must be in range [0, width] [0, height]".);
                    throw new NotImplementedException();

                }

				this.position = value;
			}
		}

        public Position OldPosition
        {
            get
            {
                return this.oldPosition;
            }
            set
            {
                if (oldPosition.X < 0 || oldPosition.X > Galaxy_Runner.EngineNS.Engine.width || oldPosition.Y < 0 || oldPosition.Y > Galaxy_Runner.EngineNS.Engine.height)
                {
                    //throw new PositionOutOfRangeException("value", "The position must be in range [0, width] [0, height]".);
                    throw new NotImplementedException();

                }

                this.oldPosition = value;
            }
        }

        public void Destroy()
        {
            IsDestroyed = true;
        }

        public virtual void UpdatePosition()
        {
            int tmpPositionX = this.Position.X;
            int tmpPositionY = this.Position.Y;

            this.Position = new Position(tmpPositionX - 1, tmpPositionY);
            this.OldPosition = new Position(tmpPositionX, tmpPositionY);
        }

        public abstract char[,] ToPrintArray();
	}
}

