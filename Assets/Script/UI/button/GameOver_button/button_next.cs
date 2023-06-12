using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_next : BaseButton
{
    protected override void onClick()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
