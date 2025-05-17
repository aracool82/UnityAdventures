using UnityEngine;

namespace _Project16_17.Scripts
{
    public static class Utils
    {
        public static class Validator
        {
            public static bool IsValidReference(object value)
            {
                if (value != null)
                    return true;

                Debug.LogError("Reference is null");
                return false;
            }

            public static bool IsValidFLoat(float value)
            {
                if (value >= 0)
                    return true;

                Debug.LogError("Value is negative");
                return false;
            }
        }
    }
}