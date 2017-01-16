using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PResistance
    {
        public string Description;
        public int Value;

        public PResistance(string description, int value)
        {
            Description = description;
            Value = value;
        }
    }
}
