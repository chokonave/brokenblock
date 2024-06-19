using UnityEngine;

public class BallController : MonoBehaviour
{
    Vector3 mousepos, worldpos;
    bool fire ;//発射されたかどうか
               //スピード
    public float speed;
    new Rigidbody2D rigidbody;
    float lastYPosition;
    float yTime;
    

    // Start is called before the first frame update
    void Start()
    {
         speed = 5.0f;
        Application.targetFrameRate = 60;
        fire = false;
        Vector2 vec=new Vector2(3.0f,3.0f);
        rigidbody= this.GetComponent<Rigidbody2D>();
        rigidbody.velocity = vec;
        StageRender stageRender = FindObjectOfType<StageRender>();
        stageRender.BallPurus();
        lastYPosition=transform.position.y;
        yTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetMouseButtonDown(0))//左クリックしたら
        {
            fire = true;//固定を解除
            
        }

        if (fire == false)//発射されていなかったら
        {
            mousepos = Input.mousePosition;
            worldpos = Camera.main.ScreenToWorldPoint(new Vector3(mousepos.x, 70, 10f));//ボールとプレイヤーが同じ動きをする
            if (worldpos.x < -2.3f)
            {
                worldpos.x = -2.3f;
            }
            if (worldpos.x > 2.3f)
            {
                worldpos.x = 2.3f;
            }
            transform.position = worldpos;

        }
        else
        {
            // Y座標の変化をチェックし、一定期間変わらなかった場合に角度を変更
            CheckPositionChange();
        }
        
        
        
    }
    
    
    private void CheckPositionChange()
    {
        
        float currentYPosition = transform.position.y;
        
        if (currentYPosition == lastYPosition)
        {
            yTime += Time.deltaTime;

            // ある程度の時間が経過したら
            if (yTime >= 120) // 2秒と仮定
            {
                ChangeAngle(); // 角度を変更する処理を呼ぶ
            }
        }
        else
        {
            // Y座標が変わった場合はリセット
            lastYPosition = currentYPosition;
            yTime = 0f;
        }
    }
    void ChangeAngle()
    {
        
        transform.Rotate(Vector3.forward, 30.0f); //横跳びになった場合に30度の傾きを追加
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.transform.tag=="Player"||collision.transform.tag=="Block") //switchでもいいかも?
        {
            Vector2 PLPos=collision.transform.position;
            Vector2 BallPos= transform.position;
            Vector3 direction = (BallPos - PLPos).normalized;
            if (collision.transform.tag == "Player"&&speed<=10.0f&&fire==true) { 
                speed = speed + 0.1f;
            
            }
            rigidbody.velocity = direction * speed;
        }
        
    }
    
    void OnBecameInvisible()
    {
        StageRender stageRender = FindObjectOfType<StageRender>();
        if(stageRender != null)
        {
            stageRender.BallCount();
            
        }
        
        DestroyBall();
        
    }
    public void Balldestroy()
    {
        Destroy(gameObject);
    }
    void DestroyBall()
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
