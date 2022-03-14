using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[CreateAssetMenu(fileName = "New Important Item", menuName = "Import Item/Important Item", order = 0)]
public class ImportantItemSO : ScriptableObject {
    [SerializeField]
    int currentItemCount = 0;
    [SerializeField]
    int maxItemCount = 24;

    public Sprite ItemSprite;
    public TMP_Text ItemCountText;

    public int MaxItemCount
    {
        get { return maxItemCount; }
    }

    public int CurrentItemCount
    {
        get { return currentItemCount; }
        set
        {
            currentItemCount = value;
            if (currentItemCount < 0)
            {
                currentItemCount = 0;
            }
            else if (currentItemCount > maxItemCount)
            {
                currentItemCount = maxItemCount;
            }
        }
    }

}