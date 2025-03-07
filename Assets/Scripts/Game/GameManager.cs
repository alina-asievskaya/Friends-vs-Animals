using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
public static GameManager instance;

    private void Awake() { instance = this; }

    public Spawner spawner;
    public HealthSystem health;
    public CurrentlySystem currency;


    private void Start()
    {
        GetComponent<HealthSystem>().Init();
        GetComponent<CurrentlySystem>().Init();

        StartCoroutine(WaveStartDelay());
    }

    IEnumerator WaveStartDelay()
    {
        yield return new WaitForSeconds(2f);
    }

}
