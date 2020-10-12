using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    Vector2 movement;
    public float moveSpeed = 8f;
    public float jumpVelocity = 8f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float dashTime;
    public float dashSpeed = 50f;
    public float startDashTime = 0.1f;
    public float distance = 10f;
    private BoxCollider boxCollider;
    public InputMaster _controls;

    

    public float upMultiplier = 2f;
    public float physicMultiplier = 2f;
    
    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _controls = new InputMaster();
        _controls.Player.Fire.performed += OnFire;
        _controls.Player.Jump.performed += OnJump;
        _controls.Player.Dash.performed += OnDash;
        

    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        dashTime = startDashTime;
    }

    private void OnDash(InputAction.CallbackContext context)
    {
        var mvm = _controls.Player.Movement.ReadValue<Vector2>();
        
        if (dashTime <= 0)
        {
            dashTime = startDashTime;
            rb.velocity = Vector3.zero;
        }
        else
        {
            dashTime -= Time.deltaTime * 10;
            var direction = OnDirection(mvm);
            transform.position += direction * distance * dashTime;
            
        }
    }

    //private void OnDirection( Vector2 mvm)
    //{
    //    if (mvm.y == 1)
    //    {
    //        transform.position += Vector3.right * distance;
    //        //rb.velocity = Vector3.right * dashTime * dashSpeed;
    //    }
    //    else if (mvm.y == -1)
    //    {
    //        transform.position += Vector3.left * distance;
    //        //rb.velocity = Vector3.left * dashTime * dashSpeed;
    //    }
    //    else if (mvm.x == 1)
    //    {
    //        transform.position += Vector3.back * distance;
    //        //rb.velocity = Vector3.back * dashTime * dashSpeed;
    //    }
    //    else if (mvm.x == -1)
    //    {
    //        transform.position += Vector3.forward * distance;
    //        //rb.velocity = Vector3.forward * dashTime * dashSpeed;
    //    }

    //}

    private Vector3 OnDirection(Vector2 direction)
    {
        
        if (direction.y == 1)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            return Vector3.right;
        }
        else if (direction.y == -1)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            return  Vector3.left;
        }
        else if (direction.x == 1)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            return Vector3.back;
        }
        else if (direction.x == -1)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            return Vector3.forward;
        }
        return Vector3.zero;
    }


    private void Update()
    {
        //OnMove(_controls.Player.Movement.ReadValue<Vector2>());
        //OnDash(_controls.Player.Dash.ReadValue<Vector2>());

        if (rb.velocity.y < 0)
        {
            rb.velocity += (Vector3.up) * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        //else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        //{
        //    rb.velocity += (Vector3.up) * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        //}
    }

   



    private void OnJump(InputAction.CallbackContext context)
    {
        var mvm = _controls.Player.Movement.ReadValue<Vector2>();
        var jump = _controls.Player.Jump.ReadValue<float>();
        var direction = OnDirection(mvm);
        

        if (IsGrounded())
        {

            //GetComponent<Rigidbody>().AddForce((Vector3.up) * 12 + (direction) * jumpVelocity, ForceMode.VelocityChange);
            rb.AddForce((Vector3.up) * 12 + (direction) * jumpVelocity, ForceMode.VelocityChange);

            

        }
       
        else if (!IsGrounded()){

            //rb.velocity -= (Vector3.down) + direction * (Physics.gravity.y * physicMultiplier)  * Time.deltaTime;
           
        }
    }    
        
       
            
           
        


    private void OnMove(Vector2 context)
    {
        var trans = transform.position;
        
        if (IsGrounded())
        {

            trans += context.y * transform.right * Time.fixedDeltaTime * moveSpeed;
            trans -= context.x * transform.forward * Time.fixedDeltaTime * moveSpeed;
            transform.position = trans;

        }
        else
        {   
            //trans += context.y * transform.right * Time.fixedDeltaTime * moveSpeed;
            //trans -= context.x * transform.forward * Time.fixedDeltaTime * moveSpeed;
            //transform.position = trans;
        }
    }
    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }


    void OnFire(InputAction.CallbackContext context)
    {
        //Debug.Log("Jump pressed");
        
    }

    private bool IsGrounded()
    {
        float extraHeightText = 0.5f;
        var raycastHit = Physics.Raycast(transform.position, Vector3.down, extraHeightText);
        return raycastHit != false;
    }

        

       
}
