using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    [SerializeField]
    private float textDuration = 2f;
    [SerializeField]
    private float wobbleMultiplier = 2f;
    [SerializeField]
    private float wobbleDuration = 2f;
   
    [SerializeField]
    private Ease wobbleEasing;
    [SerializeField]
    private Ease textEasing;

    private TextMeshPro textMeshPro;
    private Camera mainCamera;
    private string textValue;
    private Vector3 scaleValue;

	void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshPro>();
        mainCamera = Camera.main;
        scaleValue = transform.localScale;
        textValue = textMeshPro.text;
        gameObject.SetActive(false);
    }

	private void Update() {
        transform.LookAt(mainCamera.transform, Vector3.up);	
	}


	private void OnDisable() {
        transform.localScale = scaleValue;
		DOTween.Clear();
	}

	public void PrintText() {
        textMeshPro.text = "";
        transform.DOScale(transform.localScale * wobbleMultiplier, wobbleDuration).SetLoops(5, LoopType.Yoyo).SetEase(wobbleEasing);
        textMeshPro.DOText(textValue, textDuration, true).SetEase(textEasing);
    }



}
