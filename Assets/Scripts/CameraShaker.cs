using System.Collections;
using UnityEngine;

public class CameraShaker : MonoBehaviour, IInteract {
    [SerializeField] Transform cameraHolder;
    AdvancedLerpLibrary lerpLibrary;
    private void Start() {
        lerpLibrary = AdvancedLerpLibrary.Instance;
    }
    // Shakes the camera and gradually dies the effect and then resets back to the original position
    public IEnumerator Shake(float duration, float positionOffset, float rotationOffsetStrength) {
        Vector3 originalPos = cameraHolder.localPosition;
        Quaternion originalRot = cameraHolder.localRotation;
        float magnitude = 1f;
        float elapsed = 0.0f;
        while(elapsed < duration) {
            float x = (Random.value -.5f) * magnitude * positionOffset;
            float y = (Random.value -.5f) * magnitude * positionOffset;
            float LerpAmount = magnitude * rotationOffsetStrength;
            Vector3 lookAtVector = lerpLibrary.LerpVectorNormal(Vector3.forward, Random.insideUnitCircle, LerpAmount);
            cameraHolder.transform.localPosition = new Vector3(cameraHolder.localPosition.x + x, cameraHolder.localPosition.y + y, cameraHolder.localPosition.z);
            cameraHolder.transform.localRotation = Quaternion.LookRotation(lookAtVector);
            elapsed += Time.deltaTime;
            magnitude = (1 - (elapsed / duration)) * (1 - (elapsed / duration));
            yield return null;
            
        }
        StartCoroutine(lerpLibrary.LerpLocalPositionEasing(cameraHolder, cameraHolder.localPosition, originalPos, EasingType.Expo, EasingAccents.easeInOut, .1f));
        cameraHolder.localRotation = originalRot;
    }

    public void Interact() {
        StopAllCoroutines();
        StartCoroutine(Shake(.5f, .1f, 0.1f));
    }
}
