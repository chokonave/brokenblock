using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int destroyedblocks;
    public AudioClip soundEffect;
    // Start is called before the first frame update
    void Start()
    {
        soundEffect = GetComponent<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            
            Destroy(gameObject);
            int tokuten = 100;
            StageRender stageRender = FindObjectOfType<StageRender>();
            stageRender.BlockDestroy();
            ScoreMnager scoreadd = FindObjectOfType<ScoreMnager>();
            scoreadd.ScoreUpdate(tokuten);
        }
    }
}
