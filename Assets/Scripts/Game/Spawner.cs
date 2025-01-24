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
                SpawnTower(cellPosCentered);

                spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.None);

            }

        }
    }
    
    void SpawnTower(Vector3 position)
    {
        GameObject tower = Instantiate(towersPrefabs[spawnID], spawnTowerRoot);
        tower.transform.position = position;

        DeselectTower();
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
