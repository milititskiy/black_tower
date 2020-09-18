using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]


public class PlayerMovementController3D: MonoBehaviour
{

    [SerializeField] AnimationCurve curveY;
    Rigidbody rb;
    Vector3 movement;
    Vector3 currentPos;
    Vector3 landingPos;
    float landingDis;
    public float speed = 1f;
    float timeElapsed = 0f;
    public bool onGround = true;
    bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            JumpHandler();
        }
        else
        {
            MovementHandler();
        }
    }

    void JumpHandler()
    {
        if (onGround)
        {
            currentPos = rb.position;
            landingPos = currentPos + movement.normalized * speed;
            landingDis = Vector3.Distance(landingPos, currentPos);
            timeElapsed = 0f;
            onGround = false;
        }
        else
        {
            timeElapsed += Time.fixedDeltaTime * speed / landingDis;
            if (timeElapsed <= 1f)
            {
                currentPos = Vector3.MoveTowards(currentPos, landingPos, Time.fixedDeltaTime * speed);
                rb.MovePosition(new Vector3(currentPos.x, currentPos.y + curveY.Evaluate(timeElapsed)));
            }
            else
            {
                jump = false;
                onGround = true;
            }
        }
    }

    void MovementHandler()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }


    void InputHandler()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector3(horizontal, vertical);

        if (Input.GetKeyDown("space"))
        {
            jump = true;
        }
    }

}
