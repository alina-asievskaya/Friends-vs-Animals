 using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int health;
    public int cost;

    protected virtual void Start()
    {

    }

    public  virtual bool LoseHealth(int amount)
    {
        health-=amount;

        if (health <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
