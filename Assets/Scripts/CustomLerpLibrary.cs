using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomLerpLibrary : MonoBehaviour {
    bool lerping;   
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
    Vector3 startSize;
    [SerializeField]Vector3 endSize;
    //UI Elements
    [SerializeField] TextMeshProUGUI text;
    float progressText;
    //Setting Easing Properties
    public EasingFunction easeFunction;
    public EasingType myEase;
    //Changing Properties Bools
    public bool canChangePosition;
    public bool canChangeRotation;
    public bool canChangeSize;
    private void Awake() {
        startPos = transform.position;
        startRot = transform.eulerAngles;
        startSize = transform.localScale;
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

    IEnumerator Lerp(EasingType ease) {
        lerping = true;
        float time = 0;
        while (time < 1) {
            float percentage = 0;
            switch(easeFunction) {
                case EasingFunction.Sines:
                    if(ease == EasingType.easeIn) {
                        percentage = Easing.Sines.In(time);
                    } else if(ease == EasingType.easeOut) {
                        percentage = Easing.Sines.Out(time);
                    } else if(ease == EasingType.easeInOut) {
                        percentage = Easing.Sines.InOut(time);
                    }
                    break;
                case EasingFunction.Cubic:
                    if(ease == EasingType.easeIn) {
                        percentage = Easing.Cubic.In(time);
                    } else if(ease == EasingType.easeOut) {
                        percentage = Easing.Cubic.Out(time);
                    } else if(ease == EasingType.easeInOut) {
                        percentage = Easing.Cubic.InOut(time);
                    }
                    break;
                case EasingFunction.Quint:
                    if(ease == EasingType.easeIn) {
                        percentage = Easing.Quint.In(time);
                    } else if(ease == EasingType.easeOut) {
                        percentage = Easing.Quint.Out(time);
                    } else if(ease == EasingType.easeInOut) {
                        percentage = Easing.Quint.InOut(time);
                    }
                    break;
                case EasingFunction.Elastic:
                    if(ease == EasingType.easeIn) {
                        percentage = Easing.Elastic.In(time);
                    } else if(ease == EasingType.easeOut) {
                        percentage = Easing.Elastic.Out(time);
                    } else if(ease == EasingType.easeInOut) {
                        percentage = Easing.Elastic.InOut(time);
                    }
                    break;
                case EasingFunction.Quadratic:
                    if(ease == EasingType.easeIn) {
                        percentage = Easing.Quadratic.In(time);
                    } else if(ease == EasingType.easeOut) {
                        percentage = Easing.Quadratic.Out(time);
                    } else if(ease == EasingType.easeInOut) {
                        percentage = Easing.Quadratic.InOut(time);
                    }
                    break;
                case EasingFunction.Quart:
                    if(ease == EasingType.easeIn) {
                        percentage = Easing.Quart.In(time);
                    } else if(ease == EasingType.easeOut) {
                        percentage = Easing.Quart.Out(time);
                    } else if(ease == EasingType.easeInOut) {
                        percentage = Easing.Quart.InOut(time);
                    }
                    break;
                case EasingFunction.Expo:
                    if(ease == EasingType.easeIn) {
                        percentage = Easing.Expo.In(time);
                    } else if(ease == EasingType.easeOut) {
                        percentage = Easing.Expo.Out(time);
                    } else if(ease == EasingType.easeInOut) {
                        percentage = Easing.Expo.InOut(time);
                    }
                    break;
                case EasingFunction.Back:
                    if(ease == EasingType.easeIn) {
                        percentage = Easing.Back.In(time);
                    } else if(ease == EasingType.easeOut) {
                        percentage = Easing.Back.Out(time);
                    } else if(ease == EasingType.easeInOut) {
                        percentage = Easing.Back.InOut(time);
                    }
                    break;
                case EasingFunction.Bounce:
                    if(ease == EasingType.easeIn) {
                        percentage = Easing.Bounce.In(time);
                    } else if(ease == EasingType.easeOut) {
                        percentage = Easing.Bounce.Out(time);
                    } else if(ease == EasingType.easeInOut) {
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
                lerpScale = LerpVector(startSize, endSize, percentage);
            }
            progressText = InverseLerpFloat(0, 1f, percentage);
            time += Time.deltaTime;
            yield return null;

        }
        lerping = false;
    }

    public void LerpButton() {
        if(lerping == false) {
            StartCoroutine(Lerp(myEase));
        }
    }

    private void Update() {
        if(canChangePosition) {
            transform.position = lerpPos;
        }
        if(canChangeRotation) {
            transform.eulerAngles = lerpRotation;
        }
        if(canChangeSize) {
            transform.localScale = lerpScale;
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
public enum EasingType {
    easeIn, 
    easeOut, 
    easeInOut
}