using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyaHouse : MonoBehaviour
{
    public AnyaHouseSO anyaHouseSO;
    public Transform playerTransform;
    private void Start() {
        if(anyaHouseSO.isExitAnyaHouse)
        {
            anyaHouseSO.isExitAnyaHouse = false;
            playerTransform.position += new Vector3(11.0f, 0.0f, 0.0f);
        }
    }
}
