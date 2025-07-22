using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public int playerHealth;
    public int maxHealth = 5;

    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(playerHealth / maxHealth, 0, 5);


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

