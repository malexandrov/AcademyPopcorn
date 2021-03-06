﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        static void Main(string[] args)
        {
            GameWorld world = new GameWorld();
            IRenderer renderer = new ConsoleRenderer(world.GetRows, world.GetCols);
            IUserInterface keyboard = new KeyboardInterface();
            EngineShootingRacket gameEngine = new EngineShootingRacket(renderer, keyboard, 150, world.GetRows, world.GetCols);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };
            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };
            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };
            keyboard.OnEscPressed += (sender, eventInfo) =>
            {
                Process.GetCurrentProcess().Kill();
            };
            world.Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
