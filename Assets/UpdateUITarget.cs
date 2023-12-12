using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUITarget : MonoBehaviour
{
    [SerializeField] LerpEasingAccent easingAccentUI;
    [SerializeField] GameObject objectOwned;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            Debug.Log("Contact");
            //easingAccentUI.target = objectOwned;

        }
    }
}
