using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 1;
    public PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("enemy has collided with player");
            playerStats = null;
            if (playerStats == null)
            {
                playerStats = collision.gameObject.GetComponent<PlayerStats>();
                playerStats.TakeDamage(damage);
                Debug.Log("enemy has damaged player");
            }
        }
    }
}
