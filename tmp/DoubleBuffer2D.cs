/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */

using System;
using System.Collections;
using System.Collections.Generic;

// Classe que implementa um double buffer bidimensional de tipo genérico
public class DoubleBuffer2D<T> : IBuffer2D<T>, IEnumerable<T>
{

    // Os dois buffers
    private T[,] nextBuffer, currentBuffer;

    // Indexador, serve para ler e escrever no double buffer de forma
    // transparente
    public T this[int x, int y]
    {
        // Leitura é feita do buffer current
        get => currentBuffer[x, y];
        // Escrita é feita no buffer next
        set => nextBuffer[x, y] = value;
    }

    // Propriedades que indicam o tamanho do buffer
    public int XDim => currentBuffer.GetLength(0);
    public int YDim => currentBuffer.GetLength(1);

    // Construtor, inicializa os buffers e limpa o buffer next
    public DoubleBuffer2D(int x, int y)
    {
        currentBuffer = new T[x, y];
        nextBuffer = new T[x, y];
        Clear();
    }

    // Método que limpa o buffer next
    public void Clear()
    {
        Array.Clear(nextBuffer, 0, XDim * YDim - 1);
    }

    // Método que preenche o buffer next com o objeto indicado
    public void Fill(T obj) {
        for (int x = 0; x < XDim; x++)
            for (int y = 0; y < YDim; y++)
                nextBuffer[x, y] = obj;
    }

    // Troca os buffers, current passa a ser o antigo next e o next passa a ser
    // o antigo current
    public void Swap()
    {
        T[,] aux = currentBuffer;
        currentBuffer = nextBuffer;
        nextBuffer = aux;
    }

    // Nesta versão do DoubleBuffer2D implementamos a interface IEnumerable<T>
    // de modo a podermos percorrer os seus conteúdos usando um foreach
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

    // Método necessário para implementação de IEnumerable
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
