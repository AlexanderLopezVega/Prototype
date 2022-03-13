using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.alexlopezvega.prototype
{
    public static class MathExtensions
    {
        public static float Remap(this float value, float inMin, float inMax, float outMin, float outMax)
        {
            return Mathf.Lerp(outMin, outMax, Mathf.InverseLerp(inMin, inMax, value));
        }
    }
}
