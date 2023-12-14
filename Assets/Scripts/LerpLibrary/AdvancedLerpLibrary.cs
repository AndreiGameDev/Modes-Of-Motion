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

    public Vector3 QuadBezier(Vector3 point1, Vector3 point2, Vector3 point3, float t) {
        //lerp from the first point to the second
        Vector3 mid1 = LerpVector(point1, point2, t);
        //lerp from the second point to the third
        Vector3 mid2 = LerpVector(point2, point3, t);

        //return the lerp from the two intermediate points
        return LerpVector(mid1, mid2, t);
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

    public IEnumerator testLerp(Transform targetTransform, Vector3 startVector, Vector3 endVector, PropertyToChange propertyToChange, EasingType easingType, EasingAccents easingAccent, float duration = 1f, bool ResetToStartAfterDone = false) {
        float time = 0;
        while(time < duration) {
            float percentage = 0;
            
            switch(propertyToChange) {
                case PropertyToChange.Position:
                    targetTransform.position = LerpVectorEasing(startVector, endVector, percentage, easingType, easingAccent);
                    break;
                case PropertyToChange.Scale:
                    targetTransform.localScale = LerpVector(startVector, endVector, percentage);
                    break;
            }
            time += Time.deltaTime;
            yield return null;
        }
        if(ResetToStartAfterDone == true) {
            yield return new WaitForSeconds(duration);
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
    public IEnumerator WorldVector3LerpEasing(Transform targetTransform, Vector3 startVector, Vector3 endVector, PropertyToChange propertyToChange, EasingType easingType, EasingAccents easingAccent, float duration = 1f, bool ResetToStartAfterDone = false) {
        float time = 0;
        while(time < duration) {
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
            yield return new WaitForSeconds(duration);
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

    public IEnumerator LocalVector3LerpEasing(Transform targetTransform, Vector3 startVector, Vector3 endVector, PropertyToChange propertyToChange, EasingType easingType, EasingAccents easingAccent, float duration = 1f, bool ResetToStartAfterDone = false) {
        float time = 0;
        while(time < duration) {
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
                    targetTransform.localPosition = LerpVector(startVector, endVector, percentage);
                    break;
                case PropertyToChange.Scale:
                    targetTransform.localScale = LerpVector(startVector, endVector, percentage);
                    break;
            }
            time += Time.deltaTime;
            yield return null;
        }
        if(ResetToStartAfterDone == true) {
            yield return new WaitForSeconds(duration);
            switch(propertyToChange) {
                case PropertyToChange.Position:
                    targetTransform.localPosition = startVector;
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