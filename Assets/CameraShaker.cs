using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShaker : MonoBehaviour, IInteract {
    bool lerping;
    [SerializeField] Transform cameraHolder;
    AdvancedLerpLibrary lerpLibrary;
    public EasingType easingType;
    public EasingAccents easingAccent;
    private void Start() {
        lerpLibrary = AdvancedLerpLibrary.Instance;
    }
    public IEnumerator Shake(float duration, float magnitude) {
        Vector3 originalPos = cameraHolder.localPosition;
        float elapsed = 0.0f;
        float frameSpeed = Time.deltaTime;

        while(elapsed < duration) {
            ////next position based on perlin noise
            //Vector3 nextPos = (Mathf.PerlinNoise(time * Speed, time * Speed * 2) - 0.5f) * Amount.x * transform.right * Curve.Evaluate(1f - time / Duration) +
            //          (Mathf.PerlinNoise(time * Speed * 2, time * Speed) - 0.5f) * Amount.y * transform.up * Curve.Evaluate(1f - time / Duration);
            ////Vector3 nextFoV = (Mathf.PerlinNoise(time * Speed * 2, time * Speed * 2) - 0.5f) * Amount.z * Curve.Evaluate(1f - time / Duration);

            ////Camera.fieldOfView += (nextFoV - lastFoV);
            //Camera.transform.Translate(DeltaMovement ? (nextPos - lastPos) : nextPos);
            //StartCoroutine
            //lastPos = nextPos;
            ////lastFoV = nextFoV;




            float x = Random.Range(-1, 1f) * magnitude;
            //transform.localPosition = new Vector3(x, originalPos.y, originalPos.z);
            Vector3 NewPosition = new Vector3(cameraHolder.localPosition.x + x, cameraHolder.localPosition.y, cameraHolder.localPosition.z);
            Debug.Log(frameSpeed);
            StartCoroutine(lerpLibrary.LerpLocalPosition(cameraHolder, cameraHolder.localPosition, NewPosition, easingType, easingAccent, duration * Time.deltaTime, false));
            elapsed += Time.deltaTime;
            
            yield return null;
        }
        StartCoroutine(lerpLibrary.LerpLocalPosition(cameraHolder, cameraHolder.localPosition, originalPos, easingType, easingAccent, duration * Time.deltaTime, false));
        //transform.localPosition = originalPos;
    }

    //public IEnumerator Shake(float magnitude) {
    //    Vector3 originalPos = cameraHolder.localPosition;
    //    float x = Random.Range(-1,1f) * magnitude;
    //    Vector3 NewPosition = new Vector3(cameraHolder.localPosition.x + x, cameraHolder.localPosition.y, cameraHolder.localPosition.z);
    //    StartCoroutine(lerpLibrary.LocalVector3LerpEasing(cameraHolder, cameraHolder.localPosition, NewPosition, PropertyToChange.Position, easingType, easingAccent, false));
    //    yield return new WaitForSecondsRealtime(1);
    //    StartCoroutine(lerpLibrary.LocalVector3LerpEasing(cameraHolder, cameraHolder.localPosition, originalPos, PropertyToChange.Position, easingType, easingAccent, false));
    //}
    public void Interact() {
        StartCoroutine(Shake(0.15f, 5f));
    }
}
