﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(Collider))]

public class CameraZones : MonoBehaviour
{
    #region Fields;

    [SerializeField]
    private CinemachineVirtualCamera virtualCamera = null;

    #endregion

    #region MonoBegaviour

    private void Start()
    {
        virtualCamera.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            virtualCamera.enabled = true;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            virtualCamera.enabled = false;
    }

    

    private void OnValidate()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    #endregion

}
