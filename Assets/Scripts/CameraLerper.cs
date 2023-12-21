using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerper : MonoBehaviour, IInteract
{
    [SerializeField] GameObject ObjectToMove;
    [SerializeField] GameObject TargetToSwapTo;
    AdvancedLerpLibrary lerpLibrary;
    bool isRunning;
    private void Start() {
        lerpLibrary = AdvancedLerpLibrary.Instance;
    }

    // Uses a lerp to move the camera root to the target's position
    public void Interact() {
        if(!isRunning) {
            StartCoroutine(Lerping());
                StartCoroutine(lerpLibrary.LerpWorldPositionEasing(ObjectToMove.transform, ObjectToMove.transform.position, TargetToSwapTo.transform.position, EasingType.Expo, EasingAccents.easeIn, 1f, true));
        }
    }

    IEnumerator Lerping() {
        isRunning = true;
        yield return new WaitForSeconds(2f);
        isRunning = false;
    }
}
