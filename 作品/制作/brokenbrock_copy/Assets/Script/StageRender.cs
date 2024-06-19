using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageRender : MonoBehaviour
{
    [SerializeField]

    public string levelDataFolder = "Map";
    private string[] textdata;
    private int NowLevel = 0;//現在のステージ
    public int balls;//ボールの数
    bool clearcheck;
    
    public enum BlockType
    {
        Enemy,
        Enemy2,
        stagewall,
        Enpty
    }
    public bool gamestate;
    public GameObject Enemy;
    public GameObject Enemy2;
    public GameObject StageWall;
    public GameObject ball;
    //他参照先のスクリプト
    ClearChecker clearChecker;
    TextRender textRender;
    BallController ballController;
    AudioController audioController;
    BGMcheck bgmcheck;
    // Start is called before the first frame update
    void Start()
    {
        gamestate = true;
        clearChecker = FindObjectOfType<ClearChecker>();
        textRender = FindObjectOfType<TextRender>();
        bgmcheck=FindObjectOfType<BGMcheck>();
        audioController = FindObjectOfType<AudioController>();
        SwitchToLevel(NowLevel);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gamestate == false)
        {
            SwitchToTitle();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Esc();
        }
    }
    public void SwitchToLevel(int LevelIndex)
    {
        //初期化
        
        clearChecker.ResetBlock();

        DestroyALL();
        clearcheck = false;
        string relativePath = Path.Combine("Map", "stage" + (NowLevel + 1) + ".txt");
        string filePath = Path.Combine(Application.streamingAssetsPath, relativePath);
        Instantiate(ball);
        ballController = FindObjectOfType<BallController>();
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            for (int n = 0; n < lines.Length; n++)
            {
                string[] blockData = lines[n].Split(',');

                for (int m = 0; m < blockData.Length; m++)
                {
                    int blockValue = int.Parse(blockData[m]);
                    BlockType blockType;
                    switch (blockValue)
                    {
                        case 0:
                            blockType = BlockType.stagewall;
                            break;
                        case 1:
                            blockType = BlockType.Enemy;
                            break;
                        case 2:
                            blockType = BlockType.Enemy2;
                            break;
                        case 9:
                            blockType = BlockType.Enpty;
                            break;
                        default:
                            blockType = BlockType.Enpty;
                            break;
                    }

                    //ブロックの生成
                    InstantiateBlock(blockType, new Vector2(-2.5f + 0.5f * m, 3.0f - 0.2f * n));
                    if (blockType != BlockType.stagewall && blockType != BlockType.Enpty)
                    {
                        clearChecker.totaldestroyblocks++;
                        
                    }
                }

            }
        }
        if (clearChecker.totaldestroyblocks == 0)
        {
            clearChecker.GameClear();
        }
        else
        {
            textRender.Stage(NowLevel + 1);

            audioController.State();
            StartCoroutine(Textdelete());
        }
    }
    IEnumerator Textdelete()
    {
        yield return new WaitForSeconds(3f);
        textRender.Haku();
    }
    void InstantiateBlock(BlockType blockType, Vector2 position)
    {
        GameObject block = null;
        switch (blockType)
        {
            case BlockType.Enpty:
                break;

            case BlockType.Enemy:
                block = Instantiate(Enemy, position, Quaternion.identity);
                break;

            case BlockType.Enemy2:
                block = Instantiate(Enemy2, position, Quaternion.identity);
                break;

            case BlockType.stagewall:
                Instantiate(StageWall, position, Quaternion.identity);
                break;

        }
        if (block != null)
        {
            block.tag = "Block";
        }
    }
    void DestroyALL()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        foreach (GameObject block in blocks)
        {
            Destroy(block);
        }
    }
    public void BlockDestroy()//外部のEnemyからブロックが減ったことを知らせる処理
    {
        audioController.Effect();
        clearChecker.destroyedblocks++;
        if (clearChecker.destroyedblocks == clearChecker.totaldestroyblocks)
        { 
            audioController.ClearSound();
            clearcheck = true;
            ballController.Balldestroy();
            textRender.ClearText();
            
            
        }
        
        

    }
    public void SwitchToNextLevel()
    {
        NowLevel++;
        SwitchToLevel(NowLevel);//次のステージ番号

    }

    public void BallPurus()
    {
        balls++;
    }
    public void BallCount()
    {
        balls--;
        if (balls == 0 && clearcheck == false)
        {
            LoseLife();
        }
    }
    void LoseLife()
    {
        clearChecker.life--;
        if (clearChecker.life > 0)
        {
            audioController.LostLife();
            textRender.MissText(clearChecker.life);
            gamestate = true;
            textRender.GameOverText();
            Instantiate(ball);
            ballController=FindObjectOfType<BallController>();
        }
        else
        {
            bgmcheck.BGMmute();
            audioController.GameOver();
            textRender.GameEnd();
            gamestate = false;
        }
    }
    
    
    
    void SwitchToTitle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Title_Scene");
        }
    }
    void Esc()
    {
        Debug.Log("ゲームを終了する");
        Application.Quit();
    }
    void Awake()//デバッグ
    {
        clearChecker = FindObjectOfType<ClearChecker>();
        textRender = FindObjectOfType<TextRender>();
        ballController = FindObjectOfType<BallController>();
        audioController = FindObjectOfType<AudioController>();
        if (clearChecker == null)
        {
            Debug.LogError("ClearChecker not found!");
        }
        if (textRender == null)
        {
            Debug.LogError("textRender not found!");
        }
        if(audioController == null)
        {
            Debug.LogError("audioController not found!");
        }
        // 同様に他の変数に対しても null チェックを追加
        // ...
    }
}

    