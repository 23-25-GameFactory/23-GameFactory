using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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

   

   
}
