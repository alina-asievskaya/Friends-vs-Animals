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
        // �������� ��������� TextMeshProUGUI
        textMeshPro = GetComponent<TextMeshProUGUI>();

        // �������� ��������� �����
        towerCost = GameManager.instance.spawner.TowerCost(towerID);

        // ������������� �����
        textMeshPro.text = towerCost.ToString();
    }
}
