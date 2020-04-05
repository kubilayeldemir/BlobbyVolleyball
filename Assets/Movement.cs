using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 jmpForce = new Vector2(0f, 20f);
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; //Klavyeden sağ sol hareketleri alıyor run speedle hesaplıyor.

        if (Input.GetButtonDown("Jump"))  //karakter zıplama tuşuna basarsa jump true oluyor aşşağıda kodda kullanılıyor.
        {
            jump = true;                  
        }

        /*if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }*/

    }

    void FixedUpdate()
    {
        // Move our character
        //Debug.Log(horizontalMove + "-" + horizontalMove * Time.fixedDeltaTime);
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);   //CharacterController2D ye inputları gönderiyoruz.
        jump = false; //Zıplama bitmesi için false deniliyor.
    }


    //-------------------

    /*rb = GetComponent<Rigidbody2D>();
    transform.Translate(Input.GetAxis("Horizontal") *7* Time.deltaTime, 0f, 0f);
    //transform.Translate(0f, Input.GetAxis("Vertical") * 20* Time.deltaTime, 0f);
    Debug.Log(Input.GetAxis("Vertical"));
    if (Input.GetAxisRaw("Vertical")>0f)
    {
        rb.AddForce(jmpForce*Time.deltaTime);

    }*/










    /*private void FixedUpdate()
        {

            rb = GetComponent<Rigidbody2D>();
            transform.Translate(Input.GetAxis("Horizontal") * 7 * Time.deltaTime, 0f, 0f);
            //transform.Translate(0f, Input.GetAxis("Vertical") * 20* Time.deltaTime, 0f);
            Debug.Log(Input.GetAxis("Vertical"));

            if (Input.GetAxisRaw("Vertical") > 0f)
            {
                rb.AddForce(jmpForce * Time.deltaTime);

            }
        }*/


}
