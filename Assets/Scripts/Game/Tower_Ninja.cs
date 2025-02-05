using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Ninja : Tower
{
    public int damage;
    public GameObject shootItemPrefab;
    public float interval;

    protected override void Start()
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

}
