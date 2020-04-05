using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAI : MonoBehaviour
{
    public GameObject ball;    
    private Rigidbody2D rbBall,rbBlobby;
    bool isGrounded = false;
    float horizontalMove = 0;
    public float moveSpeed = 40f;
     private float m_JumpForce = 600f;
    private Vector3 m_Velocity = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    float goRight = 1.0f;
    float goLeft = -1.0f;
    [SerializeField]  float servisUzakligi = .3f;

    public GameObject gameRulesObject;//game rules ball'ın içinde.
    GameRules temp1;
    public bool roundEnd;
    public bool round;
    // Start is called before the first frame update
    void Start()
    {
        rbBlobby = GetComponent<Rigidbody2D>();
        temp1 = gameRulesObject.GetComponent<GameRules>();


    }

    // Update is called once per frame
    void Update()
    {
        
        round = temp1.getRound();
        roundEnd = temp1.getRoundEnd();
        //round = gameRules.GetComponent<GameRules>().getRound();

        //roundEnd = gameRules.GetComponent<GameRules>().getRoundEnd();
        //Debug.Log("OI round:" + round + "roundEnd:" + roundEnd);
        StartCoroutine(move());


        

        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.name == "BlueSide")
        {
            Debug.Log("Mavi blobby yere değiyor.");
            isGrounded = true;


        }
    }


    IEnumerator move()
    {
        
        if (ball.transform.position.x > 0 && isGrounded == true && roundEnd==false && round == false && (ball.transform.position.x - this.transform.position.x) < -3f)  //blobby zıplatma
        {
            rbBlobby.AddForce(new Vector2(0f, m_JumpForce));
            isGrounded = false;

        }

        

        else if (ball.transform.position.x > 0 && isGrounded == true && roundEnd == true && round == false && (ball.transform.position.x-this.transform.position.x)<-4f)  //blobby zıplatma
        {
            rbBlobby.AddForce(new Vector2(0f, m_JumpForce));
            isGrounded = false;

        }

        if (ball.transform.position.x < 0 && this.transform.position.x < 7 && roundEnd == false && round == false)
        {
            yield return new WaitForSeconds(0.3f);
            Vector3 targetVelocity = new Vector2(goRight * moveSpeed * Time.fixedDeltaTime * 10f, rbBlobby.velocity.y);
            rbBlobby.velocity = Vector3.SmoothDamp(rbBlobby.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }

        else if (ball.transform.position.x < 0 && this.transform.position.x > 7 && roundEnd == false && round == false)
        {
            yield return new WaitForSeconds(0.3f);
            Vector3 targetVelocity = new Vector2(goLeft * moveSpeed * Time.fixedDeltaTime * 10f, rbBlobby.velocity.y);
            rbBlobby.velocity = Vector3.SmoothDamp(rbBlobby.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }


        else if (ball.transform.position.x > 0 && ball.transform.position.x < this.transform.position.x && roundEnd == false && round==false)
        {
            yield return new WaitForSeconds(0.3f);
            Vector3 targetVelocity = new Vector2(goLeft * moveSpeed * Time.fixedDeltaTime * 10f, rbBlobby.velocity.y);
            rbBlobby.velocity = Vector3.SmoothDamp(rbBlobby.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }

        else if (ball.transform.position.x > 0 && ball.transform.position.x > this.transform.position.x && roundEnd == false && round == false)
        {
            yield return new WaitForSeconds(0.3f);
            Vector3 targetVelocity = new Vector2(goRight * moveSpeed * Time.fixedDeltaTime * 10f, rbBlobby.velocity.y);
            rbBlobby.velocity = Vector3.SmoothDamp(rbBlobby.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }

        else if(ball.transform.position.x > 0 && ball.transform.position.x < this.transform.position.x && roundEnd == true && round == false)
        {
            yield return new WaitForSeconds(.5f);
            Vector3 targetVelocity = new Vector2(goLeft * moveSpeed * Time.fixedDeltaTime * 10f, rbBlobby.velocity.y);
            rbBlobby.velocity = Vector3.SmoothDamp(rbBlobby.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        }

        else if (ball.transform.position.x > 0 && ball.transform.position.x > this.transform.position.x && roundEnd == true && round == false)
        {
            yield return new WaitForSeconds(.5f);
            Vector3 targetVelocity = new Vector2(goRight * moveSpeed * Time.fixedDeltaTime * 10f, rbBlobby.velocity.y);
            rbBlobby.velocity = Vector3.SmoothDamp(rbBlobby.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }


    }


    

}
