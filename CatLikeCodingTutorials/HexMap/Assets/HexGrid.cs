﻿using UnityEngine;

public class HexGrid : MonoBehaviour
{
    public int width = 6;
    public int height = 6;

    public HexCell cellPrefab;

    HexCell[] cells;

    private void Awake()
    {
        cells = new HexCell[height * width];
    } 
}
