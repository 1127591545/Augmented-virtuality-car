using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public GameObject wall;
    //public GameObject ground;

    private Rigidbody playerRB;
    private Animator playerAnim;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround;
    public bool ishitwall;

    public float verticalInput;
    public float horizontalInput;

    void Start()
    {

       //bool wall.tag{ };


        isOnGround = true;

        playerRB = GetComponent<Rigidbody>();  //获取了物体的rigidbody
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)       //按下空格键就是跳
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //,不同的forcemode
            isOnGround = false;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            playerAnim.SetTrigger("Jump_trig");
           

        }


        transform.Translate(Vector3.forward * 10 * Time.deltaTime * verticalInput);     //往前往后

        transform.Rotate(Vector3.up * 100 * Time.deltaTime * horizontalInput);          //左右转动

        Debug.Log(horizontalInput);

       
    }


    private void OnCollisionEnter(Collision collision)
    {
      
        if (collision.gameObject.CompareTag("Ground")){

            isOnGround = true;
            Debug.Log("i am on the ground");
        }

        else if (collision.gameObject.CompareTag("wall1"))
        {
            Debug.Log("hit the wall1");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            
        }

        else if (collision.gameObject.CompareTag("wall2"))
        {
            Debug.Log("hit the wall2");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

        }

        else if (collision.gameObject.CompareTag("wall3"))
        {
            Debug.Log("hit the wall3");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

        }

        else if (collision.gameObject.CompareTag("wall4"))
        {
            Debug.Log("hit the wall4");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

        }


    }



}

