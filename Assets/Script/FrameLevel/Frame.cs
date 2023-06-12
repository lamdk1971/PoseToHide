using DG.Tweening;
using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;
using Color = UnityEngine.Color;
using Image = UnityEngine.UI.Image;

public class Frame : MonoBehaviour
{

    public List<Character> characterList;
    public bool allPass = false;

    public GameObject tickUI;
    public GameObject gameOverCanvas;

    private float time;
    private Tween myTween;
    private Image image;
    private void Start()
    {
        image = tickUI.GetComponent<Image>();
    }
    private void Update()
    {
        
        allPass = true;
        foreach (Character character in characterList)
        {
            if (character.isPass == false)
            {
                allPass = false;
                tickUI.SetActive(false);
                return;
            }
        }
        if (allPass)
        {
            setActiveTick();
            gameOver();
            return;
        }
    }

    public void setActiveTick()
    {
        myTween.Restart();
        tickUI.SetActive(true);
        float fadeInDuration = 1f;
        Ease easing = Ease.OutQuad;
        float startScale = 0.5f;
        float endScale = 2.5f;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        image.transform.localScale = Vector3.one * startScale;
        myTween = image
            .DOFade(1f, fadeInDuration).
            SetEase(easing);
        myTween = image
            .transform
            .DOScale(endScale, fadeInDuration)
            .SetEase(easing)
            .OnComplete(gameOver);
    }

    public void gameOver()
    {
        foreach (Character character in characterList)
        {
            character.GetComponent<PolygonCollider2D>().enabled = false;
        }
        time += Time.deltaTime;
        if(time >= 3f)
        {
            gameOverCanvas.SetActive(true);
            tickUI.SetActive(false);
            allPass = false;
        }
    }

    // pending
    public Image image_white_flash;
    public void flashWhite()
    {
        image_white_flash.gameObject.SetActive(true);
        image_white_flash.color = new Color(1f, 1f, 1f, 0f);
        Tween fadeInTween = image_white_flash.DOFade(1f, 1f);
        Tween fadeOutTween = image_white_flash.DOFade(0f, 1f);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(fadeInTween);
        sequence.AppendInterval(1f);
        sequence.Append(fadeOutTween);
        sequence.Play();
    }
}
