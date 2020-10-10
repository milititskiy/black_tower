using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 20f;
    public float jumpVelocity = 7f;
    [SerializeField] private LayerMask groundLayerMask;
    private Vector3 movement;
    private BoxCollider boxCollider;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float dashSpeed = 50f;

    public float dashTime;
    public float startDashTime = 0.1f;
    private int direction;


    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = transform.GetComponent<BoxCollider>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        Dash();
        Movement();
        Jump();

        if (rb.velocity.y < 0)
        {
            rb.velocity += (Vector3.up * 4) * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime / 2;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += (Vector3.up * 4) * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime / 2;
        }

       

    }

    private void FixedUpdate()
    {
        //Movement();
        //Jump();

    }

    void Dash()
    {
        
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                //Debug.Log(Input.GetKeyDown(KeyCode.LeftShift));
                Debug.Log(Input.GetButton("left shift"));
                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.S) )
            {
                direction = 2;
            }
            else if (Input.GetKeyDown(KeyCode.A) )
            {
                direction = 3;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                direction = 4;
            }
        }
        
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector3.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
                if (direction == 1)
                {
                    transform.position += Vector3.right * dashTime * dashSpeed;
                    rb.velocity = Vector3.right * dashTime *  dashSpeed;
                }
                else if (direction == 2)
                {
                    transform.position += Vector3.left * dashTime * dashSpeed;
                    rb.velocity = Vector3.left * dashTime * dashSpeed;
                }
                else if (direction == 3)
                {
                    transform.position += Vector3.forward * dashTime * dashSpeed;
                    rb.velocity = Vector3.forward * dashTime * dashSpeed;
                }
                else if (direction == 4)
                {
                    transform.position += Vector3.back * dashTime * dashSpeed;
                    rb.velocity = Vector3.back * dashTime * dashSpeed;
                }
            }
        }
        //Debug.Log(direction);
    }

    void Jump()
    {
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            //gameObject.GetComponent<Rigidbody>().AddForce((Vector3.up + movement), ForceMode.Impulse);
            //GetComponent<Rigidbody>().velocity = ((Vector3.up * 4 ) + movement) * jumpVelocity;
            GetComponent<Rigidbody>().AddForce(((Vector3.up * 2) + movement) * jumpVelocity, ForceMode.Impulse);
            transform.position += movement * Time.fixedDeltaTime / 2;

        }

        movement = Vector3.zero;



    }

    private bool IsGrounded()
    {

        float extraHeightText = 0.5f;
        //RaycastHit raycastHit = Physics.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, Vector3.down,,extraHeightText, groundLayerMask);
        //RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraHeightText, groundLayerMask);
        //RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + extraHeightText, groundLayerMask);

        var raycastHit = Physics.Raycast(transform.position, Vector3.down, extraHeightText);
        //Debug.Log(Physics.OverlapBox(boxCollider.bounds.center, boxCollider.bounds.size, Quaternion.identity, groundLayerMask));
        //Debug.Log(Physics.Raycast(transform.position, Vector3.down, extraHeightText));
        Color rayColor;
        if (raycastHit)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(boxCollider.bounds.center, Vector2.down * (boxCollider.bounds.extents.y + extraHeightText), rayColor);
        //Debug.Log(raycastHit);
        return raycastHit != false;
    }





    void Movement()
    {

        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    //GetComponent<Rigidbody>().AddForce(Vector3.left * dashTime, ForceMode.Impulse);
        //    //transform.position += movement * Time.deltaTime * dashTime;
        //    rb.AddForce(transform.right * dashTime, ForceMode.Impulse);
        //    //rb.useGravity = true;
        //}

        if (Input.GetKey(KeyCode.W))
        {
            movement = Vector3.right;
            if (IsGrounded())
            {
                transform.position += movement * Time.fixedDeltaTime * moveSpeed;
            }
            else
            {
                transform.position += movement * (Time.fixedDeltaTime / 2) * moveSpeed;
            }

        }
        if (Input.GetKey(KeyCode.S))
        {
            movement = Vector3.left;
            if (IsGrounded())
            {
                transform.position += movement * Time.fixedDeltaTime * moveSpeed;
            }
            else
            {
                transform.position += movement * (Time.fixedDeltaTime / 2) * moveSpeed;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement = Vector3.forward;
            if (IsGrounded())
            {
                transform.position += movement * Time.fixedDeltaTime * moveSpeed;
            }
            else
            {
                transform.position += movement * (Time.fixedDeltaTime / 2) * moveSpeed;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement = Vector3.back;
            if (IsGrounded())
            {
                transform.position += movement * Time.fixedDeltaTime * moveSpeed;
            }
            else
            {
                transform.position += movement * (Time.fixedDeltaTime / 2) * moveSpeed;
            }
        }
    }

}




