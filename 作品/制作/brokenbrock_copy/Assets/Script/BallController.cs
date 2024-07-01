using UnityEngine;

public class BallController : MonoBehaviour
{
    Vector3 mousepos, worldpos;
    bool fire ;//発射されたかどうか
               //スピード
    public float speed;
    new Rigidbody2D rigidbody;

    

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
        
        
        
        
    }
    
    

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.transform.tag=="Player"||collision.transform.tag=="Block") 
        {
            Vector2 PLPos=collision.transform.position;
            Vector2 BallPos= transform.position;
            Vector3 direction = (BallPos - PLPos).normalized;
            if (collision.transform.tag == "Player"&&speed<=10.0f&&fire==true) { 
                speed = speed + 0.1f;
            
            }
            rigidbody.velocity = direction * speed;
        }
        if (collision.transform.tag == "wall")
        {
            Vector3 direction=collision.rigidbody.velocity;
            
                direction.x = -direction.x;
            
            
        }
        if(collision.transform.tag == "Up")
        {
            Vector3 direction=-collision.rigidbody.velocity;
            direction.y = -direction.y;
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
