using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    public int playerHealth;
    public int maxHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
   

    }

    public void TakeDamage(int amount)
    {
        playerHealth -= amount;

        if(playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

 
}

