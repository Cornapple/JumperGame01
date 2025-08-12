using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Exit")
        {
            Debug.Log("player has hit exit");
        }
    }

    public void OnCollisionEnter2D02(Collision2D collision)
    {
        if (collision.gameObject.name == "WaterDrop")
        {
            Debug.Log("player has hit waterdrop");

        }
    }

    public void OnCollisionEnter2D03(Collision2D collision)
    {

    }
}
