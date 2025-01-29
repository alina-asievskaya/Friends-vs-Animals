using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower_Pink : MonoBehaviour
{
    public int IncomeValue;
    public float interval;
    public int health;
    public int cost;
    public GameObject object_coin;

    public void Start()
    {
        StartCoroutine(Interval());
    }

    IEnumerator Interval()
    {
        yield return new WaitForSeconds(interval);
        IncreaseIncome();

        StartCoroutine(Interval());
    }

    public void IncreaseIncome()
    {
        GameManager.instance.currency.Gain(IncomeValue);
        StartCoroutine(CoinIndication());
    }

    IEnumerator CoinIndication()
    {
        object_coin.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        object_coin.SetActive(false);

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
