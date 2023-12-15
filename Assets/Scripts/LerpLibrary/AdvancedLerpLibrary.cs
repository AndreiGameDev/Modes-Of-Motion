using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AdvancedLerpLibrary : MonoBehaviour {
    private static AdvancedLerpLibrary instance;
    public static AdvancedLerpLibrary Instance {
        get {
            return instance;
        }
    }

    private void Awake() {
        instance = this;
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
    public Vector3 LerpVectorEasing(Vector3 startVector,  Vector3 endVector, float t, EasingType easingType, EasingAccents easingAccent) {
        float percentage = 0;
        switch(easingType) {
            case EasingType.Sines:
                switch(easingAccent) {
                    case EasingAccents.easeIn:
                        percentage = Easing.Sines.In(t);
                        break;
                    case EasingAccents.easeOut:
                        percentage = Easing.Sines.Out(t);
                        break;
                    case EasingAccents.easeInOut:
                        percentage = Easing.Sines.InOut(t);
                        break;
                }
                break;
            case EasingType.Cubic:
                switch(easingAccent) {
                    case EasingAccents.easeIn:
                        percentage = Easing.Cubic.In(t);
                        break;
                    case EasingAccents.easeOut:
                        percentage = Easing.Cubic.Out(t);
                        break;
                    case EasingAccents.easeInOut:
                        percentage = Easing.Cubic.InOut(t);
                        break;
                }
                break;
            case EasingType.Quint:
                switch(easingAccent) {
                    case EasingAccents.easeIn:
                        percentage = Easing.Quint.In(t);
                        break;
                    case EasingAccents.easeOut:
                        percentage = Easing.Quint.Out(t);
                        break;
                    case EasingAccents.easeInOut:
                        percentage = Easing.Quint.InOut(t);
                        break;
                }
                break;
            case EasingType.Elastic:
                switch(easingAccent) {
                    case EasingAccents.easeIn:
                        percentage = Easing.Elastic.In(t);
                        break;
                    case EasingAccents.easeOut:
                        percentage = Easing.Elastic.Out(t);
                        break;
                    case EasingAccents.easeInOut:
                        percentage = Easing.Elastic.InOut(t);
                        break;
                }
                break;
            case EasingType.Quadratic:
                switch(easingAccent) {
                    case EasingAccents.easeIn:
                        percentage = Easing.Quadratic.In(t);
                        break;
                    case EasingAccents.easeOut:
                        percentage = Easing.Quadratic.Out(t);
                        break;
                    case EasingAccents.easeInOut:
                        percentage = Easing.Quadratic.InOut(t);
                        break;
                }
                break;
            case EasingType.Quart:
                switch(easingAccent) {
                    case EasingAccents.easeIn:
                        percentage = Easing.Quart.In(t);
                        break;
                    case EasingAccents.easeOut:
                        percentage = Easing.Quart.Out(t);
                        break;
                    case EasingAccents.easeInOut:
                        percentage = Easing.Quart.InOut(t);
                        break;
                }
                break;

            case EasingType.Expo:
                switch(easingAccent) {
                    case EasingAccents.easeIn:
                        percentage = Easing.Expo.In(t);
                        break;
                    case EasingAccents.easeOut:
                        percentage = Easing.Expo.Out(t);
                        break;
                    case EasingAccents.easeInOut:
                        percentage = Easing.Expo.InOut(t);
                        break;
                }
                break;
            case EasingType.Back:
                switch(easingAccent) {
                    case EasingAccents.easeIn:
                        percentage = Easing.Back.In(t);
                        break;
                    case EasingAccents.easeOut:
                        percentage = Easing.Back.Out(t);
                        break;
                    case EasingAccents.easeInOut:
                        percentage = Easing.Back.InOut(t);
                        break;
                }
                break;
            case EasingType.Bounce:
                switch(easingAccent) {
                    case EasingAccents.easeIn:
                        percentage = Easing.Bounce.In(t);
                        break;
                    case EasingAccents.easeOut:
                        percentage = Easing.Bounce.Out(t);
                        break;
                    case EasingAccents.easeInOut:
                        percentage = Easing.Bounce.InOut(t);
                        break;
                }
                break;
        }
        return LerpVector(startVector, endVector, percentage);
    }

    public Quaternion LerpQuaternionEasing(Quaternion startQuaternion, Quaternion endQuaternion, float t, EasingType easingType, EasingAccents easingAccent) {
        
        float percentage = 0;
        switch(easingType) {
            case EasingType.Sines:
                switch(easingAccent) {
                    case EasingAccents.easeIn:
                        percentage = Easing.Sines.In(t);
                        break;
                    case EasingAccents.easeOut:
                        percentage = Easing.Sines.Out(t);
                        break;
                    case EasingAccents.easeInOut:
                        percentage = Easing.Sines.InOut(t);
                        break;
                }
                break;
            case EasingType.Cubic:
                switch(easingAccent) {
                    case EasingAccents.easeIn:
                        percentage = Easing.Cubic.In(t);
                        break;
                    case EasingAccents.easeOut:
                        percentage = Easing.Cubic.Out(t);
                        break;
                    case EasingAccents.easeInOut:
                        percentage = Easing.Cubic.InOut(t);
                        break;
                }
                break;
            case EasingType.Quint:
                switch(easingAccent) {
                    case EasingAccents.easeIn:
                        percentage = Easing.Quint.In(t);
                        break;
                    case EasingAccents.easeOut:
                        percentage = Easing.Quint.Out(t);
                        break;
                    case EasingAccents.easeInOut:
                        percentage = Easing.Quint.InOut(t);
                        break;
                }
                break;
            case EasingType.Elastic:
                switch(easingAccent) {
                    case EasingAccents.easeIn:
                        percentage = Easing.Elastic.In(t);
                        break;
                    case EasingAccents.easeOut:
                        percentage = Easing.Elastic.Out(t);
                        break;
                    case EasingAccents.easeInOut:
                        percentage = Easing.Elastic.InOut(t);
                        break;
                }
                break;
            case EasingType.Quadratic:
                switch(easingAccent) {
                    case EasingAccents.easeIn:
                        percentage = Easing.Quadratic.In(t);
                        break;
                    case EasingAccents.easeOut:
                        percentage = Easing.Quadratic.Out(t);
                        break;
                    case EasingAccents.easeInOut:
                        percentage = Easing.Quadratic.InOut(t);
                        break;
                }
                break;
            case EasingType.Quart:
                switch(easingAccent) {
                    case EasingAccents.easeIn:
                        percentage = Easing.Quart.In(t);
                        break;
                    case EasingAccents.easeOut:
                        percentage = Easing.Quart.Out(t);
                        break;
                    case EasingAccents.easeInOut:
                        percentage = Easing.Quart.InOut(t);
                        break;
                }
                break;

            case EasingType.Expo:
                switch(easingAccent) {
                    case EasingAccents.easeIn:
                        percentage = Easing.Expo.In(t);
                        break;
                    case EasingAccents.easeOut:
                        percentage = Easing.Expo.Out(t);
                        break;
                    case EasingAccents.easeInOut:
                        percentage = Easing.Expo.InOut(t);
                        break;
                }
                break;
            case EasingType.Back:
                switch(easingAccent) {
                    case EasingAccents.easeIn:
                        percentage = Easing.Back.In(t);
                        break;
                    case EasingAccents.easeOut:
                        percentage = Easing.Back.Out(t);
                        break;
                    case EasingAccents.easeInOut:
                        percentage = Easing.Back.InOut(t);
                        break;
                }
                break;
            case EasingType.Bounce:
                switch(easingAccent) {
                    case EasingAccents.easeIn:
                        percentage = Easing.Bounce.In(t);
                        break;
                    case EasingAccents.easeOut:
                        percentage = Easing.Bounce.Out(t);
                        break;
                    case EasingAccents.easeInOut:
                        percentage = Easing.Bounce.InOut(t);
                        break;
                }
                break;
        }
        return Quaternion.Lerp(startQuaternion, endQuaternion, percentage);
    }

    public IEnumerator LerpWorldPosition(Transform targetTransform, Vector3 startVector, Vector3 endVector, EasingType easingType, EasingAccents easingAccent, float duration = 1f, bool ResetToStartAfterDone = false) {
        float time = 0;
        while(time < duration) {
            targetTransform.position = LerpVectorEasing(startVector, endVector, time, easingType, easingAccent);
            time += Time.deltaTime / duration;
            yield return null;
        }
        if(ResetToStartAfterDone == true) {
            yield return new WaitForSeconds(duration);
            targetTransform.position = startVector;
        }
    }

    public IEnumerator LerpLocalPosition(Transform targetTransform, Vector3 startVector, Vector3 endVector, EasingType easingType, EasingAccents easingAccent, float duration, bool ResetToStartAfterDone = false) {
        float time = 0;
        while(time < 1) {
            targetTransform.localPosition = LerpVectorEasing(startVector, endVector, time, easingType, easingAccent);
            time += Time.deltaTime / duration;
            yield return null;
        }
        if(ResetToStartAfterDone == true) {
            yield return new WaitForSeconds(duration);
            targetTransform.localPosition = startVector;
        }
    }

    public IEnumerator LerpLocalScale(Transform targetTransform, Vector3 startVector, Vector3 endVector, EasingType easingType, EasingAccents easingAccent, float duration = 1f, bool ResetToStartAfterDone = false) {
        float time = 0;
        while(time < duration) {
            targetTransform.localScale = LerpVectorEasing(startVector, endVector, time, easingType, easingAccent);
            time += Time.deltaTime / duration;
            yield return null;
        }
        if(ResetToStartAfterDone == true) {
            yield return new WaitForSeconds(duration);
            targetTransform.localScale = startVector;
        }
    }
    public IEnumerator QuaternionLerpEasing(Transform targetTransform, Quaternion startQuaternion, Quaternion endQuaternion, EasingType easingType, EasingAccents easingAccent, float duration = 1f, bool ResetToStartAfterDone = false) {
        float time = 0;
        while(time < 1) {
            targetTransform.rotation = LerpQuaternionEasing(startQuaternion, endQuaternion, time, easingType, easingAccent);
            time += Time.deltaTime / duration;
            yield return null;
        }
        if(ResetToStartAfterDone == true) {
            yield return new WaitForSeconds(1);
            targetTransform.rotation = startQuaternion;
        }
    }

    //public IEnumerator BezierCurve(Transform targetTransform, Vector3 startVector, Vector3 endVector, EasingType easingType, EasingAccents easingAccent, float duration = 1f, bool ResetToStartAfterDone = false) {

    //}
}
public enum EasingType {
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