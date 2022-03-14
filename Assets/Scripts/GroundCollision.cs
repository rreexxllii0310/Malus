using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    public PlayerController playercontroller;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Ground") // ���a���b�a�O�W
        {
            playercontroller.IsJump = false;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") // ���a���b���D��
        {
            playercontroller.IsJump = true;
        }

    }
}