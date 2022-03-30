using UnityEngine;
using UnityEngine.InputSystem;

namespace com.alexlopezvega.prototype
{
    public static class UnityExtensions
    {
        // Math
        public static float Remap(this float value, float inMin, float inMax, float outMin, float outMax)
        {
            return Mathf.Lerp(outMin, outMax, Mathf.InverseLerp(inMin, inMax, value));
        }

        // Transform
        public static void Clear(this Transform transform)
        {
            foreach (Transform child in transform)
                Object.Destroy(child.gameObject);
        }

        // Input Value
        public static bool HasValue<T>(this InputValue inputValue) where T : struct => !inputValue.Get<T>().Equals(default(T));
    }
}
