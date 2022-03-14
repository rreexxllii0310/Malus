using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveBag : MonoBehaviour, IDragHandler
{
    public Canvas canvas;
    RectTransform currentRect;

    void Awake() 
    {
        currentRect = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (currentRect.anchoredPosition.x < 630 && currentRect.anchoredPosition.x > -630 && currentRect.anchoredPosition.y < 400 && currentRect.anchoredPosition.y > -430)
        {
            currentRect.anchoredPosition += eventData.delta;
        }
        if (currentRect.anchoredPosition.x >= 630)
            currentRect.anchoredPosition = new Vector2(629, currentRect.anchoredPosition.y);
        if (currentRect.anchoredPosition.x <= -630)
            currentRect.anchoredPosition = new Vector2(-629, currentRect.anchoredPosition.y);
        if (currentRect.anchoredPosition.y >= 400)
            currentRect.anchoredPosition = new Vector2(currentRect.anchoredPosition.x, 399);
        if (currentRect.anchoredPosition.y <= -430)
            currentRect.anchoredPosition = new Vector2(currentRect.anchoredPosition.x, -429);
    }
}
