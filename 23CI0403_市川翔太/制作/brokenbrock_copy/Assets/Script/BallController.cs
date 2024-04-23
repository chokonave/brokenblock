using UnityEngine;

public class BallController : MonoBehaviour
{
    Vector3 mousepos, worldpos;
    bool fire ;//���˂��ꂽ���ǂ���
               //�X�s�[�h
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
       
        if(Input.GetMouseButtonDown(0))//���N���b�N������
        {
            fire = true;//�Œ������
            
        }

        if (fire == false)//���˂���Ă��Ȃ�������
        {
            mousepos = Input.mousePosition;
            worldpos = Camera.main.ScreenToWorldPoint(new Vector3(mousepos.x, 70, 10f));//�{�[���ƃv���C���[����������������
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
            // Y���W�̕ω����`�F�b�N���A�����ԕς��Ȃ������ꍇ�Ɋp�x��ύX
            CheckPositionChange();
        }
        
        
        
    }
    
    
    private void CheckPositionChange()
    {
        
        float currentYPosition = transform.position.y;
        
        if (currentYPosition == lastYPosition)
        {
            yTime += Time.deltaTime;

            // ������x�̎��Ԃ��o�߂�����
            if (yTime >= 120) // 2�b�Ɖ���
            {
                ChangeAngle(); // �p�x��ύX���鏈�����Ă�
            }
        }
        else
        {
            // Y���W���ς�����ꍇ�̓��Z�b�g
            lastYPosition = currentYPosition;
            yTime = 0f;
        }
    }
    void ChangeAngle()
    {
        
        transform.Rotate(Vector3.forward, 30.0f); //�����тɂȂ����ꍇ��30�x�̌X����ǉ�
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.transform.tag=="Player"||collision.transform.tag=="Block") //switch�ł���������?
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
