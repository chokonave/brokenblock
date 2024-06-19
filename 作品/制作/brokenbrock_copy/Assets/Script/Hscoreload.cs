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
     void LoadHighScoer()//�N�����Ƀn�C�X�R�A��ǂݍ���
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        UpdateHighScoreDisplay();
    }
    void SaveHighScore()//�n�C�X�R�A�̋L�^
    {
        PlayerPrefs.SetInt(highScoreKey, highScore);
        PlayerPrefs.Save();
    }
    void UpdateHighScoreDisplay()//�n�C�X�R�A�̕\��
    {
        Htext.text = highScore.ToString();
    }
}
