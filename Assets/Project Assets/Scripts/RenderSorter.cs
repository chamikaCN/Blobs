﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderSorter : MonoBehaviour
{
    private void Start() {

        SpriteRenderer[] renderers = FindObjectsOfType<SpriteRenderer>();

        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.sortingOrder = (int)(renderer.transform.position.y*-100);
        }
    }
}
