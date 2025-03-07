using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int heart = 5;
    public int towerCost;
    public int towerID;

    public TMP_Text heartText;

    public TMP_Text tower1Text;
    public TMP_Text tower2Text;
    public TMP_Text tower3Text;
    public TMP_Text currencyMoney;

    public GameObject gameOverPanel;

    void Start()
    {
        UpdateHeartText(heart);
    }

    public void UpdateHeartText(int hearts)
    {
        heartText.text = hearts.ToString();
    }





    public void Heart()
    {
        heart--;
        UpdateHeartText(heart);

        if (heart <= 0)
        {
            StartCoroutine(ShowGameOverPanel());
        }
    }

    private IEnumerator ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true); // ���������� ������
        Time.timeScale = 0; // ������������� ����
        yield return new WaitForSecondsRealtime(1.5f); // ���� 2 ������� (���������� WaitForSecondsRealtime)
        Time.timeScale = 1; // ���������� ���������� �������� �������
        SceneManager.LoadScene("Menu");
    }
}