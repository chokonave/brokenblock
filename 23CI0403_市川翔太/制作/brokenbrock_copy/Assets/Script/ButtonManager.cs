using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public Button startButton,endButton,BGMButton;
    public Text text;
    public TMP_Text vertext;
    public static bool check;
    // Start is called before the first frame update
    void Start()
    {
        string version = Application.version;
        vertext.text = "Version" + version;
        startButton.onClick.AddListener(StartGame);
        endButton.onClick.AddListener(EndGame);
        BGMButton.onClick.AddListener(OnOffBGM);
        if (check) { text.text = "BGM　オン"; }
        else {text.text = "BGM　オフ"; }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndGame();
        }
    }
    void StartGame()
    {
        SceneManager.LoadScene("Game_Scene");
    }
    public void EndGame()
    {
        Application.Quit();
    }
    void OnOffBGM()
    {
        if(check) { check = false;text.text = "BGM　オフ"; } 
        else { check = true; text.text = "BGM　オン"; }

    }
}
