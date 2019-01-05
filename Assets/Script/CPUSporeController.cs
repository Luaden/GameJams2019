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
        if (Pattern == MovementPattern.StraightLine)
        {
            Move(randomDirection);
        }
        else if (Pattern == MovementPattern.Follow)
        {
            float distance = Vector3.Distance(GameController.Player.transform.position, transform.position);
            if (DistanceToStartFollowing >= distance
                && DistanceToStopFollowing <= distance)
            {
                Vector2 direction =
                    (Vector2)GameController.Player.transform.position - (Vector2)transform.position;
                Move(direction);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
