using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementController : MonoBehaviour
{

    public float speed = 1;
    private Rigidbody2D rb2d;


    // Start is called before the first frame update
    virtual protected void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    protected void Move(Vector2 movement)
    {
        rb2d.AddForce(movement * speed);
    }

}
