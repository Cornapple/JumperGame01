using System.Collections;
using System.Collections.Generic;
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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (waterDrop != null)
        {
            
        }
    }


    //public void OnCollisionEnter2D()
    //{
    //    if (waterDrop != null)
    //        remainingTime = maxTime;
    //    return;
    //}
}
