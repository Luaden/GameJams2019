using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public float maxSpeed = 3;

    [Tooltip("The size of the spore")]
    public int Growth = 3;
    public int MaxGrowth = 10;

    private Rigidbody2D rb2d;


    // Start is called before the first frame update
    virtual protected void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        InitGrowthResizing();
    }
    /// <summary>
    /// AddForce movement * speed to max speed
    /// </summary>
    /// <param name="movement"></param>
    protected void Move(Vector2 movement)
    {
        rb2d.AddForce(movement * maxSpeed);
        // Limit max speed
        if (rb2d.velocity.magnitude >= maxSpeed)
        {
            rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxSpeed);
        }

    }

    protected void Grow(int number)
    {


        Growth += number;
        if(Growth>MaxGrowth) Growth = MaxGrowth;
        InitGrowthResizing();
        
    }

    /// <summary>
    /// Will change the size of the spore according to its growth level
    /// </summary>
    protected void InitGrowthResizing()
    {
        transform.localScale = new Vector3(Growth * 11, Growth * 11, Growth * 11);
    }

}
