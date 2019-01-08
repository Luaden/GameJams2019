using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public float maxSpeed = 5;
    public float acceleration = 10;

    [Tooltip("The size of the spore")]
    public int Growth = 1;
    public int MaxGrowth = 10;

    private Rigidbody2D rb2d;


    // Start is called before the first frame update
    virtual protected void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GrowthResizing();
    }
    /// <summary>
    /// AddForce movement * speed to max speed
    /// </summary>
    /// <param name="movement"></param>
    protected void Move(Vector2 movement)
    {
        movement.Normalize();
        if (rb2d.velocity.magnitude < maxSpeed)
        {
            rb2d.AddForce(movement * acceleration);
        }
        else
        { 
            //rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxSpeed);
        }

    }

    virtual protected void Grow(int number)
    {

        Growth += number;
        if(Growth>MaxGrowth) Growth = MaxGrowth;
        //if (Growth <= 0) Die();
        GrowthResizing();
        
    }
    
    /// <summary>
    /// Will change the size of the spore according to its growth level
    /// </summary>
    protected void GrowthResizing()
    {
        transform.localScale = new Vector3(Growth * 7, Growth * 7, Growth * 7);
    }

    public virtual void Die()
    {
        this.gameObject.SetActive(false);
        Debug.Log(this + "Set Inactive");
    }
}
