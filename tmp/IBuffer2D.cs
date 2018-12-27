
/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */

// Interface que representa mundos 2D genéricos
public interface IBuffer2D<T>
{
    int XDim { get; }
    int YDim { get; }
    T this[int x, int y] { get; }
}
