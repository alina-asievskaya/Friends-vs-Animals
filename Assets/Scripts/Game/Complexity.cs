using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Complexity : MonoBehaviour
{
    public GameObject LevelsMenu;
    public GameObject SettingImg;
    public GameObject PauseMenu;
    public GameObject WinPanel;


    public void Start()
    {
        Time.timeScale = 0f;
        SettingImg.SetActive(false);
        PauseMenu.SetActive(false);
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void EasyLevel()
    {
        Time.timeScale = 1f;
        SettingImg.SetActive(true);
        PauseMenu.SetActive(true);
        EnemySpawner.Instance.StartSpawning(10, 0.2f); 
        LevelsMenu.SetActive(false);
    }

    public void NormalLevel()
    {
        Time.timeScale = 1f;
        SettingImg.SetActive(true);
        PauseMenu.SetActive(true);
        EnemySpawner.Instance.StartSpawning(15, 0.5f); 
        LevelsMenu.SetActive(false);

    }

    public void HardLevel()
    {
        Time.timeScale = 1f;
        SettingImg.SetActive(true);
        PauseMenu.SetActive(true);
        EnemySpawner.Instance.StartSpawning(20, 0.8f); 
        LevelsMenu.SetActive(false);

    }

    public void Winner()
    {
        if (EnemySpawner.Instance.AreEnemiesDefeated())
        {
            StartCoroutine(ShowWinPanel());
        }
    }

    private IEnumerator ShowWinPanel()
    {
        yield return new WaitForSeconds(0.7f); 
        Time.timeScale = 0f; 
        WinPanel.SetActive(true); 
    }
}
