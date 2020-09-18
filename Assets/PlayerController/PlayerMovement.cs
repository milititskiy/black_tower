using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 120f;
    [SerializeField]
    float rayLenght = 1.4f;
    [SerializeField]
    float rayOffsetX = 0.5f;
    [SerializeField]
    float rayOffsetY = 0.5f;
    [SerializeField]
    float rayOffsetZ = 0.5f;
    public float gridSize = 1.0f;
    
    Vector3 targetPosition;
    Vector3 startPosition;

    

    bool moving;

    // Update is called once per frame
    void Update()
    {

        //Move();
        //Movement();


    }

    private void FixedUpdate()
    {
        Move();
    }


    void Move()
    {
        if (moving)
        {



            if (Vector3.Distance(startPosition, transform.position) > 1.0f)
            {
                transform.position = targetPosition;
                moving = false;
                return;
            }
                

            transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
            return;
        }
                
                
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W input");
            if (CanMove(Vector3.right))
            {
                targetPosition = transform.position + Vector3.right;
                startPosition = transform.position;
                moving = true;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (CanMove(Vector3.left))
            {
                
                targetPosition = transform.position + Vector3.left;
                startPosition = transform.position;
                moving = true;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (CanMove(Vector3.forward))
            {
                targetPosition = transform.position + Vector3.forward;
                startPosition = transform.position;
                moving = true;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (CanMove(Vector3.back))
            {
                targetPosition = transform.position + Vector3.back;
                startPosition = transform.position;
                moving = true;
            }
        }
    }

    void Movement()
    {
        Vector3 movement;
        if ((Input.GetKey(KeyCode.W)))
        {
            Debug.Log("W input");
            if (CanMove(Vector3.right))
            {
                movement = Vector3.right;
                transform.position += movement * Time.deltaTime * moveSpeed;
            }

        }
        if ((Input.GetKey(KeyCode.S)))
        {
            if (CanMove(Vector3.left))
            {
                movement = Vector3.left;
                transform.position += movement * Time.deltaTime * moveSpeed;
            }

        }
        if ((Input.GetKey(KeyCode.A)))
        {
            if (CanMove(Vector3.forward)) { 
                movement = Vector3.forward;
                transform.position += movement * Time.deltaTime * moveSpeed;
            }
        }
        if ((Input.GetKey(KeyCode.D)))
        {
            if (CanMove(Vector3.back))
            {
                movement = Vector3.back;
                transform.position += movement * Time.deltaTime * moveSpeed;

            }
        }
    }













    bool CanMove(Vector3 direction) { 
    
        if(Vector3.Equals(Vector3.forward,direction) || Vector3.Equals(Vector3.back, direction)){
            if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX, direction, rayLenght)) return false;
            if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX, direction, rayLenght)) return false;
        }
        else if (Vector3.Equals(Vector3.left, direction) || Vector3.Equals(Vector3.right, direction)){
                if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ, direction, rayLenght)) return false;
                if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ, direction, rayLenght)) return false;
            }

        
        return true;
    }

        

        
    
}

static class ExtensionMethods
{
    /// <summary>
    /// Rounds Vector3.
    /// </summary>
    /// <param name="vector3"></param>
    /// <param name="decimalPlaces"></param>
    /// <returns></returns>
    public static Vector3 Round(this Vector3 vector3, int decimalPlaces = 2)
    {
        float multiplier = 1;
        for (int i = 0; i < decimalPlaces; i++)
        {
            multiplier *= 10f;
        }
        
        Vector3 nVec = new Vector3(
            Mathf.RoundToInt(vector3.x * multiplier) / multiplier,
            Mathf.RoundToInt(vector3.y * multiplier) / multiplier,
            Mathf.RoundToInt(vector3.z * multiplier) / multiplier);
        

        return new Vector3(
            Mathf.RoundToInt(vector3.x * multiplier) / multiplier,
            Mathf.RoundToInt(vector3.y * multiplier) / multiplier,
            Mathf.RoundToInt(vector3.z * multiplier) / multiplier);
        
       
        
    }
}