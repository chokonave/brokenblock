using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    int HP;
    public AudioClip soundEffect;
    [SerializeField]
    private Sprite newsprite;
    // Start is called before the first frame update
    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        HP = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            HP--;
            if (HP == 1)
            {
                spriteRenderer.sprite = newsprite;
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = soundEffect;
                audioSource.Play();
            }
        }
            if (HP == 0)
            {
                Destroy(gameObject);
            int tokuten = 200;
                StageRender stageRender = FindObjectOfType<StageRender>();
                stageRender.BlockDestroy();
                ScoreMnager scoreadd = FindObjectOfType<ScoreMnager>();
                scoreadd.ScoreUpdate(tokuten);
            }
            
        
        
    }
}
