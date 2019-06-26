using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Vector3 moveUp;
    Vector3 moveRight;
    Vector3 moveLeft;
    Vector3 moveDown;
    bool isFlying;
    bool isWalking;
    bool isHit;
    Rigidbody2D rb2d;
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    Animator playerAnim;
    Animator swordAnim;
    // Start is called before the first frame update
    void Start()
    {
        moveUp = new Vector3(0, 5.5f, 0);
        moveRight = new Vector3(4.5f, 0, 0);
        moveLeft = new Vector3(-4.5f, 0, 0);
        moveDown = new Vector3(0, -4.5f, 0);
        isFlying = false;
        isWalking = false;
        isHit = false;
        playerAnim = GetComponent<Animator>();
        swordAnim = GameObject.FindGameObjectWithTag("Sword").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -10));
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            transform.position += moveUp;
            isFlying = true;
        }
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            transform.position += moveRight;
            isWalking = true;   
        }
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            transform.position += moveLeft;
        }   
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += moveDown;
        }
        if (isHit == true) 
        {
            //somthing here
         }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Sword")) 
        {
            playerAnim.SetBool("hasSword", true);
            swordAnim.SetBool("pickedUp", true);
        }

        if (collision.CompareTag("Finish"))
        {
            SceneManager.LoadScene("firstLevel", LoadSceneMode.Single);
        }
    }

}
