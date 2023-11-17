using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimpleLerp : MonoBehaviour {
    bool lerping;
    Vector3 lerpPos;
    Vector3 lerpRotation;
    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 endPos;

    [SerializeField] Vector3 startRot;
    [SerializeField] Vector3 endRot;

    [SerializeField] float duration;

    [SerializeField] TextMeshProUGUI text;
    float progressText;
    public enum eases {
        easeInSine, easeOutSine, easeOutBounce
    }

    public eases myEase;

    public void LerpButton() {
        if (lerping == false) {
            StartCoroutine(LerpFloat(myEase));
        }
    }

    IEnumerator LerpFloat(eases ease) {
        lerping = true;
        float time = 0;
        while (time < 1) {
            float percentage = 0; // % through the animation
            if (ease == eases.easeInSine) {
                percentage = Easing.Sines.In(time);
            } else if (ease == eases.easeOutSine) {
                percentage = Easing.Sines.Out(time);
            } else if (ease == eases.easeOutBounce) {
                percentage = Easing.Bounce.Out(time);
            }

            lerpPos = new Vector3(Lerp(startPos.x, endPos.x, percentage), Lerp(startPos.y, endPos.y, percentage), Lerp(startPos.z, endPos.z, percentage));
            lerpRotation = new Vector3(Lerp(startRot.x, endRot.x, percentage), Lerp(startRot.y, endRot.y, percentage), Lerp(startRot.z, endRot.z, percentage));
            progressText = InverseLerping(0, 1f, percentage);
            time += Time.deltaTime;
            yield return null;
        }
        lerping = false;
    }


    public static float Lerp(float startValue, float endValue, float t) {
        return (startValue + (endValue - startValue) * t);
    }
    public static float InverseLerping(float startValue, float endValue, float t) {
        if (startValue != endValue) {
            return Mathf.Clamp01((t - startValue) / (endValue - startValue));
        } else {
            return 0.0f;
        }
    }

    private void Update() {
        transform.position = lerpPos;
        transform.eulerAngles = lerpRotation;
        text.text = "Progress: " + Mathf.Round(progressText * 100) + "%";
    }
}
