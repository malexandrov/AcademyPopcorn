using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    public class GameWorld
    {
        private static int WorldRows = 23;
        private static int WorldCols = 40;
        private static int RacketLength = 6;
       
        private int startRow = 3;
        private int startCol = 2;
        private int endCol = WorldCols - 2;
        private int wallStartRow = 0;
        
        public int GetRows
        {
            get { return WorldRows; }
        }

        public int GetCols
        {
            get { return WorldCols; }
        }

        public int GetRacketLength
        {
            get { return RacketLength; }
        }

        public void Initialize(Engine engine)
        {
            // Initialize ceiling
            for (int i = wallStartRow; i < WorldCols; i++)
            {
                IndestructibleBlock ceiling = new IndestructibleBlock(new MatrixCoords(wallStartRow, i));
                engine.AddObject(ceiling);
            }

            // Initialize indestructible walls
            for (int i = wallStartRow + 1; i < WorldRows; i++)
            {
                IndestructibleBlock leftWallBlock = new IndestructibleBlock(new MatrixCoords(i, 0));
                IndestructibleBlock rightWallBlock = new IndestructibleBlock(new MatrixCoords(i, GetCols - 1));
                engine.AddObject(leftWallBlock);
                engine.AddObject(rightWallBlock);
            }

            // Initialize exploding Blocks
            for (int i = startCol; i < endCol; i++)
            {
                if (i % 7 == 0)
                {
                    Block explBlock = new ExplodingBlock(new MatrixCoords(startRow + 1, i));
                    engine.AddObject(explBlock);
                }
            }

            // Initialize Unpassable Blocks
            for (int i = startCol; i < endCol; i++)
            {
                if (i % 5 == 0)
                {
                    Block unpassableBlock = new UnpassableBlock(new MatrixCoords(WorldRows / 2, i));
                    engine.AddObject(unpassableBlock);
                }
            }

            // Gift Blocks
            for (int i = startCol; i < endCol; i++)
            {
                if (i % 4 == 0)
                {
                    Block currBlock = new GiftBlock(new MatrixCoords(startRow - 1, i));
                    engine.AddObject(currBlock);
                }
            }

            // Original Blocks
            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));
                engine.AddObject(currBlock);
            }

            // Original Ball

            //ball theball = new ball(new matrixcoords(worldrows / 2, 0),
            //new matrixcoords(-1, 1));

            //engine.addobject(theball);

            // Meteorite Ball Test

            //Ball theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));
            //engine.AddObject(theBall);


            // Unstoppable Ball Test

            UnstoppableBall theBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));
            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, GetCols / 2), RacketLength);
            engine.AddObject(theRacket);
        }
    }
}
