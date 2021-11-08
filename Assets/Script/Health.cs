using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int heathAmount = 1;

    public void GainHealth()
    {
        FindObjectOfType<PlayerController>().GetComponent<Damegeable>().SetHealth(heathAmount);
    }
}
