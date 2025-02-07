using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public class Spawner : MonoBehaviour
{
    // list of towers

    int spawnID = -1;
    public List<GameObject> towersPrefabs;
    public Transform spawnTowerRoot;

    public List<Image> towersUI;
    public Tilemap spawnTilemap;

    private Vector3Int tilePos;

    public void Update()
    {
        if(CanSpawn())
          DetectSpawnPoint();
    }

    bool CanSpawn()
    {
        if( spawnID == -1)
            return false;
        else
            return true;
    }

    void DetectSpawnPoint()
    {
        if (Input.GetMouseButtonDown(0))
        {

            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var cellPosDefault = spawnTilemap.WorldToCell(mousePos);
            Debug.Log(cellPosDefault);

            var cellPosCentered = spawnTilemap.GetCellCenterWorld(cellPosDefault);

            if (spawnTilemap.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
            {
                int towerCost = TowerCost(spawnID);
                if (GameManager.instance.currency.EnoughCurrency(towerCost))
                {
                    GameManager.instance.currency.Use(towerCost);

                    SpawnTower(cellPosCentered, cellPosDefault);
                    spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.None);
                }
                else
                {
                    Debug.Log("dcidb");
                }
                

            }

        }
    }

    public int TowerCost(int id)
    {
        switch (id)
        {
            case 0:
                return towersPrefabs[id].GetComponent<Tower_Pink>().cost;
            case 1:
                return towersPrefabs[id].GetComponent<Tower_Mask>().cost;
            case 2:
                return towersPrefabs[id].GetComponent<Tower_Ninja>().cost;
            default:
                return -1;
        }
    }



    void SpawnTower(Vector3 position, Vector3Int cellPosition)
    {
        GameObject tower = Instantiate(towersPrefabs[spawnID], spawnTowerRoot);
        tower.transform.position = position;
        tower.GetComponent<Tower>().Init(cellPosition);

        DeselectTower();
    }

    public void RevertCellState(Vector3Int pos)
    {
        spawnTilemap.SetColliderType(pos, Tile.ColliderType.Sprite);
    }

    public void SelectTower(int id)
    {
        DeselectTower();
        spawnID = id;

        towersUI[spawnID].color = Color.white;
    }

    public void DeselectTower()
    {
        spawnID = -1;
        foreach (var t in towersUI)
        {
            t.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }
}
