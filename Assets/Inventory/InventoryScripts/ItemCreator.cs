using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    public Transform prefab;

    void Start()
    {
        /* ����prefab items */
        for (int i = 0; i < 10; i++)
        {
            //����10��prefab, ��m�O(0~18, 0, 0), ��V�O���`���
            Instantiate(prefab, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        }
    }
}
