using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MovementController
{


    public GameObject Mushroom;
    public GameObject respawnMenu;
    //public GameObject soundNewTry;
    public AudioSource sFXAudioSource;
    public SoundController soundController;


    // Start is called before the first frame update
    override protected void Start()
    {
        base.Start(); // Get rg2b component
        //soundController = new SoundController();
    }

    private void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        Move(movement);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        FriendlySporeController FriendlySpore = collision.gameObject.GetComponent<FriendlySporeController>();
        ContaminationController Contamination = collision.gameObject.GetComponent<ContaminationController>();
        sFXAudioSource = gameObject.GetComponent<AudioSource>();
        


        if (FriendlySpore != null)
        {
            Debug.Log("We're here.");
            Grow(FriendlySpore.Growth);
            soundController.GrowthClip();

        }
        else if (Contamination != null && Growth > 1)
        {
            Grow(-1);
            soundController.ShrinkClip();

        }
        else if (Contamination != null && Growth <= 1)
        {
            Grow(-1);
            soundController.DeathClip();
            Die();
        }
    }

    protected override void Grow(int number)
    {
        base.Grow(number);
        if(Growth == MaxGrowth)
        {
            GrowIntoMushroom();
            soundController.RespawnClip();

        }
    }

    protected void GrowIntoMushroom()
    {
        Instantiate(Mushroom,transform.position,Quaternion.identity);
        gameObject.SetActive(false);
        
    }
    public override void Die ()
    {
   
        base.Die();
        Debug.Log("Player died.");
        respawnMenu.SetActive(true);
    }

        
}
