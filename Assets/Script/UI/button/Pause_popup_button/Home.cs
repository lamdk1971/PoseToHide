using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : BaseButton
{
    protected override void onClick()
    {
        Debug.Log("home");
        SceneManager.LoadScene("LevelSelect");
    }
}
