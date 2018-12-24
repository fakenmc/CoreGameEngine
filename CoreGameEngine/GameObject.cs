/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CoreGameEngine.Components;

namespace CoreGameEngine
{
    public class GameObject : IGameObject, IEnumerable<Component>
    {

        public Scene ParentScene { get; internal set; }

        private readonly ICollection<Component> components;

        public GameObject()
        {
            components = new List<Component>();
        }

        public void AddComponent(Component component) {
            component.ParentGameObject = this;
            components.Add(component);
        }

        public T GetComponent<T>() where T : Component
        {
            return components.First(component => component is T) as T;
        }

        public IEnumerable<T> GetComponents<T>() where T : Component
        {
            return components
                .Where(component => component is T)
                .Select((component => component as T));
        }

        public void Start()
        {
            foreach (Component component in components)
            {
                component.Start();
            }
        }

        public void Update()
        {
            foreach (Component component in components)
            {
                component.Update();
            }
        }

        public void Finish()
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
