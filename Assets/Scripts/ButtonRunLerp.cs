using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRunLerp : MonoBehaviour, IInteract
{
    [SerializeField] GameObject target;
    CustomLerpLibrary lerpLibrary;
    private void Start() {
        lerpLibrary = target.GetComponent<CustomLerpLibrary>();
    }

    public void Interact() {
        
        lerpLibrary.LerpButton();
    }
}
