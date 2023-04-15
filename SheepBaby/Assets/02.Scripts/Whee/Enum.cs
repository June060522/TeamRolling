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
        wolf,
        rest
    }

    [System.Serializable]
    public enum State
    { 
        idle,
        act 
    };

    public enum Stat
    {
        fun,
        thirst,
        hungry,
        stress 
    };
}
