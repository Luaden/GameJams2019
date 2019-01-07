using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public GameObject player;
    public float FollowSpeed = 15;

    private Vector3 offset;

    void Start()
    {
        transform.position = new Vector3(GameController.Player.transform.position.x, GameController.Player.transform.position.y, transform.position.z);
        offset = transform.position - GameController.Player.transform.position;
    }

    void Update()
    {
        RubberCamera();
    }


    Vector3 currentVelo = new Vector3();
    void RubberCamera()
    {
        transform.position = Vector3.SmoothDamp(transform.position,
            GameController.Player.transform.position + offset, ref currentVelo, FollowSpeed);
    }
}
