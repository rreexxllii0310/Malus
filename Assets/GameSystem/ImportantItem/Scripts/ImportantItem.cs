using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImportantItem : MonoBehaviour
{
    public ImportantItemSO importantItemSO;
    public Image itemImage;
    public TMP_Text countText;

    private void Start() {
        itemImage.sprite = importantItemSO.ItemSprite;
        countText.text = "x"+importantItemSO.CurrentItemCount.ToString();
    }

    public void ResetToInitial()
    {
        importantItemSO.CurrentItemCount = 0;
    }

    public void GetImportantItem(int count){
        importantItemSO.CurrentItemCount += count;
        countText.text = "x"+importantItemSO.CurrentItemCount.ToString();
    }

    public void UseImportantItem(int count){
        importantItemSO.CurrentItemCount -= count;
        countText.text = "x"+importantItemSO.CurrentItemCount.ToString();
    }
}
