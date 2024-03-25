using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Vector3Extentions
{
    public static Vector3 SetY(this Vector3 vector, float value, bool isAdditive = false)
    {
        return vector = new Vector3(value + (isAdditive ? vector.y : 0), vector.y, vector.z);
    }
    public static Vector3 SetX(this Vector3 vector, float value, bool isAdditive = false)
    {
        return vector = new Vector3(vector.x, value + (isAdditive ? vector.y : 0), vector.z);
    }
    public static Vector3 SetZ(this Vector3 vector, float value, bool isAdditive = false)
    {
        return vector = new Vector3(vector.x, vector.y, value + (isAdditive ? vector.y : 0));
    }

    public static Vector3 RandomInRange(this Vector3 value)
    {
        var x = Random.Range(-value.x, value.x);
        var y = Random.Range(-value.y, value.y);
        var z = Random.Range(-value.z, value.z);

        return new Vector3(x, y, z);
    }
    public static Vector3 Clamp(this Vector3 vector, Vector3 min, Vector3 max)
    {
        float x = Mathf.Clamp(vector.x, min.x, max.x);
        float y = Mathf.Clamp(vector.y, min.y, max.y);
        float z = Mathf.Clamp(vector.z, min.z, max.z);

        return new Vector3(x, y, z);
    }

}
