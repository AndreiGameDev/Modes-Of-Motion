using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleTransformsUI : MonoBehaviour {
    [SerializeField] Toggle positionToggle;
    [SerializeField] Toggle rotationToggle;
    [SerializeField] Toggle scaleToggle;
    public ButtonRunLerp buttonLerp;

    // We check when enabled for the values so we can have a matching UI of the button lerp
    private void OnEnable() {
        positionToggle.isOn = buttonLerp.moveObject;
        rotationToggle.isOn = buttonLerp.rotateObject;
        scaleToggle.isOn = buttonLerp.scaleObject;
    }


    // Buttons which well toggle on and off booleans
    public void TogglePosition(bool toggle) {
        buttonLerp.moveObject = toggle;
    }

    public void ToggleRotation(bool toggle) {
        buttonLerp.rotateObject = toggle;
    }

    public void ToggleScale(bool toggle) {
        buttonLerp.scaleObject = toggle;
    }
}
