using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;

    /*[SerializeField]
    private StageData stageData;*/
    
    Rigidbody2D myrigidbody2D;
    bool isGround;

    [SerializeField]
    Transform pos;

    [SerializeField]
    float checkRadius;

    [SerializeField]
    LayerMask islayer;

    [SerializeField]
    private float power;

    public int jumpCount;

    int jumpCnt;

    [SerializeField]
    private StageData stageData;
 

    private void Awake()
    {

    }

    public void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        jumpCnt = jumpCount;
    }

    public void Update()
    {
        isGround = Physics2D.OverlapCircle(pos.position, checkRadius, islayer);

        if (isGround == true && Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0)
        {
            myrigidbody2D.velocity = Vector2.up * power;
        }

        if (isGround == false && Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0)
        {
            myrigidbody2D.velocity = Vector2.up * power;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpCnt--;
            
        }

        if (isGround)
        {
            jumpCnt = jumpCount;
        }
    }

    public void OnDie() {
        PlayerPrefs.SetInt("Score", score);
       // 플레이어 사망 시 nextSceneName 씬으로 이동
        SceneManager.LoadScene(nextSceneName);
    }

    private int score;
    public int Score {
        set => score = Mathf.Max(0,value);
        get => score;
    }
   
}
