using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public GameObject player;
    public float FollowSpeed = 15;
    public float LagDistance = 25;

    private Vector3 camFollowPos;
    private Vector3 offset;
    private float xDistance;
    private float yDistance;


    void Start()
    {
        transform.position = new Vector3(GameController.Player.transform.position.x, 
                                         GameController.Player.transform.position.y, transform.position.z);
        offset = transform.position - GameController.Player.transform.position;
    }

    void Update()
    {
        RubberCamera();
    }


    Vector3 currentVelo = new Vector3();
    void RubberCamera()
    {
        xDistance = Mathf.Abs(transform.position.x - GameController.Player.transform.position.x);
        yDistance = Mathf.Abs(transform.position.y - GameController.Player.transform.position.y);
        
        /*
        if (xDistance >= LagDistance || yDistance >= LagDistance)
        {*/
            camFollowPos = Vector3.SmoothDamp (transform.position,
            GameController.Player.transform.position + offset, ref currentVelo, FollowSpeed);

            //camFollowPos.x = Mathf.Clamp(camFollowPos.x, -41f, 43.5f);
            //camFollowPos.y = Mathf.Clamp(camFollowPos.y, -39f, 58f);

            transform.position = camFollowPos;
        //}
            
    }
}
