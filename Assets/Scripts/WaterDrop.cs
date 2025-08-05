using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    public GameObject waterDrop;
    public PlayerStats playerStats;
    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("player has collided with waterdrop");
    //    if (waterDrop != null && collision.gameObject.tag == "Collectable")
    //    {
    //        timer = GetComponent<Timer>();
    //        timer = new Timer();
    //    }
    //}
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Example using GetComponent
        Timer timer = collision.gameObject.GetComponent<Timer>();

        if (timer != null)
        {
            // Call a public method in OtherScript
            timer.remainingTime = 45f;

            
        }
    }
}
