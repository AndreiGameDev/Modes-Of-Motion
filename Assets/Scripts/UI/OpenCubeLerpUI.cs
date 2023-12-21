using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCubeLerpUI : MonoBehaviour, IInteract
{
    [SerializeField] GameObject CanvasToOpen;
    [SerializeField]LerpEasingAccent easingAccentUI;
    [SerializeField]ToggleTransformsUI transformLockUI;
    [SerializeField] ButtonRunLerp buttonLerp;
    FirstPersonController fpsController;
    private void Start() {
        fpsController = FindObjectOfType<FirstPersonController>();
    }

    // Opens UI and disabled player controlls and shows cursor
    public void Interact() {
        fpsController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        if (CanvasToOpen != null) {
            transformLockUI.buttonLerp = buttonLerp;
            easingAccentUI.buttonLerp = buttonLerp;
            CanvasToOpen.SetActive(true);
        }
    }
}
