using System;
using UnityEngine;

public static class ExtensionMethods {
    public static Vector2Int Floor(this Vector2 vector) {
        return new Vector2Int((int)Math.Floor(vector.x), (int)Math.Floor(vector.y));
    }

    public static Vector2Int Ceiling(this Vector2 vector) {
        return new Vector2Int((int)Math.Ceiling(vector.x), (int)Math.Ceiling(vector.y));
    }
}
