using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndingController : MonoBehaviour
{
    public ImportantItemSO importantItemSO;
    public CountSO countSO;
    public TMP_Text RepairText;
    public TMP_Text ObserveText;
    public TMP_Text ImportantItemText;

    public void AddRepair()
    { 
        if (importantItemSO.CurrentItemCount > 0) {
            //reduce current item
            importantItemSO.CurrentItemCount -= 1;
            //add one to repair
            countSO.RepairCount += 1;

            //Show Text
            RepairText.SetText(countSO.RepairCount.ToString());
            ImportantItemText.SetText(importantItemSO.CurrentItemCount.ToString());
        }
    }

    public void MinusRepair()
    {
        //Debug.Log(countSO.RepairCount);
        if (countSO.RepairCount > 0)
        {
            //reduce current item
            importantItemSO.CurrentItemCount += 1;
            //minus one to repair
            countSO.RepairCount -= 1;

            //Show Text
            RepairText.SetText(countSO.RepairCount.ToString());
            ImportantItemText.SetText(importantItemSO.CurrentItemCount.ToString());
        }
    }

    public void AddObserve()
    {
        if (importantItemSO.CurrentItemCount > 0)
        {
            //reduce current item
            importantItemSO.CurrentItemCount -= 1;
            //add one to repair
            countSO.ObserveCount += 1;

            //Show Text
            ObserveText.SetText(countSO.ObserveCount.ToString());
            ImportantItemText.SetText(importantItemSO.CurrentItemCount.ToString());
        }
    }

    public void MinusObserve()
    {
        //Debug.Log(countSO.ObserveCount);
        if (countSO.ObserveCount > 0)
        {
            
            //reduce current item
            importantItemSO.CurrentItemCount += 1;
            //minus one to repair
            countSO.ObserveCount -= 1;

            //Show Text
            ObserveText.SetText(countSO.ObserveCount.ToString());
            ImportantItemText.SetText(importantItemSO.CurrentItemCount.ToString());
        }
    }

    public void Submit()
    {
        //蒐集「Ελπρις」數量<X，且拿去修理飛行船的數量>拿去觀測地球
        if ((countSO.RepairCount + countSO.ObserveCount) < 18 && countSO.RepairCount > countSO.ObserveCount) {
            Debug.Log("幻化星塵");
            SceneManager.LoadScene("END1");
        }

        //蒐集「Ελπρις」數量<X，且拿去觀測地球>=拿去修理飛行船的數量
        if ((countSO.RepairCount + countSO.ObserveCount) < 18 && countSO.RepairCount <= countSO.ObserveCount)
        {
            Debug.Log("心存希冀");
            SceneManager.LoadScene("END2");
        }

        //蒐集「Ελπρις」數量>=X，且拿去觀測地球>=拿去修理飛行船的數量
        if ((countSO.RepairCount + countSO.ObserveCount) >= 18 && countSO.RepairCount <= countSO.ObserveCount)
        {
            Debug.Log("End3");
            SceneManager.LoadScene("END3");
        }

        //蒐集「Ελπρις」數量>=X，且拿去修理飛行船的數量>拿去觀測地球
        if ((countSO.RepairCount + countSO.ObserveCount) >= 18 && countSO.RepairCount > countSO.ObserveCount)
        {
            Debug.Log("THE TRUE END");
            SceneManager.LoadScene("END4");
        }
    }
}
