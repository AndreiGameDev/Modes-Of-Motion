using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vec2
{
    public float x = 0f;
    public float y = 0f;

    public Vec2() {
        x = 0f; y = 0f;
    }

    public Vec2(float a_x, float a_y) {
        x = a_x; y = a_y;
    }

    //convert from our Vec2 custom data structure to Unity's Vector3 data structure

    public Vector3 ToVector3() {
        return new Vector3(x, y, 0f);
    }

    public static Vec2 operator +(Vec2 a, Vec2 b) {
        return new Vec2(a.x + b.x, a.y + b.y);
    }
    public static Vec2 operator -(Vec2 a, Vec2 b) {
        return new Vec2(a.x - b.x, a.y - b.y);
    }

    public static Vec2 operator *(Vec2 a, Vec2 b) {
        return new Vec2(a.x * b.x, a.y * b.y);
    }
    public static Vec2 operator *(Vec2 v, float s) {
        return new Vec2(v.x * s, v.y * s);
    }
}
