using UnityEngine;
using System.Collections;

public class Jump_2 : MonoBehaviour
{
    float maxJumpHeight = 3.0f;
    float groundHeight;
    Vector3 groundPos;
    public float jumpSpeed = 7.0f;
    public float fallSpeed = 12.0f;
    public bool inputJump = false;
    public bool grounded = true;

    public float feetDist = 1.0f;



    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //groundPos = transform.position;

        groundPos = player.transform.position;
        groundHeight = transform.position.y;
        maxJumpHeight = transform.position.y + maxJumpHeight;
        
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                //groundPos = transform.position;
                groundPos = player.transform.position;
                
                inputJump = true;
                StartCoroutine("Jump");
                
            }
        }
        


        //Debug.Log(player.transform.position.x);

        //if (transform.position == groundPos)
        //{

        //    grounded = true;
        //}

        //else
        //{
        //    grounded = false;
        //}
        Vector3 forward = transform.TransformDirection(Vector3.down);
        //player.transform.position.y <= 0.15f
        if (Physics.Raycast(transform.position,forward,feetDist))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    //private bool grounded()
    //{
    //    float extraHeight = 0.1f;
    //    RaycastHit raycastHit =  Physics.Raycast(BoxCollider.bounds.center, Vector3.down, BoxCollider.bounds.extents.y + extraHeight);
    //    Color rayColor;
    //    if(raycastHit.collider != null)
    //    {
    //        rayColor = Color.green;
    //    }
    //    else
    //    {
    //        rayColor = Color.red;
    //    }
    //    Debug.DrawRay(BoxCollider.bounds.center, Vector3.down * (BoxCollider.bounds.extents.y + extraHeight));
    //    return raycastHit.collider != null;
    //}

    IEnumerator Jump()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        while (true)
        {
            if (transform.position.y >= maxJumpHeight)
                inputJump = false;
            if (inputJump)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    Debug.Log("W");
                }

                transform.Translate(Vector3.up * jumpSpeed * Time.smoothDeltaTime);
                //if (Input.GetKey(KeyCode.W))
                //{
                //    transform.Translate((Vector3.up + Vector3.right) * jumpSpeed * Time.smoothDeltaTime);
                //}
                //if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space))
                //{
                //    transform.Translate((Vector3.up + Vector3.left) * jumpSpeed * Time.smoothDeltaTime);
                //}
                //if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Space))
                //{
                //    transform.Translate((Vector3.up + Vector3.forward) * jumpSpeed * Time.smoothDeltaTime);
                //}
                //if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Space))
                //{
                //    transform.Translate((Vector3.up + Vector3.back) * jumpSpeed * Time.smoothDeltaTime);
                //}
            }
            else if (!inputJump)
            {
                transform.Translate(Vector3.down * fallSpeed * Time.smoothDeltaTime);
                if (transform.position.y < groundPos.y)
                {
                    //transform.position = groundPos;
                    transform.position = player.transform.position;
                    StopAllCoroutines();
                }
            }

            yield return new WaitForEndOfFrame();
        }
    }
}