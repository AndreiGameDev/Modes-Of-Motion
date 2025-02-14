using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderUI : MonoBehaviour
{
	[SerializeField]Slider slider;
	[SerializeField]TextMeshProUGUI textUI;

	public void ChangeText() {
		textUI.text = slider.value.ToString();
	}
}
