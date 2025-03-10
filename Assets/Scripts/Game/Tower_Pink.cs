using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower_Pink : Tower
{
    public int IncomeValue;
    public float interval;
    
    public GameObject object_coin;
    //public GameObject object_delete;


    protected override void Start()
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

    //private void OnMouseDown()
    //{
    //    object_delete.SetActive(true); // Показываем кнопку удаления
    //    Button deleteButton = object_delete.GetComponent<Button>();

    //    if (deleteButton != null)
    //    {
    //        deleteButton.onClick.RemoveAllListeners();
    //        deleteButton.onClick.AddListener(DeleteTower);
    //        Debug.Log("Delete button listener added.");
    //    }
    //    else
    //    {
    //        Debug.LogError("Button component is missing on the delete button object!");
    //    }
    //}

    //public void DeleteTower()
    //{
    //    Debug.Log("DeleteTower called.");
    //    Destroy(gameObject);
    //    object_delete.SetActive(false);
    //}

}
