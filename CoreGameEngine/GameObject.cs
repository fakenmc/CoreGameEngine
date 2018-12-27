/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CoreGameEngine
{
    public class GameObject : IGameObject, IEnumerable<Component>
    {

        public Scene ParentScene { get; internal set; }

        public string Name { get; }

        public bool IsRenderable => containsSprite && containsPosition;

        public bool IsCollidable => containsPosition && containsCollider;

        private static readonly Type[] oneOfAKind = new Type[]
        {
            typeof(Position),
            typeof(KeyObserver),
            typeof(ConsoleSprite),
            typeof(AbstractCollider)
        };

        private bool containsSprite, containsPosition, containsCollider;

        private readonly ICollection<Component> components;

        public GameObject(string name)
        {
            Name = name;
            components = new List<Component>();
        }

        public void AddComponent(Component component)
        {

            // Check for one of a kind components
            foreach (Type componentType in oneOfAKind)
            {
                if (componentType.IsInstanceOfType(component)
                    && GetComponent(componentType) != null)
                {
                    throw new InvalidOperationException(
                        $"Game objects can only have one {componentType.Name} "
                        + "component");
                }
            }

            if (component is AbstractCollider) containsCollider = true;
            else if (component is Position) containsPosition = true;
            else if (component is ConsoleSprite) containsSprite = true;

            component.ParentGameObject = this;
            components.Add(component);
        }

        public T GetComponent<T>() where T : Component
        {
            // TODO: Use dictionary for one of a kind game objects
            // to speed up this search

            return components.FirstOrDefault(component => component is T) as T;
        }

        public Component GetComponent(Type type)
        {
            // TODO: Use dictionary for one of a kind game objects
            // to speed up this search

            return components.FirstOrDefault(
                component => type.IsInstanceOfType(component));
        }

        public IEnumerable<T> GetComponents<T>() where T : Component
        {
            // TODO: Use dictionary for one of a kind game objects
            // to speed up this search

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
