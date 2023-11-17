using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomLerp : MonoBehaviour
{
    float z;

    public void LerpButton() {
        StartCoroutine(LerpFloat());
    }

    IEnumerator LerpFloat() {
        float time = 0;
        while ( time < 1 ) {
            // t = easing function
            float t = Mathf.Pow(time, 3);
            // lerpfloat = startValue + (endValue - startVelocity) * time
            z = -5 + (5 - -5) * t;
            time += Time.deltaTime;
            yield return null;
        }
    }

    private void Update() {
        transform.position = new Vector3(0, 0, z);
    }
}
