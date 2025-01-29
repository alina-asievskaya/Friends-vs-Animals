using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CostDisplayer : MonoBehaviour
{
    public int towerID;
    public int towerCost;
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        // Получаем компонент TextMeshProUGUI
        textMeshPro = GetComponent<TextMeshProUGUI>();

        // Получаем стоимость башни
        towerCost = GameManager.instance.spawner.TowerCost(towerID);

        // Устанавливаем текст
        textMeshPro.text = towerCost.ToString();
    }
}
