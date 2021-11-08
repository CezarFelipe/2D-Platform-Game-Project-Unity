using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool singleUser;

    public UnityEvent OnTrigger;
    public UnityEvent OnExit;


    private bool used;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (used)
        {
            return;
        }
        if (singleUser)
        {
            used = true;
        }

        OnTrigger.Invoke();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (singleUser)
        {
            return;
        }
        OnExit.Invoke();

    }
}
