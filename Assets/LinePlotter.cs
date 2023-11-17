using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LinePlotter : MonoBehaviour
{
    private List<Vec2> points;
    public float x1 = 0f;
    public float y1 = 1f;
    public float m = 1f;
    public float c = 0f;
    [Range(-5, 5)]
    public int p = 1;
    private float calculateY(float y1, float x, float x1, float m, float c) {
        //return m * (x-x1) + c + y1;

        return m * (x-x1) + c + y1;
    }

    void PlotPoints() {
        // As we are using this in editor it is possible to get here prior to Start being called
        if(points == null) {
            points = new List<Vec2>();
        }

        points.Clear();
        float x = -10f;
        for(float xPos = x; xPos < 10f; xPos += 0.2f) {
            points.Add(new Vec2(xPos, calculateY(y1, xPos, x1, m, c)));
        }
    }
    private void Start() {
        points = new List<Vec2>();
        PlotPoints();
    }

    private void OnDrawGizmos() {
        //If we have any points in the list do logic:
        if (points != null) {

            // Set gizmo colour to red
            Gizmos.color = Color.red;

            //for each point in the list draw a line to the next point in the list
            for (int i = 0; i < points.Count - 1; i++) {
                Gizmos.DrawLine(points[i].ToVector3(), points[i + 1].ToVector3());
            }
        }
    }

    private void OnValidate() {
        PlotPoints();
        Debug.Log("Re-populating gizmo positions");
    }

    
}
