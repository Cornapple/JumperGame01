using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerController : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;

    [SerializeField] UnityEvent onTriggerExit;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        onTriggerEnter.Invoke();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        onTriggerExit.Invoke();
    }


}
