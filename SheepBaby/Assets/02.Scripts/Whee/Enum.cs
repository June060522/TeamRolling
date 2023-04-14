using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enum
{
    [System.Serializable]
    public enum Act
    {
        water,
        eat,
        bell,
        cut,
    }

    [System.Serializable]
    public enum State
    { 
        idle,
        act 
    };
}
