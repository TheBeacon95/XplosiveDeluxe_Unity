using System;
/// <summary>
/// Defines the speed of an entity.
/// </summary>
public enum EntitySpeed {
    Slow = 1,
    Normal = 2,
    Fast = 4,
    VeryFast = 6,
}

public static class EntitySpeedExtensions {
    public static EntitySpeed Next(this EntitySpeed currentSpeed) {
        EntitySpeed[] speeds = (EntitySpeed[])Enum.GetValues(typeof(EntitySpeed));
        int currentIndex = Array.IndexOf(speeds, currentSpeed);
        if (speeds.Length > currentIndex + 1) {
            return speeds[currentIndex + 1];
        }
        else {
            return currentSpeed;
        }
    }
    public static EntitySpeed Previous(this EntitySpeed currentSpeed) {
        EntitySpeed[] speeds = (EntitySpeed[])Enum.GetValues(typeof(EntitySpeed));
        int currentIndex = Array.IndexOf(speeds, currentSpeed);
        if (currentIndex > 0) {
            return speeds[currentIndex - 1];
        }
        else {
            return currentSpeed;
        }
    }
}