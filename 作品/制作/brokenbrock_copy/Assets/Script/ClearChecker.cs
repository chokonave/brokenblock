using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;


public class ClearChecker : MonoBehaviour
{
    [SerializeField]
    public int totaldestroyblocks;//壊せるブロック数
    public int destroyedblocks;//壊したブロック数
    public int life;//残機
    StageRender stageRender;
    TextRender textRender;
    // Start is called before the first frame update
    void Start()
    {
        stageRender = FindObjectOfType<StageRender>();
        textRender = FindObjectOfType<TextRender>();
        life = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetBlock()
    {
        totaldestroyblocks = 0;
        destroyedblocks = 0;
    }
    public void GameClear()
    {
        textRender.game.text = "COMPLETE!!";
        textRender.gameovertext.text = "左クリックでタイトルに戻る";
        stageRender.gamestate = false;

    }
}
