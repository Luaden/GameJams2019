﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MovementController
{

    public GameObject Mushroom;

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start(); // Get rg2b component 
    }

    private void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        Move(movement);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FriendlySporeController FriendlySpore = collision.gameObject.GetComponent<FriendlySporeController>();
        ContaminationController Contamination = collision.gameObject.GetComponent<ContaminationController>();
        if (FriendlySpore != null)
        {
            Grow(FriendlySpore.Growth);

        }
        else if (Contamination != null)
        {
            Grow(-1);
        }
    }

    protected override void Grow(int number)
    {
        base.Grow(number);
        if(Growth == MaxGrowth)
        {
            GrowIntoMushroom();
        }
    }

    protected void GrowIntoMushroom()
    {
        Instantiate(Mushroom,transform.position,Quaternion.identity);
        gameObject.SetActive(false);
    }
}
