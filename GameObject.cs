/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */
using System.Collections;
using System.Collections.Generic;

namespace ConsoleGameEngine
{
    public class GameObject : Component, IEnumerable<Component>
    {

        protected Scene CurrentScene { get; }

        private readonly IEnumerable<Component> components;

        public GameObject(Scene scene)
        {
            CurrentScene = scene;
            components = new List<Component>();
        }
        public override void Start()
        {
            foreach (Component component in components)
            {
                component.Start();
            }
        }

        public override void Update()
        {
            foreach (Component component in components)
            {
                component.Update();
            }
        }

        public override void Finish()
        {
            foreach (Component component in components)
            {
                component.Finish();
            }
        }

        // Go through all components in this game object
        public IEnumerator<Component> GetEnumerator()
        {
            return components.GetEnumerator();
        }

        // Required for IEnumerable<T> implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}