using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    //public GameObject Player;
    public GameObject FriendlySpore;
    public GameObject Contamination;
    public GameObject Spore;
    [Header("Spawning")]
    public float ExistDistanceFromPlayer = 5000f;
    public float RespawnDistance = 2000f;
    public float RepawnMaxDistance = 4000f;
    public float StartingSpawnPosition = 50f;
    [Header("Quantity")]
    public int minimumFriendlySpore = 25;
    public int minimumContam = 25;
    

    public bool worldInitialized = false;

    public List<GameObject> FriendlySporeList = new List<GameObject>();
    public List<GameObject> ContaminationList = new List<GameObject>();
    //List<GameObject> SporeList = new List<GameObject>();

        // Start is called before the first frame update
    void Start()
    {
        InitializeWorld();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.Player.GetComponent<PlayerController>().sporulate)
        {
            if (FriendlySporeList.Count < minimumFriendlySpore + GameController.Player.GetComponent<PlayerController>().numMushroom)
            {
                GenerateRandomCPU(FriendlySpore);
            }
            if (ContaminationList.Count < minimumContam + GameController.Player.GetComponent<PlayerController>().numMushroom *3)
            {
                GenerateRandomCPU(Contamination);
            }
        }
        else
        {
            EmptyLevel();
        }
    }

    void EmptyLevel()
    {
        while(FriendlySporeList.Count > 0)
        {
            FriendlySporeList[FriendlySporeList.Count - 1].GetComponent<CPUSporeController>().RemoveSpore();
        }
        while (ContaminationList.Count > 0)
        {
            ContaminationList[ContaminationList.Count - 1].GetComponent<CPUSporeController>().RemoveSpore();
        }
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

    

    protected GameObject GenerateRandomCPU(GameObject CPUGO)
    {
        CPUSporeController CPUcontroller = CPUGO.GetComponent<CPUSporeController>();
        if (CPUcontroller == null)
        {
            Debug.LogError("The game object received doesn't have a CPU Controller.");
        }
        else
        {

            GameObject go = Instantiate(CPUGO, GenerateRandomPositionRelativeToPlayer(), Quaternion.identity);
            CPUcontroller = go.GetComponent<CPUSporeController>();


            CPUcontroller.Pattern = (MovementPattern)Random.Range(0, System.Enum.GetNames(typeof(MovementPattern)).Length);
            float newSpeed = (CPUcontroller.team == Team.Friend ? 3 : 10)
                + (GameController.Player.GetComponent<PlayerController>().numMushroom * GameController.Player.GetComponent<PlayerController>().numMushroom) * 3;

            CPUcontroller.acceleration = newSpeed;
            CPUcontroller.maxSpeed = (CPUcontroller.team == Team.Friend ? 3 : 10)
                + (GameController.Player.GetComponent<PlayerController>().numMushroom * GameController.Player.GetComponent<PlayerController>().numMushroom)*3;
            if (CPUcontroller.team == Team.Contam)
            {
                CPUcontroller.Growth = CPUcontroller.Growth + GameController.Player.GetComponent<PlayerController>().numMushroom;
                CPUcontroller.GrowthResizing();
            }
            return go;
        }
        return null;
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
