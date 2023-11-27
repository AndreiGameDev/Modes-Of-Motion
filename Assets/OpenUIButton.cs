using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUIButton : MonoBehaviour, IInteract
{
    [SerializeField] GameObject CanvasToOpen;

    public void Interact() {
        if (CanvasToOpen != null) {
            CanvasToOpen.SetActive(true);
        }
    }
}
