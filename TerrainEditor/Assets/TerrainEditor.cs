using UnityEngine;
using System.Collections;

public class TerrainEditor : MonoBehaviour {

    public Terrain myTerrain;
    TerrainData tData;
    int xResolution;
    int zResolution;
    float[,] heights;
    float paintRadius;
    bool lockedUp = false;
    bool lockedDown = false;
    RaycastHit hit;
    Ray ray;

    #region Start & Update
    // Use this for initialization
	void Start () {
        // Grab my terrain data
        tData = myTerrain.terrainData;

        // Set the resolutions (the grid)
        xResolution = tData.heightmapWidth;
        zResolution = tData.heightmapHeight;
        paintRadius = 5;

        // Get the heights along the grid
        heights = tData.GetHeights(0, 0, xResolution, zResolution);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && !lockedUp)
        {
            paintRadius = (float)Mathf.RoundToInt(paintRadius);
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            lockedUp = true;
        }
        else if (Input.GetMouseButton(1) && !lockedDown)
        {
            paintRadius = (float)Mathf.RoundToInt(paintRadius);
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            lockedDown = true;
        }
        else // Mouse click takes priority. disable brush scrolling
        {
            // Increase the size of the paint brush
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                Debug.Log(paintRadius);
                if (paintRadius < 50)
                    paintRadius += 1f;
            }
            // Decrease the size of the paint brush
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                Debug.Log(paintRadius);
                if (paintRadius > 5)
                    paintRadius -= 1f;
            }
        }

        if(lockedUp)
        {
            if(Input.GetMouseButtonUp(0))
            {
                lockedUp = false;
            }
            if(Physics.Raycast(ray, out hit))
            {
                raiseTerrain(hit.point);
            }
        }
        if(lockedDown)
        {
            if (Input.GetMouseButtonUp(1))
            {
                lockedDown = false;
            }
            if (Physics.Raycast(ray, out hit))
            {
                lowerTerrain(hit.point);
            }
        }
	}

    #endregion

    #region Beginning Code
    // Raises a point
    private void raisePoint(Vector3 point)
    {
        // Get the mouse location on the terrain grid
        int mouseX = (int)((point.x / tData.size.x) * xResolution);
        int mouseZ = (int)((point.z / tData.size.z) * zResolution);

        // Modify the height upward
        float[,] modHeights = new float[1, 1];
        float y = heights[mouseX, mouseZ];
        y += 0.01f * Time.deltaTime;

        // Cap the height at max
        if(y > tData.size.y)
        {
            y = tData.size.y;
        }

        // Set terrain data to modified values at point
        modHeights[0, 0] = y;
        heights[mouseX, mouseZ] = y;
        tData.SetHeights(mouseX, mouseZ, modHeights);
    }

    // Lowers a point
    private void lowerPoint(Vector3 point)
    {
        // Get the mouse location on the terrain grid
        int mouseX = (int)((point.x / tData.size.x) * xResolution);
        int mouseZ = (int)((point.z / tData.size.z) * zResolution);

        // Modify the height upward
        float[,] modHeights = new float[1, 1];
        float y = heights[mouseX, mouseZ];
        y -= 0.01f * Time.deltaTime;

        // Hold the height above 0
        if (y < 0.0f)
        {
            y = 0.0f;
        }

        // Set terrain data to modified values at point
        modHeights[0, 0] = y;
        heights[mouseX, mouseZ] = y;
        tData.SetHeights(mouseX, mouseZ, modHeights);
    }
    #endregion

    #region Current Code
    private void raiseTerrain(Vector3 point)
    {
        int radius = (int)paintRadius;
        // Get the mouse location on the terrain grid
        int mouseX = (int)((point.x / tData.size.x) * xResolution);
        int mouseZ = (int)((point.z / tData.size.z) * zResolution);

        // Modify the height upward
        float[,] modHeights = new float[radius, radius];
        for (int x = 0; x < radius; x++)
        {
            for (int z = 0; z < radius; z++)
            {
                float y = heights[mouseX + x - 1, mouseZ + z - 1];
                y += 0.01f * Time.deltaTime;

                // Cap the height at max
                if (y > tData.size.y)
                {
                    y = tData.size.y;
                }

                modHeights[x, z] = y;
                heights[mouseX + x - 1, mouseZ + z - 1] = y;
            }
        }

        // Set terrain data to modified values at point
        tData.SetHeights(mouseX, mouseZ, modHeights);
    }

    // Lowers a point
    private void lowerTerrain(Vector3 point)
    {
        int radius = (int)paintRadius;
        // Get the mouse location on the terrain grid
        int mouseX = (int)((point.x / tData.size.x) * xResolution);
        int mouseZ = (int)((point.z / tData.size.z) * zResolution);

        // Modify the height upward
        float[,] modHeights = new float[radius, radius];
        for (int x = 0; x < radius; x++)
        {
            for (int z = 0; z < radius; z++)
            {
                float y = heights[mouseX + x - 1, mouseZ + z - 1];
                y -= 0.01f * Time.deltaTime;

                // Hold the height above 0
                if (y < 0.0f)
                {
                    y = 0.0f;
                }

                modHeights[x, z] = y;
                heights[mouseX + x - 1, mouseZ + z - 1] = y;
            }
        }

        // Set terrain data to modified values at point
        tData.SetHeights(mouseX, mouseZ, modHeights);
    }
    #endregion
}
