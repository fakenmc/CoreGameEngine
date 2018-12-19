/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */
using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleGameEngine
{
    // Implements a generic bidimensional double buffer
    public class DoubleBuffer2D<T> : IBuffer2D<T>, IEnumerable<T>
    {

        // The two buffers
        private T[,] nextBuffer, currentBuffer;

              // Go through all elements in the current buffer
        public IEnumerator<T> GetEnumerator()
        {
            for (int y = 0; y < YDim; y++)
            {
                for (int x = 0; x < XDim; x++)
                {
                    yield return currentBuffer[x, y];
                }
            }
        }

        // Required for IEnumerable<T> implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
  // Indexer, transparently reads and writes to the double buffer
              // Go through all elements in the current buffer
        public IEnumerator<T> GetEnumerator()
        {
            for (int y = 0; y < YDim; y++)
            {
                for (int x = 0; x < XDim; x++)
                {
                    yield return currentBuffer[x, y];
                }
            }
        }

        // Required for IEnumerable<T> implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
  public T this[int x, int y]
              // Go through all elements in the current buffer
        public IEnumerator<T> GetEnumerator()
        {
            for (int y = 0; y < YDim; y++)
            {
                for (int x = 0; x < XDim; x++)
                {
                    yield return currentBuffer[x, y];
                }
            }
        }

        // Required for IEnumerable<T> implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
  {
              // Go through all elements in the current buffer
        public IEnumerator<T> GetEnumerator()
        {
            for (int y = 0; y < YDim; y++)
            {
                for (int x = 0; x < XDim; x++)
                {
                    yield return currentBuffer[x, y];
                }
            }
        }

        // Required for IEnumerable<T> implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
      // Reading is done from the current buffer
              // Go through all elements in the current buffer
        public IEnumerator<T> GetEnumerator()
        {
            for (int y = 0; y < YDim; y++)
            {
                for (int x = 0; x < XDim; x++)
                {
                    yield return currentBuffer[x, y];
                }
            }
        }

        // Required for IEnumerable<T> implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
      get => currentBuffer[x, y];
              // Go through all elements in the current buffer
        public IEnumerator<T> GetEnumerator()
        {
            for (int y = 0; y < YDim; y++)
            {
                for (int x = 0; x < XDim; x++)
                {
                    yield return currentBuffer[x, y];
                }
            }
        }

        // Required for IEnumerable<T> implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
      // Writing is done to the next buffer
              // Go through all elements in the current buffer
        public IEnumerator<T> GetEnumerator()
        {
            for (int y = 0; y < YDim; y++)
            {
                for (int x = 0; x < XDim; x++)
                {
                    yield return currentBuffer[x, y];
                }
            }
        }

        // Required for IEnumerable<T> implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
      set => nextBuffer[x, y] = value;
              // Go through all elements in the current buffer
        public IEnumerator<T> GetEnumerator()
        {
            for (int y = 0; y < YDim; y++)
            {
                for (int x = 0; x < XDim; x++)
                {
                    yield return currentBuffer[x, y];
                }
            }
        }

        // Required for IEnumerable<T> implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
  }

        // These properties determine the size of the buffer
        public int XDim => currentBuffer.GetLength(0);
        public int YDim => currentBuffer.GetLength(1);

        /        // Go through all elements in the current buffer
        public IEnumerator<T> GetEnumerator()
        {
            for (int y = 0; y < YDim; y++)
            {
                for (int x = 0; x < XDim; x++)
                {
                    yield return currentBuffer[x, y];
                }
            }
        }

        // Required for IEnumerable<T> implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
/ Constructor, initializes the buffers and cleans the next buffer
        p        // Go through all elements in the current buffer
        public IEnumerator<T> GetEnumerator()
        {
            for (int y = 0; y < YDim; y++)
            {
                for (int x = 0; x < XDim; x++)
                {
                    yield return currentBuffer[x, y];
                }
            }
        }

        // Required for IEnumerable<T> implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
ublic DoubleBuffer2D(int x, int y)
        {        // Go through all elements in the current buffer
        public IEnumerator<T> GetEnumerator()
        {
            for (int y = 0; y < YDim; y++)
            {
                for (int x = 0; x < XDim; x++)
                {
                    yield return currentBuffer[x, y];
                }
            }
        }

        // Required for IEnumerable<T> implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

                 // Go through all elements in the current buffer
        public IEnumerator<T> GetEnumerator()
        {
            for (int y = 0; y < YDim; y++)
            {
                for (int x = 0; x < XDim; x++)
                {
                    yield return currentBuffer[x, y];
                }
            }
        }

        // Required for IEnumerable<T> implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
   currentBuffer = new T[x, y];
                 // Go through all elements in the current buffer
        public IEnumerator<T> GetEnumerator()
        {
            for (int y = 0; y < YDim; y++)
            {
                for (int x = 0; x < XDim; x++)
                {
                    yield return currentBuffer[x, y];
                }
            }
        }

        // Required for IEnumerable<T> implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
   nextBuffer = new T[x, y];
                 // Go through all elements in the current buffer
        public IEnumerator<T> GetEnumerator()
        {
            for (int y = 0; y < YDim; y++)
            {
                for (int x = 0; x < XDim; x++)
                {
                    yield return currentBuffer[x, y];
                }
            }
        }

        // Required for IEnumerable<T> implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
   Clear();
        }

        // Cleans the next buffer
        public void Clear()
        {
            Array.Clear(nextBuffer, 0, XDim * YDim);
        }

        public void Clear(T clearValue)
        {
            for (int i = 0; i < nextBuffer.GetLength(0); i++)
            {
                for (int j = 0; j < nextBuffer.GetLength(1); j++)
                {
                    nextBuffer[i, j] = clearValue;
                }
            }
        }

        // Swaps buffers: current is now the next buffer and vice-versa
        public void Swap()
        {
            T[,] aux = currentBuffer;
            currentBuffer = nextBuffer;
            nextBuffer = aux;
        }

        // Go through all elements in the current buffer
        public IEnumerator<T> GetEnumerator()
        {
            for (int y = 0; y < YDim; y++)
            {
                for (int x = 0; x < XDim; x++)
                {
                    yield return currentBuffer[x, y];
                }
            }
        }

        // Required for IEnumerable<T> implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}