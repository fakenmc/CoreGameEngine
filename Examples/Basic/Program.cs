using System;
using System.Collections.Generic;
using CoreGameEngine;
using CoreGameEngine.Components;

namespace basic
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create scene
            Scene scene = new Scene(40, 20, new InputHandler(10));
            GameObject quitter = new GameObject();
            KeyObserver keyObserver = new KeyObserver(new ConsoleKey[] { ConsoleKey.Escape});
            quitter.AddComponent(keyObserver);
            scene.AddGameObject("quitter", quitter);
            scene.GameLoop(100);
        }
    }
}
