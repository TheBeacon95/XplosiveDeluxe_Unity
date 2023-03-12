using System;
using UnityEngine;

public static class ExtensionMethods {
    public static Vector2Int Floor(this Vector2 vector) {
        return new Vector2Int((int)Math.Floor(vector.x), (int)Math.Floor(vector.y));
    }

    public static Vector2Int Ceiling(this Vector2 vector) {
        return new Vector2Int((int)Math.Ceiling(vector.x), (int)Math.Ceiling(vector.y));
    }

    public static Vector2Int Round(this Vector2 vector) {
        return new Vector2Int((int)Math.Round(vector.x), (int)Math.Round(vector.y));
    }

    public static Vector2 ToVector2(this Vector3 vector) {
        return new Vector2(vector.x, vector.y);
    }

    public static Vector3 ToVector3(this Vector2Int vector) {
        return new Vector3(vector.x, vector.y);
    }
}
