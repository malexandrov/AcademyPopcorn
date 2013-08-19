using System;

namespace AcademyPopcorn
{
    public class EngineShootingRacket : Engine
    {
        private int worldRows;
        private int worldCols;

        public EngineShootingRacket(IRenderer renderer, IUserInterface userInterface, int sleepTime, int worldRows, int worldCols)
            : base(renderer, userInterface, sleepTime)
        {
            this.worldCols = worldCols;
            this.worldRows = worldRows;
        }

        public override void MovePlayerRacketLeft()
        {
            if (playerRacket.TopLeft.Col > 1)
            {
                this.playerRacket.MoveLeft();
            }
        }

        public override void MovePlayerRacketRight()
        {
            if ((playerRacket.TopLeft.Col + playerRacket.Width) < worldCols - 1)
            {
                this.playerRacket.MoveRight();
            }
        }

        public void ShootPlayerRacket()
        {
            if (this.playerRacket is ShootingRacket)
            {
                (this.playerRacket as ShootingRacket).Shoot();
            }
        }
    }
}
