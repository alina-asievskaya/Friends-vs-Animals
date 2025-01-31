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
        // �������� ��������� TextMeshProUGUI
        textMeshPro = GetComponent<TextMeshProUGUI>();

        // �������� ��������� �����
        towerCost = GameManager.instance.spawner.TowerCost(towerID);

        int currentMoney = int.Parse(currencyMoney.text);

        if (towerCost > currentMoney)
        {
            textMeshPro.color = Color.red; // ������������� ���� ������ � �������
        }
        else
        {
            textMeshPro.color = Color.white; // ������������� ���� ������ � �����
        }

        // ������������� �����
        textMeshPro.text = towerCost.ToString();
    }
}
