using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapItem : MonoBehaviour
{
    [SerializeField]
    private int idx;
    private bool isPicked;
    public MapItemManager mapItemManager;

    public int Idx
    {
        get { return idx; }
        set { idx = value; }
    }

    public bool IsPicked
    {
        get { return isPicked; }
        set { isPicked = value; }
    }

    public void SetPicked()
    {
        mapItemManager.SetPicked(SceneManager.GetActiveScene().name, idx);
    }

}
