using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRules : MonoBehaviour
{

    
  
    public GameObject ground;
    public GameObject ball;
    public GameObject OppenentsAIObject;
    public Text scoreBoardRed, scoreBoardBlue;
    int scoreTemp = 0;
    bool round;
    bool roundEnd;
    Canvas canv;
    Vector2 temp;
    int ballBounceRed = 0, ballBounceBlue=0;//topun kaç kez sektiğini gösteren.
    string lastBounce;
    Vector2 startPoint = new Vector2(-6.18f, 0.99f);
    Vector2 blueStartPoint = new Vector2(5.59f, 0.99f);
    Rigidbody2D rb;
    OpponentAI opTemp;
    
    // Start is called before the first frame update
    void Start()
    {        
        round = false;
        rb = GetComponent<Rigidbody2D>();

        //opTemp = OppenentsAIObject.GetComponent<OpponentAI>();
        

    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("GR round:" + round + "roundEnd:" + roundEnd);

        //Debug.Log(transform.rotation);
        if (round == false && roundEnd == false && ballBounceRed > 2) //Top kırmızının üstünde 3 kez sekerse.
        {
            round = true;  //round sonu.yeni round başlat
            //opTemp.round = true;            
            Debug.Log("Kırmızı top 3 kez sektirdi.");
            StartCoroutine(resetGame("RedSide"));//yeni round için oyun resetleniyor.
            
        }

        else if (round == false && roundEnd == false && ballBounceBlue > 2)
        {
            round = true;  //round sonu.yeni round başlat
            //opTemp.round = true;
            
            StartCoroutine(resetGame("BlueSide"));//yeni round için oyun resetleniyor.
            Debug.Log("Mavi top 3 kez sektirdi.");
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {

        Debug.Log("Top " + coll.gameObject.name + "'e çaptı");
        //txt.text = "Naber";
        if (roundEnd == true)  //oyun resetlendi ve blobby topa çarptı.oyunu başlat.
        {
            roundEnd = false;
            //opTemp.roundEnd = false;
            rb.gravityScale = 0.5f;
            rb.freezeRotation = false;
            
        }

        if(round == false && coll.gameObject.name == "redBlobby" && roundEnd == false)
        {
            ballBounceRed += 1;
            ballBounceBlue = 0;//red topa değdiği için blue'nın sayısı sıfırlanıyor.
        }

        if (round == false && coll.gameObject.name == "blueBlobby" && roundEnd == false)
        {
            ballBounceBlue += 1;
            ballBounceRed = 0;
        }


        if (round == false && coll.gameObject.name=="RedSide" && roundEnd==false)  //Eğer top red side'a düşerse
        {
            round = true;  //round sonu.yeni round başlat
            //opTemp.round = true;
            StartCoroutine(resetGame("RedSide"));//yeni round için oyun resetleniyor.
        }

        else if (round == false && coll.gameObject.name == "BlueSide" && roundEnd == false)  //Eğer top red side'a düşerse
        {
            round = true;  
            StartCoroutine(resetGame("BlueSide"));
        }




    }
    void resetBallPosition()
    {
        
    }


    IEnumerator resetGame(string side)  //Skor yapan oyuncuya puan verir ve oyunu 3 saniyeliğine duraklatır.3 saniye sonunda topu 
    {                                   //default konuma koyar.
        
        if (side=="RedSide") //Red side aleyhine sayı olursa.
        {
            Debug.Log("Bekleme başladı.");
            yield return new WaitForSeconds(3);  //3 saniye bekle
            Debug.Log("Mavi puan kazandı!");
            Debug.Log("Puan Ekle Topu yerleştir.");
            rb.gravityScale = 0; //Yeni oyun başlarken topun havada asılı kalması için.
            rb.velocity = Vector3.zero;
            
            rb.freezeRotation = true;
            transform.position = startPoint;
            roundEnd = true;
            //opTemp.roundEnd = true;
            round = false;
            //opTemp.round = false;
            
            score("Blue");//top red side'a düştüğü için blue'ya puan veriyoruz.
            ballBounceRed = 0;
            
        }
        
        else if(side =="BlueSide")  //Blue side lehine sayı olduğunda
        {
            Debug.Log("Bekleme başladı.");
            yield return new WaitForSeconds(3);  //3 saniye bekle
            Debug.Log("Kırmızı puan kazandı!");
            Debug.Log("Puan Ekle Topu yerleştir.");
            rb.gravityScale = 0; //Yeni oyun başlarken topun havada asılı kalması için.
            rb.velocity = Vector3.zero;
            
            rb.freezeRotation = true;
            transform.position = blueStartPoint;
            roundEnd = true;
            //opTemp.roundEnd = false;
            round = false;
            //opTemp.round = false;
            score("Red");//top red side'a düştüğü için blue'ya puan veriyoruz.
            ballBounceBlue = 0;
        }

       

    }//Reset game sonu

    void score(string side)
    {
        if (side == "Red") //Red side a puan yaz
        {
            scoreTemp = int.Parse(scoreBoardRed.text);            
            scoreTemp += 1;
            scoreBoardRed.text = scoreTemp.ToString();
        }
        else if (side == "Blue")
        {
            scoreTemp = int.Parse(scoreBoardBlue.text);
            scoreTemp += 1;
            scoreBoardBlue.text = scoreTemp.ToString();
        }
        
    }

    public bool getRound()
    {
        return round;
    }
    public bool getRoundEnd()
    {
        return roundEnd;
    }

}
