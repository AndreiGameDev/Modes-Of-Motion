using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CameraShaker : MonoBehaviour, IInteract {
    [SerializeField] Transform cameraHolder;
    [SerializeField] AnimationCurve curves;
    public IEnumerator Shake(float duration, float positionOffsetX, float positionOffsetY) {
        Vector3 originalPos = cameraHolder.localPosition;
        float magnitude = 1f;
        float elapsed = 0.0f;
        while(elapsed < duration / 2) {
            magnitude = Easing.Expo.InOut(elapsed / duration);
            float x = Random.Range(-1f, 1f) * magnitude * positionOffsetX;
            float y = Random.Range(-1f, 1f) * magnitude * positionOffsetY;
            cameraHolder.transform.localPosition = new Vector3(cameraHolder.localPosition.x + x, cameraHolder.localPosition.y + y, cameraHolder.localPosition.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        AdvancedLerpLibrary.Instance.StartCoroutine(AdvancedLerpLibrary.Instance.LerpLocalPosition(cameraHolder.transform, cameraHolder.transform.localPosition, originalPos, EasingType.Expo, EasingAccents.easeInOut, duration / 2));
        //cameraHolder.localPosition = Vector3.Lerp(cameraHolder.localPosition, originalPos, Time.deltaTime); ;
    }

    public void Interact() {
        StartCoroutine(Shake(.2f, .8f, .2f));
    }
}
