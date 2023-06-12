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
            tickUI.SetActive(true);
            float fadeInDuration = 1f;
            Ease easing = Ease.OutQuad;
            float startScale = 0.5f;
            float endScale = 2.5f;
            Image image = tickUI.GetComponent<Image>();
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
            image.transform.localScale = Vector3.one * startScale;

            image.DOFade(1f, fadeInDuration).SetEase(easing);
            image.transform.DOScale(endScale, fadeInDuration).SetEase(easing);
        }
        
    }
}
