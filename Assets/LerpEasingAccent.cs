using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpEasingAccent : MonoBehaviour
{
    public ButtonRunLerp buttonLerp;

    public void SetEasingAccentIn() {
        buttonLerp.easingAccent = EasingAccents.easeIn;
    }

    public void SetEasingAccentOut() {
        buttonLerp.easingAccent = EasingAccents.easeOut;
    }
    public void SetEasingAccentInOut() {
        buttonLerp.easingAccent = EasingAccents.easeInOut;
    }
}
