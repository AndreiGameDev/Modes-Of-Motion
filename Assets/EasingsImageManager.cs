using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasingsImageManager : MonoBehaviour
{
    [Header("ImageComponent")]
    RawImage imageUI;

    [Header("Sines")]
    [SerializeField] Sprite SineIn;
    [SerializeField] Sprite SineOut;
    [SerializeField] Sprite SineInOut;
    [Header("Cubic")]
    [SerializeField] Sprite CubicIn;
    [SerializeField] Sprite CubicOut;
    [SerializeField] Sprite CubicInOut;
    [Header("Quint")]
    [SerializeField] Sprite QuintIn;
    [SerializeField] Sprite QuintOut;
    [SerializeField] Sprite QuintInOut;
    [Header("Elastic")]
    [SerializeField] Sprite ElasticIn;
    [SerializeField] Sprite ElasticOut;
    [SerializeField] Sprite ElasticInOut;
    [Header("Quadratic")]
    [SerializeField] Sprite QuadIn;
    [SerializeField] Sprite QuadOut;
    [SerializeField] Sprite QuadInOut;
    [Header("Quart")]
    [SerializeField] Sprite QuartIn;
    [SerializeField] Sprite QuartOut;
    [SerializeField] Sprite QuartInOut;
    [Header("Expo")]
    [SerializeField] Sprite ExpoIn;
    [SerializeField] Sprite ExpoOut;
    [SerializeField] Sprite ExpoInOut;
    [Header("Back")]
    [SerializeField] Sprite BackIn;
    [SerializeField] Sprite BackOut;
    [SerializeField] Sprite BackInOut;
    [Header("Bounce")]
    [SerializeField] Sprite BounceIn;
    [SerializeField] Sprite BounceOut;
    [SerializeField] Sprite BounceInOut;
    public void SetEasingsImage(EasingAccents easingAccent, EasingType easingFunction) {
        switch(easingFunction) {
            case EasingType.Sines:
                switch(easingAccent) {
                    case EasingAccents.easeIn:

                        break;
                    case EasingAccents.easeOut:

                        break;
                    case EasingAccents.easeInOut:

                        break;
                }
                break;
            case EasingType.Cubic:
                switch(easingAccent) {
                    case EasingAccents.easeIn:

                        break;
                    case EasingAccents.easeOut:

                        break;
                    case EasingAccents.easeInOut:

                        break;
                }
                break;
            case EasingType.Quint:
                switch(easingAccent) {
                    case EasingAccents.easeIn:

                        break;
                    case EasingAccents.easeOut:

                        break;
                    case EasingAccents.easeInOut:

                        break;
                }
                break;
            case EasingType.Elastic:
                switch(easingAccent) {
                    case EasingAccents.easeIn:

                        break;
                    case EasingAccents.easeOut:

                        break;
                    case EasingAccents.easeInOut:

                        break;
                }
                break;
            case EasingType.Quadratic:
                switch(easingAccent) {
                    case EasingAccents.easeIn:

                        break;
                    case EasingAccents.easeOut:

                        break;
                    case EasingAccents.easeInOut:

                        break;
                }
                break;
            case EasingType.Quart:
                switch(easingAccent) {
                    case EasingAccents.easeIn:

                        break;
                    case EasingAccents.easeOut:

                        break;
                    case EasingAccents.easeInOut:

                        break;
                }
                break;
            case EasingType.Expo:
                switch(easingAccent) {
                    case EasingAccents.easeIn:

                        break;
                    case EasingAccents.easeOut:

                        break;
                    case EasingAccents.easeInOut:

                        break;
                }
                break;
            case EasingType.Back:
                switch(easingAccent) {
                    case EasingAccents.easeIn:

                        break;
                    case EasingAccents.easeOut:

                        break;
                    case EasingAccents.easeInOut:

                        break;
                }
                break;
            case EasingType.Bounce:
                switch(easingAccent) {
                    case EasingAccents.easeIn:

                        break;
                    case EasingAccents.easeOut:

                        break;
                    case EasingAccents.easeInOut:

                        break;
                }
                break;
        }
    }
}
