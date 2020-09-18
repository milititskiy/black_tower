using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnotherMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();

        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        //transform.position += movement * Time.deltaTime * moveSpeed;


        Movement();

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector2(0f, 5f), ForceMode.Impulse);
        }
    }

    void Movement()
    {
        Vector3 movement;
        if ((Input.GetKey(KeyCode.W)))
        {
            movement =  Vector3.right;
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
        if ((Input.GetKey(KeyCode.S)))
        {
            movement = Vector3.left;
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
        if ((Input.GetKey(KeyCode.A)))
        {
            movement = Vector3.forward;
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
        if ((Input.GetKey(KeyCode.D)))
        {
            movement = Vector3.back;
            transform.position += movement * Time.deltaTime * moveSpeed;
        }
    }
}
