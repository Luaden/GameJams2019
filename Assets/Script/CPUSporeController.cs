using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementPattern { StraightLine, Spiral, Zigzag, Follow };
public enum Team { Friend, Contam};

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
    protected float timer = 0f;
    protected float angle = 0f;
    protected float radius = 1000f;
    


    [Header("Follow Settings")]
    public float DistanceToStartFollowing = 100f;
    public float DistanceToStopFollowing = 0f;
    [Header("Spiral Settings")]
    
    Vector2 _centerSpiral;
    /// <summary>
    /// clock or anticlockwise
    /// </summary>
    float _directionSpiral;


    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start();
        FirstInitialization();
    }

    void FirstInitialization()
    {
        RegisterToGenerator();
        Spawn();
    }

    protected void Spawn()
    {
        
        randomDirection = ExtUtil.RandomUnitVector2();
        _centerSpiral = new Vector2(transform.position.x + 1, transform.position.y + 1);
        _directionSpiral = ExtUtil.sign();
    }

    public void Respawn(Vector2 pos)
    {
        transform.position = pos;
        Spawn();
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
        else if(Pattern == MovementPattern.Spiral)
        {

            
            Vector2 rayon = (Vector2)transform.position - _centerSpiral;
            Vector2 direction = new Vector2(_directionSpiral * rayon.y, - _directionSpiral * rayon.x);
            Move(direction);

        }
        else if(Pattern == MovementPattern.Zigzag)
        {
            timer += Time.deltaTime;
            if(timer > 10f)
            {

            }
        }
        if(distance > GameController.generator.ExistDistanceFromPlayer)
        {
            GameController.generator.OutOfRange(gameObject);
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

    public void RemoveSpore()
    {
        UnregisterToGenerator();
        Destroy(gameObject);
    }

    virtual protected void RegisterToGenerator()
    {
        Debug.LogError("This cannot be registered");
    }

    virtual protected void UnregisterToGenerator()
    {
        Debug.LogError("This cannot be unregistered");
    }

    private void OnDrawGizmos()
    {
        if (Pattern == MovementPattern.Spiral)
        {
            Gizmos.color = new Color(125, 125, 125, 0.1f);
            Gizmos.DrawLine(_centerSpiral, transform.position);
        }
    }
}
