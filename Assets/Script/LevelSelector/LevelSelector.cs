using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : BaseButton
{
    public int level;
    public string levelText;

    private void awake()
    {
        levelText = gameObject.name;
    }

    protected override void onClick()
    {
        SceneManager.LoadScene(gameObject.name);
    }
}
