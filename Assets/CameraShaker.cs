using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShaker : MonoBehaviour {
    bool lerping;
    public IEnumerator Shake(float duration, float magnitude) {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;

        while(elapsed < magnitude) {
            float x = Random.Range(-1, 1f) * magnitude;
            transform.localPosition = new Vector3(x, originalPos.y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
    }

    IEnumerator Lerp() {
        lerping = true;
        float time = 0;
        while(time < 1) {
            float percentage = 0;

            time += Time.deltaTime;
            yield return null;

        }
        lerping = false;
    }
}
