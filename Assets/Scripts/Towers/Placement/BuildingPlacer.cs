using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Places the tower and invokes related events
public class BuildingPlacer : MonoBehaviour
{
    //Prefabs for the tower
    protected GameObject towerPrefab;
    protected GameObject towerVisual;

    private void Awake()
    {
        towerPrefab = null;
    }

    private void Update()
    {
        if (towerPrefab != null && towerVisual != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(towerVisual);
                towerVisual = null;
                towerPrefab = null;
                return;
            }

            if (towerVisual.activeSelf == false)
            {
                towerVisual.SetActive(true);
            }

            towerVisual.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        
            if (Input.GetMouseButtonDown(0))
            {
                BuildManager m = towerVisual.GetComponent<BuildManager>();

                if (m.hasValidPlacement == true)
                {
                    m.SetPlacementMode(PlacementMode.Fixed);

                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        towerVisual = null;
                        EventBus<TowerPlaced>.Publish(new TowerPlaced());
                        PrepareTower();
                    }
                    else
                    {
                        towerPrefab = null;
                        towerVisual = null;
                        EventBus<TowerPlaced>.Publish(new TowerPlaced());
                    }
                }
            }
        }
    }

    public void SetTowerPrefab(GameObject prefab)
    {
        towerPrefab = prefab;
        PrepareTower();
    }

    protected virtual void PrepareTower()
    {
        if (towerVisual != null)
        {
            Destroy(towerVisual);
        }

        towerVisual = Instantiate(towerPrefab);
        towerVisual.SetActive(false);

        BuildManager m = towerVisual.GetComponent<BuildManager>();
        m.isFixed = false;
        m.SetPlacementMode(PlacementMode.Valid);
    }
}
