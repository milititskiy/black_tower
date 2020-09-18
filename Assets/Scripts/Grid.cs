using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    //Player Movement
    //
    public GameObject structure;
    public GameObject gridTarget;
    Vector3 truePos;
    public float gridSize;

    public void LateUpdate()
    {


        truePos.x = Mathf.Floor(gridTarget.transform.position.x / gridSize) * gridSize;
        truePos.y = Mathf.Floor(gridTarget.transform.position.y / gridSize) * gridSize;
        truePos.z = Mathf.Floor(gridTarget.transform.position.z / gridSize) * gridSize;
        
        structure.transform.position = truePos;




    }
}
