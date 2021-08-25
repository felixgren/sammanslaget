using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MouseItemHover : MonoBehaviour
{
	[SerializeField]
	private SpeechBubble speechBubble;

	private void OnMouseEnter() {
		speechBubble.gameObject.SetActive(true);
		speechBubble.PrintText();
	}

	private void OnMouseExit() {
		speechBubble.gameObject.SetActive(false);
	}
}
