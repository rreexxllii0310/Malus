using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    public Transform prefab;

    void Start()
    {
        /* 產生prefab items */
        for (int i = 0; i < 10; i++)
        {
            //產生10個prefab, 位置是(0~18, 0, 0), 方向是正常方位
            Instantiate(prefab, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        }
    }
}
