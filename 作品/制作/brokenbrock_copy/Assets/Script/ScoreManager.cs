using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMnager : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    int lifepurasu;
    public TextMeshProUGUI text,Htext;
    ClearChecker clearChecker;
    TextRender textRender;
    AudioController audioController;
    private const string highScoreKey = "HighScore";
    // Start is called before the first frame update
    void Start()
    {
        audioController = FindObjectOfType<AudioController>();
        clearChecker = FindObjectOfType<ClearChecker>();
        textRender = FindObjectOfType<TextRender>();
        LoadHighScoer();
        //SaveHighScore();
        lifepurasu = 1;
    }

    // Update is called once per frame
    void Update()
    {
        text.text=score.ToString();
        Htext.text = highScore.ToString();
    }
    public void ScoreUpdate(int Enemyscore)//敵が倒されたことに対して呼び出される
    {
        score += Enemyscore;

        if (score > highScore)
        {
            highScore = score;
            SaveHighScore();
            
        }
        
        UpDateScoreDisplay();

        if (score / 10000 >= lifepurasu)
        {
            audioController.Zanki();
            clearChecker.life++;
            lifepurasu++;
            textRender.OneUPText(clearChecker.life);
            
        }
    }
    void UpDateScoreDisplay()//スコアの表示
    {
        text.text=score.ToString();
    }
    public void LoadHighScoer()//起動時にハイスコアを読み込む
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        UpdateHighScoreDisplay();
    }
    void SaveHighScore()//ハイスコアの記録
    {
        //highScore = 0;
        PlayerPrefs.SetInt(highScoreKey, highScore);
        PlayerPrefs.Save();
    }
    public void UpdateHighScoreDisplay()//ハイスコアの表示
    {
        Htext.text=highScore.ToString();
    }
}
