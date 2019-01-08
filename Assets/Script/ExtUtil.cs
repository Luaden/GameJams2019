using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// useful extension method
/// </summary>
public static class ExtUtil
{
    public static float sign()
    {
        return Random.value < .5 ? 1 : -1;
    }

    public static Vector2 RandomUnitVector2()
    {
        float f = Random.value;
        return new Vector2(sign() * f, sign() * (Mathf.Abs(f) - 1));
    }
}
