using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hscoreload : MonoBehaviour
{
    public int highScore = 0;
    public TextMeshProUGUI Htext;
    private const string highScoreKey = "HighScore";
    // Start is called before the first frame update
    void Start()
    {
        LoadHighScoer();  
    }


    // Update is called once per frame
    void Update()
    {
        
    }
     void LoadHighScoer()//起動時にハイスコアを読み込む
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        UpdateHighScoreDisplay();
    }
    void SaveHighScore()//ハイスコアの記録
    {
        PlayerPrefs.SetInt(highScoreKey, highScore);
        PlayerPrefs.Save();
    }
    void UpdateHighScoreDisplay()//ハイスコアの表示
    {
        Htext.text = highScore.ToString();
    }
}
