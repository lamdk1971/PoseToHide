using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Button : BaseButton
{
    public Sprite soundOn;
    public Sprite soundOff;
    private bool status = true;

    protected override void onClick()
    {
        if (status)
        {
            button.image.sprite = soundOff;
            status = false;
        } else
        {
            button.image.sprite = soundOn;
            status = true;
        }
    }
}
