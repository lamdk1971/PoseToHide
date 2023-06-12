using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_pause : BaseButton
{
    public GameObject popup;
    private void awake()
    {
        popup.SetActive(false);
    }
    protected override void onClick()
    {
        popup.SetActive(true);
    }
}
