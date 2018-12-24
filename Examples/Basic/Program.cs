using System;
using System.Linq;
using System.Collections.Generic;
using CoreGameEngine;
using CoreGameEngine.Components;

namespace Basic
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create scene
            ConsoleKey[] quitKeys = new ConsoleKey[] { ConsoleKey.Escape };
            Scene scene = new Scene(40, 20, new InputHandler(10, quitKeys));
            GameObject quitter = new GameObject();
            KeyObserver keyObserver = new KeyObserver(new ConsoleKey[] { ConsoleKey.Escape, ConsoleKey.DownArrow, ConsoleKey.UpArrow });
            quitter.AddComponent(keyObserver);
            quitter.AddComponent(new Quitter());
            scene.AddGameObject("quitter", quitter);
            scene.GameLoop(100);
        }
    }

    class Quitter : Component
    {
        private KeyObserver keyObserver;
        public override void Start()
        {
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
        }
        public override void Update()
        {
            foreach (ConsoleKey key in keyObserver.GetCurrentKeys())
            {
                Console.WriteLine("Key was " + key.ToString());
                if (key == ConsoleKey.Escape)
                {
                    ParentScene.Terminate();
                }
            }
        }
    }
}
