using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : GameElement
{
    private Transform parent;
    private Vector3 surfaceSize;

    private GameObject[] getSurfaces()
    {
        return GameObject.FindGameObjectsWithTag("Surface");
    }

    public void InitSurfaceSize(Vector3 surfaceSize)
    {
        this.surfaceSize = surfaceSize;
    }

    public void InitParent(Transform parent)
    {
        this.parent = parent;

    }

    public void SpawnNextGround()
    {
        GameObject prefab = Game.model.ground.surfacePrefab;
        GameObject[] surfaces = getSurfaces();
        GameObject currentSurface = surfaces[surfaces.Length - 1];

        Vector3 newPosition = currentSurface.transform.position + (Vector3.forward * surfaceSize.z);

        GameObject newObj = Instantiate(prefab, newPosition, Quaternion.identity);
        newObj.transform.SetParent(this.parent);

        float zStart = newPosition.z - (surfaceSize.z / 2);
        float zEnd = newPosition.z + (surfaceSize.z / 2);
        SpawnTree(zStart, zEnd);
        Game.controller.item.SpawnItem(currentSurface.transform, zStart, zEnd);
    }

    public void InactivePreviousGround()
    {
        GameObject[] surfaces = getSurfaces();
        if (surfaces.Length > 1)
        {
            //surfaces[surfaces.Length - 2].SetActive(false);
            Destroy(surfaces[surfaces.Length - 2]);
        }
    }

    public void SpawnTree(float zStartPoint, float zEndPoint)
    {
        float zRangeMin = Game.model.ground.zRangeMin;
        float zRangeMax = Game.model.ground.zRangeMax;
        float xRange = Game.model.ground.xRange;
        float yPosition = Game.model.ground.yPosition;
        GameObject[] treesPrefab = Game.model.ground.treesPrefab;
        GameObject[] surfaces = getSurfaces();
        GameObject currentSurface = surfaces[surfaces.Length - 1];

        for (float z = zStartPoint; z < zEndPoint; z += Random.Range(zRangeMin, zRangeMax))
        {
            GameObject tree = Instantiate(treesPrefab[Random.Range(0, treesPrefab.Length)], currentSurface.transform);
            tree.transform.position = new Vector3(Random.Range(-xRange, xRange), yPosition, z);
            tree.transform.localPosition = new Vector3(Random.Range(-xRange, xRange), yPosition, tree.transform.localPosition.z);
            //tree.transform.localScale = 
        }
    }
}
