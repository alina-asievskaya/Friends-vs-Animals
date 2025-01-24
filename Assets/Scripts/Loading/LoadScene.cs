using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    [SerializeField] 
    private int units;

    [SerializeField] 
    private GameObject cratePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator BuilderUnits()
    {
        for (int i = 0; i < units; i++)
        {
            yield return null;
        }
    }

}
