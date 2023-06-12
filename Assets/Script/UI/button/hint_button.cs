using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class hint_button : BaseButton
{
    public List<GameObject> characters;
    public float time;
    SpriteRenderer spriteRenderer;
    protected override void onClick()
    {
        GameObject character = characters[Random.RandomRange(0, characters.Count)];
        character.gameObject.SetActive(true);
        spriteRenderer = character.GetComponent<SpriteRenderer>();

        Sequence sequence = DOTween.Sequence();
        sequence.Append(spriteRenderer.DOFade(0f, 0.75f / 2).SetEase(Ease.InOutSine));
        sequence.Append(spriteRenderer.DOFade(1f, 0.75f / 2).SetEase(Ease.InOutSine));
        sequence.SetLoops(-1);
        sequence.SetAutoKill(false);
    }

    private void Update()
    {
        /*time += Time.deltaTime;
        if(time > 3f)
        {
            spriteRenderer.DOKill();
            spriteRenderer.enabled = false;
            time = 0f;
        }*/
    }
}
