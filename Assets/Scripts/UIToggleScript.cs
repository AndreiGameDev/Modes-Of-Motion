using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToggleScript : MonoBehaviour
{
    FirstPersonController fpsController;

    private void Start() {
        fpsController = FindObjectOfType<FirstPersonController>();
    }

    public void TogglePlayerMode() {
        fpsController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
