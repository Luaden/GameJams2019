using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float stretchTime;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        RubberCamera();
    }

    void RubberCamera()
    {
        transform.position = Vector3.Lerp(transform.position,
            player.transform.position + offset, stretchTime * Time.deltaTime);
    }
}
