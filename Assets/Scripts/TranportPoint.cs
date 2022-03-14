using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TranportPoint : MonoBehaviour
{
    public PlayerController player;
    public NextDayMenu nextDayMenu;
    private bool stay = false;
    public GameObject Trigger;
    Animator animator;
    public GameObject Fade;
    public GameObject loadingtext;

    private void Start()
    {
        animator = Fade.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        stay = true;
        player.ArrowUpPressed = false;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        stay = true;
        if (col.tag == "Player" && player.ArrowUpPressed && stay)
        {
            this.gameObject.SetActive(false);
            player.ArrowUpPressed = false;
            Fade.SetActive(true);
            animator.Play("Fade_In");
            Invoke("FadeOutCompleted", animator.GetCurrentAnimatorStateInfo(0).length);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        stay = false;
        player.ArrowUpPressed = false;
    }

    private void FadeOutCompleted()
    {
        loadingtext.SetActive(true);
        nextDayMenu.StartNewDay();
        animator.Play("Loading");
        Invoke("LoadCompleted", animator.GetCurrentAnimatorStateInfo(0).length);
    }

    private void LoadCompleted()
    {
        loadingtext.SetActive(false);
        animator.Play("Fade_Out");
        Fade.SetActive(false);
    }
}
