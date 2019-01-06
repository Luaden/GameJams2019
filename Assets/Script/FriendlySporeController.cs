using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Indiquates that it is a friendly spore
/// </summary>
public class FriendlySporeController : CPUSporeController
{

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MovementController>() != null)
        {
            RemoveSpore();
        }
    }

}
