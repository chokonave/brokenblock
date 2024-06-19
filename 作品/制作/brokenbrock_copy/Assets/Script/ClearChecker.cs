using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;


public class ClearChecker : MonoBehaviour
{
    [SerializeField]
    public int totaldestroyblocks;//�󂹂�u���b�N��
    public int destroyedblocks;//�󂵂��u���b�N��
    public int life;//�c�@
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
        textRender.gameovertext.text = "���N���b�N�Ń^�C�g���ɖ߂�";
        stageRender.gamestate = false;

    }
}
