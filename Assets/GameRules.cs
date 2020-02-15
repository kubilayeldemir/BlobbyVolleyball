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
    Canvas canv;
    // Start is called before the first frame update
    void Start()
    {        
        round = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {

        Debug.Log("Top " + coll.gameObject.name + "'e çaptı");
        txt.text = "Naber";
        
        if (round == false && coll.gameObject.name=="RedSide")
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
            yield return new WaitForSeconds(3);
            Debug.Log("Mavi puan kazandı!");
            Debug.Log(round);
        }
        
        else if(side =="BlueSide")
        {
            yield return new WaitForSeconds(3);
            Debug.Log("Kırmızı puan kazandı!");
            Debug.Log(round);
        }
    }


   


}
