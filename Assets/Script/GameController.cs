using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameObject Player;
    public static GameController gameController;


    private void Awake()
    {
        if (gameController == null)
        {
            gameController = this;
        }
        else Destroy(gameObject);
        Player = FindObjectOfType<PlayerController>().gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
