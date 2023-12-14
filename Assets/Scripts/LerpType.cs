using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpType
{
    Vector3 Lerp(Vector3 a_A, Vector3 a_B, float a_t) {
        return a_t * a_B + (1 - a_t) * a_A;
    }

    public Vector3 QuadBezier(Vector3 a_A, Vector3 a_B, Vector3 a_C, float a_t) {
        //lerp from the first point to the second
        Vector3 mid1 = Lerp(a_A, a_B, a_t);
        //lerp from the second point to the third
        Vector3 mid2 = Lerp(a_B, a_C, a_t);

        //return the lerp from the two intermediate points
        return Lerp(mid1, mid2, a_t);
    }

    public Vector3 HermiteSpline(Vector3 point0, Vector3 point1, Vector3 tangent0, Vector3 tangent1, float t) {
        float tsq = t * t;
        float tcub = tsq * t;

        // First point
        float h00 = 2 * tcub - 3 * tsq + 1;
        // Second Point
        float h01 = -2 * tcub + 3 * tsq;
        // First tangent
        float h10 = tcub - 2 * tsq + t;
        // Second Tangent
        float h11 = tcub - tsq;

        Vector3 point = h00 * point0 + h10 * tangent0 + h01 * point1 + h11 * tangent1;

        return point;
    }

    public Vector3 CardinalSpline(Vector3 point0, Vector3 point1, Vector3 point2, float a, float t) {
        Vector3 tangent0 = (point1 - point0) *a;
        Vector3 tangent1 = (point2 - point1) *a;

        float tsq = t * t;
        float tcub = tsq * t;

        float h00 = 2 * tcub - 3 * tsq + 1;
        float h01 = -2 * tcub + 3 * tsq;
        float h10 = tcub - 2 * tsq + t;
        float h11 = tcub - tsq;

        Vector3 point = h00 * point0 + h10 * tangent0 + h01 * point1 + h11 * tangent1;
        return point;
    }


}
