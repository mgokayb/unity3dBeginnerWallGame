using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public GameObject PowerUp;
    public GameObject PlayerObject;
    public GameObject Wall1;
    public GameObject Wall2;
    public GameObject Wall3;
    public GameObject Wall4;

    public int PlayerSpeed = 350;

    public Text textScore;
    public Text SpeedAndLevel;
    
    private int _score;
    public string CurrentLevel;
    public bool Wall1IsDestroyed;
    public bool Wall2IsDestroyed;
    public bool Wall3IsDestroyed;
    public bool Wall4IsDestroyed;
    private int score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            DisplayScore();
        }
    }
   

    #region Singleton 
    private static GameManage _instance = null;
    public static GameManage Manager
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            DestroyImmediate(this.gameObject);
        }
        else
        {
            _instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
    }
    #endregion Singleton

    private void Start()
    {

        Wall1IsDestroyed = false;
        Wall2IsDestroyed = false;
        Wall3IsDestroyed = false;
        Wall4IsDestroyed = false;
        CurrentLevel = "Level1";
        SpawnPowerUp();
    }
    public void SpawnPowerUp()
    {
        //CurrentLevel.ToString();
        
        if (CurrentLevel == "Level1")
        {
            GameObject NewPowerUp = Instantiate(PowerUp);
            NewPowerUp.transform.position = new Vector3(Random.Range(-30, 30), 1, Random.Range(-30, 25));
            NewPowerUp.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
            NewPowerUp.transform.localScale = new Vector3(2f, 2f, 2f);
            
        }
        if (CurrentLevel == "Level2")
        {
            GameObject NewPowerUp = Instantiate(PowerUp);
            NewPowerUp.transform.position = new Vector3(Random.Range(-133, 140), 3, Random.Range(-126, 142));
            NewPowerUp.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
            NewPowerUp.transform.localScale = new Vector3(20f,20f,20f);
            
        }
        if (CurrentLevel == "Level3")
        {
            GameObject NewPowerUp = Instantiate(PowerUp);
            NewPowerUp.transform.position = new Vector3(Random.Range(-420, 370), 8, Random.Range(-380, 400));
            NewPowerUp.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
            NewPowerUp.transform.localScale = new Vector3(100f, 100f, 100f);
            
        }
        if (CurrentLevel == "Level4")
        {
            GameObject NewPowerUp = Instantiate(PowerUp);
            NewPowerUp.transform.position = new Vector3(Random.Range(-800, 800), 20, Random.Range(-800, 750));
            NewPowerUp.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
            NewPowerUp.transform.localScale = new Vector3(400f, 400f, 400f);
            
        }
        

    }
    private void DisplayScore()
    {
        
        textScore.text = score.ToString();
    }
    public void GetScore(int _value)
    {
        score += _value;
    }
    
    public void CheckingLevel()
    {
        if ((PlayerObject.transform.position.y < -10) || ((PlayerObject.transform.position.x < -1050) || (PlayerObject.transform.position.x > 1034)) || ((PlayerObject.transform.position.z > 1077) || (PlayerObject.transform.position.z < -1039)))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if ((!Wall4IsDestroyed) && ((PlayerObject.transform.position.x > -1050 || PlayerObject.transform.position.x < 1034) || (PlayerObject.transform.position.z < 1077 || PlayerObject.transform.position.z > -1039)) && ((PlayerObject.transform.position.x > 450 || PlayerObject.transform.position.x < -480) || (PlayerObject.transform.position.z > 450 || PlayerObject.transform.position.z < -448)))
        {
            CurrentLevel = "Level4";
            Camera.main.transform.position = new Vector3(2, 1985, -5);
            Wall3IsDestroyed = true;
            Destroy(Wall3);
            //Debug.Log("wtf4");
        }
        if ((!Wall3IsDestroyed) && ((PlayerObject.transform.position.x > 150 || PlayerObject.transform.position.x < -158) || (PlayerObject.transform.position.z > 160 || PlayerObject.transform.position.z < -150)) && ((PlayerObject.transform.position.x < 450 || PlayerObject.transform.position.x > -480) || (PlayerObject.transform.position.z < 450 || PlayerObject.transform.position.z > -448)))
        {
            CurrentLevel = "Level3";
            Camera.main.transform.position = new Vector3(0,950,10);
            Wall2IsDestroyed = true;
            Destroy(Wall2);
            //Debug.Log("wtf3");
        }
        if ((!Wall2IsDestroyed) && ((PlayerObject.transform.position.x < 150 || PlayerObject.transform.position.x > -158) || (PlayerObject.transform.position.z < 160 || PlayerObject.transform.position.z > -150)) && ((PlayerObject.transform.position.x > 38 || PlayerObject.transform.position.x < -41) || (PlayerObject.transform.position.z > 34 || PlayerObject.transform.position.z < -43)))
        {
            CurrentLevel = "Level2";
            Camera.main.transform.position = new Vector3(0,300,5);
            Wall1IsDestroyed = true;
            Destroy(Wall1);
            //Debug.Log("wtf2");
        }
        if (!Wall1IsDestroyed && ((PlayerObject.transform.position.x < 38 || PlayerObject.transform.position.x > -41) || (PlayerObject.transform.position.z < 34 || PlayerObject.transform.position.z > -43)))
        {
            CurrentLevel = "Level1";
            Camera.main.transform.position = new Vector3(0, 80, -4);
            //Debug.Log("wtf1");
        }
    }
    private void Update()
    {
        CheckingLevel();
    }
}
