﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface ISelectionResponse
{
    void OnDeselect(Transform selection);
    void OnSelect(Transform selection);
}

internal class HighlightSelectionResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] public Material highlightMaterial;
    [SerializeField] public Material defaultMaterial;

    public void OnSelect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = highlightMaterial;
        }
        cakeslice.Outline outline = selection.GetComponent<cakeslice.Outline>();
        outline.EnableOutline();
    }

    public void OnDeselect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = defaultMaterial;
        }
    }
}
