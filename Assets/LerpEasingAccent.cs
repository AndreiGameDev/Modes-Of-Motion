using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpEasingAccent : MonoBehaviour
{
    CustomLerpLibrary lerpLibrary;
    private void Start() {
        lerpLibrary = GetComponent<CustomLerpLibrary>();
    }

    public void SetEasingAccentIn() {
        lerpLibrary.easingAccent = EasingAccents.easeIn;
    }

    public void SetEasingAccentOut() {
        lerpLibrary.easingAccent = EasingAccents.easeOut;
    }
    public void SetEasingAccentInOut() {
        lerpLibrary.easingAccent = EasingAccents.easeInOut;
    }
}
