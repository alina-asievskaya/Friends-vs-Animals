using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Mask : MonoBehaviour
{
    public int health;
    public int cost;

    private void Start()
    {
        
    }

    public void LoseHealth()
    {
        health--;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
