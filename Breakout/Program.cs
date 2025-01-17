﻿using DIKUArcade;
using DIKUArcade.GUI;

namespace Breakout {
    class Program {
        static void Main(string[] args) {
            var windowArgs = new WindowArgs() { Title = "Breakout v1.0" };
            var game = new Game(windowArgs);
            game.Run();
        }
    }
}
