using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpEasingOptions : MonoBehaviour
{
    CustomLerpLibrary lerpLibrary;
    private void Start() {
        lerpLibrary = GetComponent<CustomLerpLibrary>();
    }
    public void SetEasingOptionSine() {
        lerpLibrary.easeFunction = EasingFunction.Sines;
    }

    public void SetEasingOptionCubic() {
        lerpLibrary.easeFunction = EasingFunction.Cubic;
    }
    public void SetEasingOptionQuint() {
        lerpLibrary.easeFunction = EasingFunction.Quint;
    }
    public void SetEasingOptionElastic() {
        lerpLibrary.easeFunction = EasingFunction.Elastic;
    }
    public void SetEasingOptionQuadratic() {
        lerpLibrary.easeFunction = EasingFunction.Quadratic;
    }
    public void SetEasingOptionQuart() {
        lerpLibrary.easeFunction = EasingFunction.Quart;
    }
    public void SetEasingOptionExpo() {
        lerpLibrary.easeFunction = EasingFunction.Expo;
    }
    public void SetEasingOptionBack() {
        lerpLibrary.easeFunction = EasingFunction.Back;
    }
    public void SetEasingOptionBounce() {
        lerpLibrary.easeFunction = EasingFunction.Bounce;
    }
}
