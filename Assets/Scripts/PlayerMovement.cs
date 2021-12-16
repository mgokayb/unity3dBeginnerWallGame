using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int JumpPower = 200;
    private Rigidbody rigid;
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();    
    }
    void FixedUpdate()
    {
        
        rigid.AddForce((Vector3.right * Input.GetAxis("Horizontal") + Vector3.forward * Input.GetAxis("Vertical")) * GameManage.Manager.PlayerSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector3.up * JumpPower ,ForceMode.Impulse);
        }

        if(this.transform.position.y / this.transform.localScale.y > 1.5f)
        {
            this.rigid.AddForce(Vector3.down*JumpPower,ForceMode.Impulse);
        }

        if(GameManage.Manager.CurrentLevel == "Level1")
        {
            GameManage.Manager.PlayerSpeed = 400;
            JumpPower = 20;
        }
        if (GameManage.Manager.CurrentLevel == "Level2")
        {
            GameManage.Manager.PlayerSpeed = 1200;
            JumpPower = 50;
        }
        if (GameManage.Manager.CurrentLevel == "Level3")
        {
            GameManage.Manager.PlayerSpeed = 4000;
            JumpPower = 100;
        }
        if (GameManage.Manager.CurrentLevel == "Level4")
        {
            GameManage.Manager.PlayerSpeed = 10000;
            JumpPower = 400;
        }

        

    }
}
