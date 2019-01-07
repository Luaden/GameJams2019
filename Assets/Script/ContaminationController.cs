using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContaminationController : CPUSporeController
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

    override protected void RegisterToGenerator()
    {
        GameController.generator.ContaminationList.Add(gameObject);
    }
    override protected void UnregisterToGenerator()
    {
        GameController.generator.ContaminationList.Remove(gameObject);
    }


}
