﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightingPlant : MonoBehaviour
{

    [SerializeField]
    public GameObject pickUpText;

    private bool pickUpAllowed;

    // Use this for initialization
    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        Destroy(gameObject);
    }

}
