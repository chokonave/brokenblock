using System.Collections;
using TMPro;
using UnityEngine;

public class TextRender : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI game, gameovertext, lifetext, stagetext;
    StageRender stageRender;
    AudioController audioController;
    // Start is called before the first frame update
    void Start()
    {
        audioController = FindObjectOfType<AudioController>();
        stageRender=FindObjectOfType<StageRender>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Stage(int number)
    {
        game.text = "STAGE" + number;
        stagetext.text = "STAGE" + number;
    }
    public void Haku()
    {
        game.text = "";
    }
    public IEnumerator  ClearText_Start()
    {
        game.text = "STAGE CLEAR";
        yield return new WaitForSeconds(5f);
        Haku();
        stageRender.SwitchToNextLevel();
        yield return new WaitForSeconds(3f);
        game.text = "";
    }
    public void MissText(int life)
    {
        lifetext.text = "LIFE" + life;
        game.text = "MISS";
        
    }
    public void OneUPText(int life)
    {
        lifetext.text = "LIFE" + life;
        
    }
    public IEnumerator GameOverText_Start()
    {
        yield return new WaitForSeconds(3f);
        game.text = "";
        
    }
    public void GameEnd()
    {
        
        game.text = "GAME OVER";
        gameovertext.text = "左クリックでタイトルに戻る";
        

    }
    public void ClearText()
    {
        StartCoroutine(ClearText_Start());
    }
    public void GameOverText()
    {
        StartCoroutine(GameOverText_Start());
    }
}
