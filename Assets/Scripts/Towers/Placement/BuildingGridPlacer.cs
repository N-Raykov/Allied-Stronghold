using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGridPlacer : BuildingPlacer
{
    public int cellSize = 16;

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

            Vector2 mousePosition = Input.mousePosition;
            Vector3 mousePositionOnScreen = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10));
            Vector2 positionInGrid = ClampToNearest(mousePositionOnScreen, cellSize);
            towerVisual.transform.position = positionInGrid;

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

    Vector2 ClampToNearest(Vector2 pos, int threshold)
    {
        float t = 1f / threshold;
        Vector2 vector = ((Vector2)Vector2Int.FloorToInt(pos * t)) / t;

        float cetner = threshold * 0.5f;
        vector.x += cetner;
        vector.y += cetner;
        return vector;
    }
}
