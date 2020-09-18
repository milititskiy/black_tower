using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float rightLimit = 6.5f;
    public float leftLimit = -6.5f;
    public float speed = 2.0f;
    private int direction = 1;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        platformMove();
        
    }

    void platformMove()
    {
        if (transform.position.x > rightLimit)
        {
            direction = -1;
        }
        else if (transform.position.x < leftLimit)
        {
            direction = 1;
        }
        movement = Vector3.right * direction * speed * Time.deltaTime;
        transform.Translate(movement);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Collider childeren = other.GetComponentInChildren<Collider>();
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entered the box");
            other.transform.parent = transform;

        }

        
    }


    

    private void OnTriggerExit(Collider other)
    {
        //    Debug.Log("Exit happened");
        //other.transform.parent = null;
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entered the box");
            other.transform.parent = null;
        }
    }
}
