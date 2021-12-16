using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingPowerUps : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("PowerUp"))
        {
            GameManage.Manager.SpawnPowerUp();
            GetComponent<Renderer>().material.color = collision.collider.GetComponent<Renderer>().material.color;
            Destroy(collision.gameObject);
            
            if(GameManage.Manager.CurrentLevel == "Level1")
            {
                GameManage.Manager.GetScore(Random.Range(1, (int)transform.localScale.x * 10));
                transform.localScale += Vector3.one * 1f;
            }
            if (GameManage.Manager.CurrentLevel == "Level2")
            {
                GameManage.Manager.GetScore(Random.Range(1, (int)transform.localScale.x * 100));
                transform.localScale += Vector3.one * 5f;
            }
            if (GameManage.Manager.CurrentLevel == "Level3")
            {
                GameManage.Manager.GetScore(Random.Range(1, (int)transform.localScale.x * 1000));
                transform.localScale += Vector3.one * 15f;
            }
            if (GameManage.Manager.CurrentLevel == "Level4")
            {
                GameManage.Manager.GetScore(Random.Range(1, (int)transform.localScale.x * 10000));
                transform.localScale += Vector3.one * 50f;
            }
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
