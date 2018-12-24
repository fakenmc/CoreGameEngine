using System;
using System.Linq;
using System.Collections.Generic;
using CoreGameEngine;

namespace Basic
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create scene
            ConsoleKey[] quitKeys = new ConsoleKey[] { ConsoleKey.Escape };
            Scene scene = new Scene(40, 20, new InputHandler(10, quitKeys));

            // Create quitter object
            GameObject quitter = new GameObject();
            KeyObserver quitSceneKeyListener = new KeyObserver(new ConsoleKey[]
                { ConsoleKey.Escape });
            quitter.AddComponent(quitSceneKeyListener);
            quitter.AddComponent(new Quitter());
            scene.AddGameObject("quitter", quitter);

            // Create player object
            GameObject player = new GameObject();
            KeyObserver playerKeyListener = new KeyObserver(new ConsoleKey[]
                { ConsoleKey.DownArrow, ConsoleKey.UpArrow, ConsoleKey.RightArrow, ConsoleKey.LeftArrow });
            player.AddComponent(playerKeyListener);
            player.AddComponent(new Position(10f, 10f));
            player.AddComponent(new Player());
            scene.AddGameObject("player", player);

            scene.GameLoop(100);
        }
    }

}
