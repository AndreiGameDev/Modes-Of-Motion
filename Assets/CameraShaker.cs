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
        //float elapsed = 0.0f;

        //while(elapsed < duration) {
            float x = Random.Range(-1, 1f) * magnitude;
            //transform.localPosition = new Vector3(x, originalPos.y, originalPos.z);

            Vector3 NewPosition = new Vector3(cameraHolder.localPosition.x + x, cameraHolder.localPosition.y, cameraHolder.localPosition.z);
            StartCoroutine(lerpLibrary.LerpLocalPosition(cameraHolder, cameraHolder.localPosition, NewPosition, easingType, easingAccent, duration));
            Debug.Log(x);
            //elapsed += Time.deltaTime;
            
            yield return new WaitForSeconds(duration);
        //}
        StartCoroutine(lerpLibrary.LerpLocalPosition(cameraHolder, cameraHolder.localPosition, originalPos, easingType, easingAccent, duration));
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
        StartCoroutine(Shake(0.15f, .4f));
    }
}
