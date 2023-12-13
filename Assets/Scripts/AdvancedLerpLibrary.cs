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

    public IEnumerator Vector3LerpEasing(Transform targetTransform, Vector3 startVector, Vector3 endVector, PropertyToChange propertyToChange, EasingType easingType, EasingAccents easingAccent, bool ResetToStartAfterDone = false) {
        float time = 0;
        while(time < 1) {
            float percentage = 0;
            switch(easingType) {
                case EasingType.Sines:
                    switch(easingAccent) {
                        case EasingAccents.easeIn:
                            percentage = Easing.Sines.In(time);
                            break;
                        case EasingAccents.easeOut:
                            percentage = Easing.Sines.Out(time);
                            break;
                        case EasingAccents.easeInOut:
                            percentage = Easing.Sines.InOut(time);
                            break;
                    }
                    break;
                case EasingType.Cubic:
                    switch(easingAccent) {
                        case EasingAccents.easeIn:
                            percentage = Easing.Cubic.In(time);
                            break;
                        case EasingAccents.easeOut:
                            percentage = Easing.Cubic.Out(time);
                            break;
                        case EasingAccents.easeInOut:
                            percentage = Easing.Cubic.InOut(time);
                            break;
                    }
                    break;
                case EasingType.Quint:
                    switch(easingAccent) {
                        case EasingAccents.easeIn:
                            percentage = Easing.Quint.In(time);
                            break;
                        case EasingAccents.easeOut:
                            percentage = Easing.Quint.Out(time);
                            break;
                        case EasingAccents.easeInOut:
                            percentage = Easing.Quint.InOut(time);
                            break;
                    }
                    break;
                case EasingType.Elastic:
                    switch(easingAccent) {
                        case EasingAccents.easeIn:
                            percentage = Easing.Elastic.In(time);
                            break;
                        case EasingAccents.easeOut:
                            percentage = Easing.Elastic.Out(time);
                            break;
                        case EasingAccents.easeInOut:
                            percentage = Easing.Elastic.InOut(time);
                            break;
                    }
                    break;
                case EasingType.Quadratic:
                    switch(easingAccent) {
                        case EasingAccents.easeIn:
                            percentage = Easing.Quadratic.In(time);
                            break;
                        case EasingAccents.easeOut:
                            percentage = Easing.Quadratic.Out(time);
                            break;
                        case EasingAccents.easeInOut:
                            percentage = Easing.Quadratic.InOut(time);
                            break;
                    }
                    break;
                case EasingType.Quart:
                    switch(easingAccent) {
                        case EasingAccents.easeIn:
                            percentage = Easing.Quart.In(time);
                            break;
                        case EasingAccents.easeOut:
                            percentage = Easing.Quart.Out(time);
                            break;
                        case EasingAccents.easeInOut:
                            percentage = Easing.Quart.InOut(time);
                            break;
                    }
                    break;

                case EasingType.Expo:
                    switch(easingAccent) {
                        case EasingAccents.easeIn:
                            percentage = Easing.Expo.In(time);
                            break;
                        case EasingAccents.easeOut:
                            percentage = Easing.Expo.Out(time);
                            break;
                        case EasingAccents.easeInOut:
                            percentage = Easing.Expo.InOut(time);
                            break;
                    }
                    break;
                case EasingType.Back:
                    switch(easingAccent) {
                        case EasingAccents.easeIn:
                            percentage = Easing.Back.In(time);
                            break;
                        case EasingAccents.easeOut:
                            percentage = Easing.Back.Out(time);
                            break;
                        case EasingAccents.easeInOut:
                            percentage = Easing.Back.InOut(time);
                            break;
                    }
                    break;
                case EasingType.Bounce:
                    switch(easingAccent) {
                        case EasingAccents.easeIn:
                            percentage = Easing.Bounce.In(time);
                            break;
                        case EasingAccents.easeOut:
                            percentage = Easing.Bounce.Out(time);
                            break;
                        case EasingAccents.easeInOut:
                            percentage = Easing.Bounce.InOut(time);
                            break;
                    }
                    break;
            }
            switch(propertyToChange) {
                case PropertyToChange.Position:
                    targetTransform.position = LerpVector(startVector, endVector, percentage);
                    break;
                case PropertyToChange.Scale:
                    targetTransform.localScale = LerpVector(startVector, endVector, percentage);
                    break;
            }
            time += Time.deltaTime;
            yield return null;
        }
        if(ResetToStartAfterDone == true) {
            yield return new WaitForSeconds(1);
            switch(propertyToChange) {
                case PropertyToChange.Position:
                    targetTransform.position = startVector;
                    break;
                case PropertyToChange.Scale:
                    targetTransform.localScale = startVector;
                    break;
            }
        }
    }

    public IEnumerator QuaternionLerpEasing(Transform targetTransform, Quaternion startQuaternion, Quaternion endQuaternion, EasingType easingType, EasingAccents easingAccent, bool ResetToStartAfterDone = false) {
        float time = 0;
        while(time < 1) {
            float percentage = 0;
            switch(easingType) {
                case EasingType.Sines:
                    switch(easingAccent) {
                        case EasingAccents.easeIn:
                            percentage = Easing.Sines.In(time);
                            break;
                        case EasingAccents.easeOut:
                            percentage = Easing.Sines.Out(time);
                            break;
                        case EasingAccents.easeInOut:
                            percentage = Easing.Sines.InOut(time);
                            break;
                    }
                    break;
                case EasingType.Cubic:
                    switch(easingAccent) {
                        case EasingAccents.easeIn:
                            percentage = Easing.Cubic.In(time);
                            break;
                        case EasingAccents.easeOut:
                            percentage = Easing.Cubic.Out(time);
                            break;
                        case EasingAccents.easeInOut:
                            percentage = Easing.Cubic.InOut(time);
                            break;
                    }
                    break;
                case EasingType.Quint:
                    switch(easingAccent) {
                        case EasingAccents.easeIn:
                            percentage = Easing.Quint.In(time);
                            break;
                        case EasingAccents.easeOut:
                            percentage = Easing.Quint.Out(time);
                            break;
                        case EasingAccents.easeInOut:
                            percentage = Easing.Quint.InOut(time);
                            break;
                    }
                    break;
                case EasingType.Elastic:
                    switch(easingAccent) {
                        case EasingAccents.easeIn:
                            percentage = Easing.Elastic.In(time);
                            break;
                        case EasingAccents.easeOut:
                            percentage = Easing.Elastic.Out(time);
                            break;
                        case EasingAccents.easeInOut:
                            percentage = Easing.Elastic.InOut(time);
                            break;
                    }
                    break;
                case EasingType.Quadratic:
                    switch(easingAccent) {
                        case EasingAccents.easeIn:
                            percentage = Easing.Quadratic.In(time);
                            break;
                        case EasingAccents.easeOut:
                            percentage = Easing.Quadratic.Out(time);
                            break;
                        case EasingAccents.easeInOut:
                            percentage = Easing.Quadratic.InOut(time);
                            break;
                    }
                    break;
                case EasingType.Quart:
                    switch(easingAccent) {
                        case EasingAccents.easeIn:
                            percentage = Easing.Quart.In(time);
                            break;
                        case EasingAccents.easeOut:
                            percentage = Easing.Quart.Out(time);
                            break;
                        case EasingAccents.easeInOut:
                            percentage = Easing.Quart.InOut(time);
                            break;
                    }
                    break;

                case EasingType.Expo:
                    switch(easingAccent) {
                        case EasingAccents.easeIn:
                            percentage = Easing.Expo.In(time);
                            break;
                        case EasingAccents.easeOut:
                            percentage = Easing.Expo.Out(time);
                            break;
                        case EasingAccents.easeInOut:
                            percentage = Easing.Expo.InOut(time);
                            break;
                    }
                    break;
                case EasingType.Back:
                    switch(easingAccent) {
                        case EasingAccents.easeIn:
                            percentage = Easing.Back.In(time);
                            break;
                        case EasingAccents.easeOut:
                            percentage = Easing.Back.Out(time);
                            break;
                        case EasingAccents.easeInOut:
                            percentage = Easing.Back.InOut(time);
                            break;
                    }
                    break;
                case EasingType.Bounce:
                    switch(easingAccent) {
                        case EasingAccents.easeIn:
                            percentage = Easing.Bounce.In(time);
                            break;
                        case EasingAccents.easeOut:
                            percentage = Easing.Bounce.Out(time);
                            break;
                        case EasingAccents.easeInOut:
                            percentage = Easing.Bounce.InOut(time);
                            break;
                    }
                    break;
            }
            targetTransform.rotation = Quaternion.Lerp(startQuaternion, endQuaternion, percentage);
            time += Time.deltaTime;
            yield return null;
        }
        if(ResetToStartAfterDone == true) {
            yield return new WaitForSeconds(1);
            targetTransform.rotation = startQuaternion;
        }
    }

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

public enum PropertyToChange {
    Position,
    Scale
}