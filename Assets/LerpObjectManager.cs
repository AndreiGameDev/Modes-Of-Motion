using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LerpObjectManager : MonoBehaviour
{
    CustomLerpLibrary lerpLibrary;

    public void SummonEvent() {
        lerpLibrary.LerpButton();
    }
}
