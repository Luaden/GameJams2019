using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    public GameObject Player;
    public GameObject FriendlySpore;
    public GameObject Contamination;
    public GameObject Spore;
    public float ExistDistanceFromPlayer = 5000f;
    public float RespawnDistance = 2000f;
    public float RepawnMaxDistance = 4000f;
    public float StartingSpawnPosition = 50f;
    public bool worldInitialized = false;

        // Start is called before the first frame update
    void Start()
    {
        InitializeWorld();
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void InitializeWorld()
    {
        int i = 20;
        while (i > 0)
        {
            GenerateRandomCPU(FriendlySpore);
            GenerateRandomCPU(Contamination);
            i--;
        }
        worldInitialized = true;
    }

    

    protected void GenerateRandomCPU(GameObject CPUGO)
    {
        CPUSporeController CPUcontroller = CPUGO.GetComponent<CPUSporeController>();
        if (CPUcontroller == null)
        {
            Debug.LogError("The game object received doesn't have a CPU Controller.");
        }
        else
        {
            
            Instantiate(CPUGO, GenerateRandomPositionRelativeToPlayer(), Quaternion.identity);
            CPUcontroller.Pattern = (MovementPattern)Random.Range(0, System.Enum.GetNames(typeof(MovementPattern)).Length);

        }
    }


    /// <summary>
    /// Return a vector for respawn according to respawn distance (will adjust if game started)
    /// </summary>
    /// <returns></returns>
   protected Vector2 GenerateRandomPositionRelativeToPlayer()
    {
        float respawnDist = GameController.gameStarted ? RespawnDistance : StartingSpawnPosition;
        float d = RepawnMaxDistance - respawnDist;
        return new Vector2(ExtUtil.sign() * (Random.value * d + respawnDist), ExtUtil.sign() * (Random.value * d +  respawnDist)) 
            + (Vector2)GameController.Player.transform.position;
    }

    public void OutOfRange(GameObject CPUGO)
    {
        CPUSporeController CPUcontroller = CPUGO.GetComponent<CPUSporeController>();
        if (CPUcontroller == null)
        {
            Debug.LogError("The game object received doesn't have a CPU Controller.");
        }
        else
        {

            CPUcontroller.Respawn(GenerateRandomPositionRelativeToPlayer());
        }
    }

}
