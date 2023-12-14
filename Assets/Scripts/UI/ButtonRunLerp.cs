using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRunLerp : MonoBehaviour, IInteract {
    [SerializeField] GameObject ObjectToMove;
    [SerializeField] Transform TargetPosition;
    [SerializeField] EasingType easingType;
    public EasingAccents easingAccent;
    public bool moveObject;
    public bool rotateObject;
    public bool scaleObject;
    AdvancedLerpLibrary lerpLibrary;
    bool isRunning;
    private void Start() {
        lerpLibrary = AdvancedLerpLibrary.Instance;
    }

    public void Interact() {
        if(!isRunning) {
            StartCoroutine(Lerping());
            if(moveObject) {
                StartCoroutine(lerpLibrary.LerpWorldPosition(ObjectToMove.transform, ObjectToMove.transform.position, TargetPosition.position,easingType, easingAccent, 1f, true));

            }
            if(rotateObject) {
                StartCoroutine(lerpLibrary.QuaternionLerpEasing(ObjectToMove.transform, ObjectToMove.transform.rotation, TargetPosition.rotation, easingType, easingAccent, true));
            }
            if(scaleObject) {
                StartCoroutine(lerpLibrary.LerpLocalScale(ObjectToMove.transform, ObjectToMove.transform.localScale, TargetPosition.localScale,easingType, easingAccent, 1f, true));
            }
        }
    }

    IEnumerator Lerping() {
        isRunning = true;
        yield return new WaitForSeconds(2f);
        isRunning = false;
    }
}
