using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContaminationController : CPUSporeController
{

    private void Awake()
    {
        team = Team.Contam;
    }

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
        MovementController mc = collision.gameObject.GetComponent<MovementController>();
        if (mc != null && mc.team != Team.Contam)
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
