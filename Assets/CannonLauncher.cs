using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLauncher : MonoBehaviour {
    public float launchVelocity = 10f;
    public float launchAngle = 30f;
    public float gravity = -9.81f;
    public Vector3 v3InitialVelocity;
    public Vector3 v3CurrentVelocity;
    private Vector3 v3Acceleration;
    private float airTime = 0f;
    private float xDisplacement = 0f;
    bool simulate = false;

    private List<Vector3> pathPoints;
    private int simulationSteps = 30;

    void CalculatePath() {
        Vector3 launchPos = transform.position;
        pathPoints.Add(launchPos);
        for(int i =0; i<= simulationSteps; i++) {
            float simTime = ( i/ (float)simulationSteps) * airTime;
            //suvat formula for displacement: s = ut + 1/2at^2
            Vector3 displacement = v3InitialVelocity * simTime + v3Acceleration * simTime * simTime * 0.5f;
            Vector3 drawPoint = launchPos + displacement;
            pathPoints.Add(drawPoint);
        }
    }

    void DrawPath() {
        for(int i=0; i< pathPoints.Count-1; i++) {
            Debug.DrawLine(pathPoints[i], pathPoints[i+1], Color.green);
        }
    }
    void Start () {
        //initualise path vector for drawing
        pathPoints = new List<Vector3>();
        CalculateProjectile();
        CalculatePath();
    }

    void CalculateProjectile() {
        //Work out velocity as vector quantity
        v3InitialVelocity.x = launchVelocity * Mathf.Cos(launchAngle * Mathf.Deg2Rad);
        v3InitialVelocity.y = launchVelocity * Mathf.Sin(launchAngle * Mathf.Deg2Rad);
        //gravity as a vector
        v3Acceleration = new Vector3(0f, gravity, 0f);

        //calculate total time in air
        float finalYvel = 0f;
        airTime = 2f * (finalYvel - v3InitialVelocity.y) / v3Acceleration.y;

        //calculate total distance travelled in x
        xDisplacement = airTime * v3InitialVelocity.x;
    }

    private void FixedUpdate() {
        if (simulate) {
            Vector3 currentPos = transform.position;
            //work out current velocity
            v3CurrentVelocity += v3Acceleration * Time.fixedDeltaTime;
            //work out displacement
            Vector3 displacement = v3CurrentVelocity * Time.fixedDeltaTime;
            currentPos += displacement;
            transform.position = currentPos;
        }
    }

    private void Update() {
        if(!simulate) {
            pathPoints = new List<Vector3>();
            CalculateProjectile();
            CalculatePath();
        }
        DrawPath();
        if ((Input.GetKeyDown(KeyCode.Space) && !simulate)) {
            simulate = true;
            v3CurrentVelocity = v3InitialVelocity;
        }
        if ((Input.GetKeyDown(KeyCode.R))) {
            simulate = false;
            transform.position = Vector3.zero;
        }
    }
}
