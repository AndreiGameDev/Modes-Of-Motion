using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomLerpLibrary : MonoBehaviour {
    [SerializeField]bool lerping;   
    //InitializingVariables
    Vector3 lerpPos;
    Vector3 lerpRotation;
    Vector3 lerpScale;

    //Position
    Vector3 startPos;
    [SerializeField] Transform endPosTransform;
    Vector3 endPos;
    //Rotation
    Vector3 startRot;
    [SerializeField] Vector3 endRot;
    //Size
    Vector3 startScale;
    [SerializeField]Vector3 endSize;
    //Setting Easing Properties
    public EasingFunction easeFunction;
    public EasingAccents easingAccent;
    //Changing Properties Bools
    public bool canChangePosition;
    public bool canChangeRotation;
    public bool canChangeSize;
    private void Awake() {
        startPos = transform.position;
        startRot = transform.eulerAngles;
        startScale = transform.localScale;
        endPos = endPosTransform.position;
    }
    public static float LerpFloat(float startValue, float endValue, float t) {
        return (startValue + (endValue - startValue) * t);
    }
    public static Vector3 LerpVector(Vector3 startPoint, Vector3 endPoint, float t) {
        return startPoint + (endPoint - startPoint) * t;
    }
    public static float InverseLerpFloat(float startValue, float endValue, float t) {
        if(startValue != endValue) {
            return Mathf.Clamp01((t - startValue) / (endValue - startValue));
        } else {
            return 0.0f;
        }
    }

    IEnumerator Lerp() {
        lerping = true;
        float time = 0;
        while (time < 1) {
            float percentage = 0;
            switch(easeFunction) {
                case EasingFunction.Sines:
                    if(easingAccent == EasingAccents.easeIn) {
                        percentage = Easing.Sines.In(time);
                    } else if(easingAccent == EasingAccents.easeOut) {
                        percentage = Easing.Sines.Out(time);
                    } else if(easingAccent == EasingAccents.easeInOut) {
                        percentage = Easing.Sines.InOut(time);
                    }
                    break;
                case EasingFunction.Cubic:
                    if(easingAccent == EasingAccents.easeIn) {
                        percentage = Easing.Cubic.In(time);
                    } else if(easingAccent == EasingAccents.easeOut) {
                        percentage = Easing.Cubic.Out(time);
                    } else if(easingAccent == EasingAccents.easeInOut) {
                        percentage = Easing.Cubic.InOut(time);
                    }
                    break;
                case EasingFunction.Quint:
                    if(easingAccent == EasingAccents.easeIn) {
                        percentage = Easing.Quint.In(time);
                    } else if(easingAccent == EasingAccents.easeOut) {
                        percentage = Easing.Quint.Out(time);
                    } else if(easingAccent == EasingAccents.easeInOut) {
                        percentage = Easing.Quint.InOut(time);
                    }
                    break;
                case EasingFunction.Elastic:
                    if(easingAccent == EasingAccents.easeIn) {
                        percentage = Easing.Elastic.In(time);
                    } else if(easingAccent == EasingAccents.easeOut) {
                        percentage = Easing.Elastic.Out(time);
                    } else if(easingAccent == EasingAccents.easeInOut) {
                        percentage = Easing.Elastic.InOut(time);
                    }
                    break;
                case EasingFunction.Quadratic:
                    if(easingAccent == EasingAccents.easeIn) {
                        percentage = Easing.Quadratic.In(time);
                    } else if(easingAccent == EasingAccents.easeOut) {
                        percentage = Easing.Quadratic.Out(time);
                    } else if(easingAccent == EasingAccents.easeInOut) {
                        percentage = Easing.Quadratic.InOut(time);
                    }
                    break;
                case EasingFunction.Quart:
                    if(easingAccent == EasingAccents.easeIn) {
                        percentage = Easing.Quart.In(time);
                    } else if(easingAccent == EasingAccents.easeOut) {
                        percentage = Easing.Quart.Out(time);
                    } else if(easingAccent == EasingAccents.easeInOut) {
                        percentage = Easing.Quart.InOut(time);
                    }
                    break;
                case EasingFunction.Expo:
                    if(easingAccent == EasingAccents.easeIn) {
                        percentage = Easing.Expo.In(time);
                    } else if(easingAccent == EasingAccents.easeOut) {
                        percentage = Easing.Expo.Out(time);
                    } else if(easingAccent == EasingAccents.easeInOut) {
                        percentage = Easing.Expo.InOut(time);
                    }
                    break;
                case EasingFunction.Back:
                    if(easingAccent == EasingAccents.easeIn) {
                        percentage = Easing.Back.In(time);
                    } else if(easingAccent == EasingAccents.easeOut) {
                        percentage = Easing.Back.Out(time);
                    } else if(easingAccent == EasingAccents.easeInOut) {
                        percentage = Easing.Back.InOut(time);
                    }
                    break;
                case EasingFunction.Bounce:
                    if(easingAccent == EasingAccents.easeIn) {
                        percentage = Easing.Bounce.In(time);
                    } else if(easingAccent == EasingAccents.easeOut) {
                        percentage = Easing.Bounce.Out(time);
                    } else if(easingAccent == EasingAccents.easeInOut) {
                        percentage = Easing.Bounce.InOut(time);
                    }
                    break;
            }

            if(canChangePosition) {
                lerpPos = LerpVector(startPos, endPos, percentage);
            }
            if(canChangeRotation) {
                lerpRotation = LerpVector(startRot, endRot, percentage);
            }
            if(canChangeSize) {
                lerpScale = LerpVector(startScale, endSize, percentage);
            }
            time += Time.deltaTime;
            yield return null;

        }
        lerping = false;
        yield return new WaitForSeconds(1);
        transform.position = startPos;
        transform.eulerAngles = startRot;
        transform.localScale = startScale;
    }

    public void LerpButton() {
        if(lerping == false) {
            StartCoroutine(Lerp());
        }
    }
}
public enum EasingFunction{
    Sines,
    Cubic,
    Quint,
    Elastic,
    Quadratic,
    Quart,
    Expo,
    Back,
    Bounce
}
public enum EasingAccents {
    easeIn, 
    easeOut, 
    easeInOut
}