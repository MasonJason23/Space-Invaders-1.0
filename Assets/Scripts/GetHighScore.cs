using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetHighScore : MonoBehaviour
{
    public TextMeshProUGUI guiText;
    
    void Awake()
    {
        int highScoreVal = PlayerPrefs.GetInt("highScore");
        guiText.text = "";
        int size = highScoreVal.ToString().Length;
        while (size < 4)
        {
            guiText.text += "0";
            size++;
        }
        guiText.text += highScoreVal.ToString();
    }
}
