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
                StartCoroutine(lerpLibrary.Vector3LerpEasing(ObjectToMove.transform, ObjectToMove.transform.position, TargetPosition.position, PropertyToChange.Position, easingType, easingAccent, true));

            }
            if(rotateObject) {
                StartCoroutine(lerpLibrary.Vector3LerpEasing(ObjectToMove.transform, ObjectToMove.transform.eulerAngles, TargetPosition.eulerAngles, PropertyToChange.Rotation, easingType, easingAccent, true));

            }
            if(scaleObject) {
                StartCoroutine(lerpLibrary.Vector3LerpEasing(ObjectToMove.transform, ObjectToMove.transform.localScale, TargetPosition.localScale, PropertyToChange.Scale, easingType, easingAccent, true));

            }
        }
    }

    IEnumerator Lerping() {
        isRunning = true;
        yield return new WaitForSeconds(2f);
        isRunning = false;
    }
}
