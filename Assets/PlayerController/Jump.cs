using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    //[Range(1, 10)]
    public float jumpvelocity = 12f;

    //public float jumpH;
    //public float jumpForce;
    //private Vector3 jump;
    //private Rigidbody rigg;

    private void Start()
    {
        //jump = new Vector3(0f, jumpH, 0f);
        //rigg = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (Input.GetButton("Jump"))
        {
            //GameObject player = GameObject.FindGameObjectWithTag("Player");
            //player.GetComponentInChildren<Rigidbody>().velocity = Vector3.up * jumpvelocity;

            GetComponent<Rigidbody>().velocity = Vector3.up * jumpvelocity;
            Debug.Log("Jump");

        }

        //if (rigg.velocity.y == 0)
        //{
        //    if (Input.GetButton("Jump"))
        //    {
        //        rigg.AddForce(jump * jumpForce, ForceMode.Impulse);
        //    }
        //}

    }
}
