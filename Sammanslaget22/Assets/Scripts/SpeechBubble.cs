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
    private string defaultText = "";
    private string printedText = "";

    private Vector3 scaleValue;
    private Tweener textTweener;

	void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshPro>();
        mainCamera = Camera.main;
        scaleValue = transform.localScale;
        defaultText = textMeshPro.text;
        gameObject.SetActive(false);
        textMeshPro.text = "";
    }

	private void Update() {
        transform.LookAt(mainCamera.transform, Vector3.up);	
	}


	private void OnDisable() {
        transform.localScale = scaleValue;

        if (textTweener != null && textTweener.IsPlaying()) {
            printedText = textMeshPro.text;
		}

        DOTween.Clear();
	}

	public void PrintText() {

        Debug.Log(printedText);
        //transform.DOScale(transform.localScale * wobbleMultiplier, wobbleDuration).SetLoops(5, LoopType.Yoyo).SetEase(wobbleEasing);
        textTweener = textMeshPro.DOText(defaultText, textDuration, true).SetEase(textEasing).ChangeStartValue(printedText);
    }



}
