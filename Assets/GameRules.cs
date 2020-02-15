using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRules : MonoBehaviour
{

    
  
    public GameObject ground;
    public GameObject ball;
    public Text txt;
    bool round;
    bool roundEnd;
    Canvas canv;
    Vector2 temp;
    
    Vector2 startPoint = new Vector2(-4.18f, 0.99f);
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {        
        round = false;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.rotation);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {

        Debug.Log("Top " + coll.gameObject.name + "'e çaptı");
        txt.text = "Naber";
        if (roundEnd == true)
        {
            roundEnd = false;
            rb.gravityScale = 0.5f;
            rb.freezeRotation = false;
            
        }
        
        if (round == false && coll.gameObject.name=="RedSide" && roundEnd==false)
        {
            round = true;
            StartCoroutine(resetGame("RedSide"));
        }
        
        
    }
    void resetBallPosition()
    {
        
    }


    IEnumerator resetGame(string side)
    {        
        if (side=="RedSide")
        {
            Debug.Log("Bekleme başladı.");
            yield return new WaitForSeconds(3);  //3 saniye bekle
            Debug.Log("Mavi puan kazandı!");
            Debug.Log("Puan Ekle Topu yerleştir.");
            rb.gravityScale = 0;
            rb.velocity = Vector3.zero;
            //transform.rotation = Quaternion.identity;
            rb.freezeRotation = true;
            transform.position = startPoint;
            roundEnd = true;
            round = false;
            
        }
        
        else if(side =="BlueSide")
        {
            yield return new WaitForSeconds(3);
            Debug.Log("Kırmızı puan kazandı!");
            Debug.Log(round);
        }
    }


   


}
