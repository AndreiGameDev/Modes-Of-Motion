using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMover : MonoBehaviour, IInteract
{
    [SerializeField] GameObject target;
    Rigidbody targetRb;
    [SerializeField] GameObject target1;
    Rigidbody targetRb1;
    [SerializeField] GameObject target2;
    Rigidbody targetRb2;
    [SerializeField] GameObject target3;
    Rigidbody targetRb3;
    public float force = 10f;
    [SerializeField] bool canUse = true;
    private void Start() {
        targetRb = target.GetComponent<Rigidbody>();
        targetRb1 = target1.GetComponent<Rigidbody>();
        targetRb2 = target2.GetComponent<Rigidbody>();
        targetRb3 = target3.GetComponent<Rigidbody>();
    }
    public void Interact() {
        if (canUse) {
            StartCoroutine(ResetPosition());
            // Adds force to all the different rigidbodies
            targetRb.AddForce(target.transform.forward * force, ForceMode.Impulse);
            targetRb1.AddForce(target.transform.forward * force, ForceMode.VelocityChange);
            StartCoroutine(ConstantForce(targetRb2, ForceMode.Force));
            StartCoroutine(ConstantForce(targetRb3, ForceMode.Acceleration));
        }
        
    }

    // Coroutine Timer to apply constant force over a certain time
    IEnumerator ConstantForce(Rigidbody rb, ForceMode forceMode) {
        float elapsed = 0.0f;
        float time = 1f;
        while (elapsed < time) {
            rb.AddForce(target.transform.forward * force, forceMode);
            elapsed += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    // Resets Position
    IEnumerator ResetPosition() {
        canUse = false;
        Quaternion originalRot = target.transform.rotation;
        Vector3 targetInitialPos = target.transform.position;
        Quaternion originalRot1 = target1.transform.rotation;
        Vector3 targetInitialPos1 = target1.transform.position;
        Quaternion originalRot2 = target2.transform.rotation;
        Vector3 targetInitialPos2 = target2.transform.position;
        Quaternion originalRot3 = target3.transform.rotation;
        Vector3 targetInitialPos3 = target3.transform.position;
        yield return new WaitForSeconds(3f);
        target.transform.position = targetInitialPos;
        target.transform.rotation = originalRot;
        target1.transform.position = targetInitialPos1;
        target1.transform.rotation = originalRot1;
        target2.transform.position = targetInitialPos2;
        target2.transform.rotation = originalRot2;
        target3.transform.position = targetInitialPos3;
        target3.transform.rotation = originalRot3;
        canUse = true;
    }
}
