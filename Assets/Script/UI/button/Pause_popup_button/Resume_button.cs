using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_button : BaseButton
{
    protected override void onClick()
    {
        this.gameObject.GetComponentInParent<Canvas>().transform.gameObject.SetActive(false);

    }
}
