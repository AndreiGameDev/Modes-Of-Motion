using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCameraShakeUI : MonoBehaviour, IInteract
{
    [SerializeField] GameObject cameraShakeOptions;
    FirstPersonController fpsController;
    private void Start() {
        fpsController = FindObjectOfType<FirstPersonController>();
    }
    public void Interact() {
        fpsController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        if(cameraShakeOptions != null) {
            cameraShakeOptions.SetActive(true);
        }
    }
}
