﻿using UnityEngine.EventSystems;
using UnityEngine;


[RequireComponent(typeof(Collider))] //A collider is needed to receive clicks
public class StartButton : MonoBehaviour, IPointerClickHandler
{
    public Color startColor;
    public Color mouseOverColor;
    //bool mouseOver = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        GameEventsManager._instance.MenuToGame();
    }

    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.SetColor("_Color", mouseOverColor);
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", startColor);
    }
}