using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CostDisplayer : MonoBehaviour
{
    public int towerID;
    public int towerCost;
    private TextMeshProUGUI textMeshPro;
    public TMP_Text currencyMoney;

    void Start()
    {
        // Получаем компонент TextMeshProUGUI
        textMeshPro = GetComponent<TextMeshProUGUI>();

        // Получаем стоимость башни
        towerCost = GameManager.instance.spawner.TowerCost(towerID);

        int currentMoney = int.Parse(currencyMoney.text);

        if (towerCost > currentMoney)
        {
            textMeshPro.color = Color.red; // Устанавливаем цвет текста в красный
        }
        else
        {
            textMeshPro.color = Color.white; // Устанавливаем цвет текста в белый
        }

        // Устанавливаем текст
        textMeshPro.text = towerCost.ToString();
    }
}
