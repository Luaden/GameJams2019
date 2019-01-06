using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementPattern { StraightLine, Circle, Random, Follow };

/// <summary>
/// Basic movement for computer either for friendly or contam spore
/// </summary>
public class CPUSporeController : MovementController
{

    public MovementPattern Pattern = MovementPattern.StraightLine;
    public float ExistDistanceFromPlayer = 5000f;
    public float RespawnDistance = 2000f;
    
    /// <summary>
    /// Defined in Start
    /// </summary>
    protected Vector2 randomDirection;
    
    [Header("Follow Settings")]
    public float DistanceToStartFollowing = 100f;
    public float DistanceToStopFollowing = 0f;

    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        randomDirection = ExtUtil.RandomUnitVector2();
    }

    private void FixedUpdate()
    {
        float distance = DistanceFromPlayer();
        if (Pattern == MovementPattern.StraightLine)
        {
            Move(randomDirection);
        }
        else if (Pattern == MovementPattern.Follow)
        {
            
            if (DistanceToStartFollowing >= distance
                && DistanceToStopFollowing <= distance)
            {
                Vector2 direction =
                    (Vector2)GameController.Player.transform.position - (Vector2)transform.position;
                Move(direction);
            }
        }
        Debug.Log(distance);
        if(distance > ExistDistanceFromPlayer)
        {
            Debug.Log("in");
            Respawn();
        }


    }

    public float DistanceFromPlayer()
    {
        return Vector3.Distance(GameController.Player.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void RemoveSpore()
    {
        Destroy(gameObject);
    }

    protected void Respawn()
    {
        transform.position = new Vector2(ExtUtil.sign() * Random.value, ExtUtil.sign() * Random.value) * RespawnDistance + (Vector2)GameController.Player.transform.position;
    }
}
