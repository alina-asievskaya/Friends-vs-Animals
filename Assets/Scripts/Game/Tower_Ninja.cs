using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Ninja : MonoBehaviour
{
    public int health;
    public int cost;
    public int damage;
    public GameObject shootItemPrefab;
    public float interval;

    void Start()
    {
        StartCoroutine(ShootDelay());
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(interval);
        ShootItem();
        StartCoroutine(ShootDelay());
    }

    void ShootItem()
    {
        GameObject ShootItem = Instantiate(shootItemPrefab, transform);

        ShootItem.GetComponent<ShootItems>().Init(damage);
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
