using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public SpriteRenderer sr;
    public GameObject player;
    public GameObject Bag;
    public GameObject Map;
    public HealthBar healthBar;
    public HealthSO healthSO;
    Animator animator;
    private string currentState;
    public GameObject Message;
    private TextAsset textAsset; //txt file, 預設是Assets/Resources資料夾
    private UsageCase useCase; //對話系統使用package


    private float MaxHorizonSpeed, MaxVerticalSpeed;
    private bool isWalkPressed = false;
    private bool isJumping = false;
    private bool isTalkPressed = false;
    private bool startTalkPressed = false;
    private bool isPickPressed = false;
    private bool isHinting = false;
    private bool arrowUpPressed = false;
    float horizontalspeed, verticalSpeed;

    private bool notleftwall = true;
    private bool notrightwall = true;

    public bool IsWalking
    {
        get { return isWalkPressed; }
        set { isWalkPressed = value; }
    }
    public bool IsJump { 
        get { return isJumping; }
        set { isJumping = value; }
    }
    public bool isTalk
    {
        get { return isTalkPressed; }
        set { isTalkPressed = value; }
    }
    public bool startTalk
    {
        get { return startTalkPressed; }
        set { startTalkPressed = value; }
    }

    public bool ArrowUpPressed
    {
        get { return arrowUpPressed; }
        set { arrowUpPressed = value; }
    }

    public bool Pick
    {
        get { return isPickPressed; }
        set { isPickPressed = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sr = this.GetComponent<SpriteRenderer>();
        rb2d = this.GetComponent<Rigidbody2D>();
        //��l��q�����(�̤j�ȻP���e��q(�@�}�l����))
        healthBar.SetMaxValue(healthSO.MaxHealthValue);
        healthBar.SetHealth(healthSO.HealthValue);
        animator = GetComponent<Animator>();
        MaxHorizonSpeed = 3;
        MaxVerticalSpeed = 7;
        useCase = GameObject.Find("MsgSystem").GetComponent<UsageCase>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalSpeed = rb2d.velocity.y + rb2d.gravityScale * Time.deltaTime;
        if (!isTalkPressed && !isHinting) //�S���b��npc��� �BHint�ʵe�~�i�H����}��
        {
            Check_player_input();
        }
        if (!isWalkPressed && !isJumping && !isHinting && !isTalkPressed)
        {
            ChangeAnimationState("Idle");
        }
        if (!Message.activeSelf) //判斷對話框是否還active
        {
            isTalkPressed = false;
        }
    }

    public void ChangeAnimationState(string newState)
    {
        //if(currentState != newState) Debug.Log("current:"+currentState+"  , newState:"+ newState);
        //stop the same animation from interrupt itself
        if (currentState == newState) return;

        // play the animation
        animator.Play(newState);

        //reassign the current state
        currentState = newState;
    }

    void JumpComplete()
    {
        isJumping = false;
    }

    void HintComplete()
    {
        isHinting = false;
    }

    private void Check_player_input()
    {
        if (Input.GetKeyDown(KeyCode.D)) //�}���I�]�A�I�]�Mitem��code�bInventory
        {
            textAsset = (TextAsset)Resources.Load("D_H_2", typeof(TextAsset)); //Load .txt file from Assets/Resources
            useCase.ReadTextDataFromAsset(textAsset); //設定對話框的對話內容並開始對話
            Message.SetActive(true); //設定對話框active
            ChangeAnimationState("Idle");
            isTalkPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            arrowUpPressed = true;
        }

        /*if (Input.GetKeyDown(KeyCode.Alpha1)) //Test for hint animation
        {
            if (!isHinting)
            {
                isHinting = true;
                ChangeAnimationState("InteractHint");
                Invoke("HintComplete", animator.GetCurrentAnimatorStateInfo(0).length); //Invoke JumpComplete function after jumpDelay time
            }
        }*/

        if (Input.GetKeyDown(KeyCode.A)) //�a��
        {
            if (Map.activeSelf == true)
            {
                Map.SetActive(false);
            }
            else {
                Map.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Z)) //�߹D��
        {
            isPickPressed = true; //�߹D�㪺code�b�D�㪺ItemTrigger
        }

        if (Input.GetKeyDown(KeyCode.X)) //���
        {
            //��ܮɦp�G�ٶ}�ۭI�]�h�����I�]
            if (Bag.activeSelf == true)
            {
                Bag.SetActive(false);
            }
            //��ܮɰʵe�]��idle
            ChangeAnimationState("Idle");
            startTalk = true; //��ܪ�code�bNPC��NPCController
        }

        if (Input.GetKeyDown(KeyCode.Space)) //jump
        {
            if (!isJumping && !isHinting)
            {
                isJumping = true;
                verticalSpeed = MaxVerticalSpeed;
                ChangeAnimationState("Jump");

                //change isJumping to false when finish animation
                //float jumpDelay = animator.GetCurrentAnimatorStateInfo(0).length; //get animation time
                //Invoke("JumpComplete", jumpDelay); //Invoke JumpComplete function after jumpDelay time
            }
        }

        if (Input.GetKeyDown(KeyCode.KeypadMinus)) //���զ�q�Ϊ�
        {
            Debug.Log("HP-20");
            TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus)) //���զ�q�Ϊ�
        {
            Debug.Log("HP+20");
            TakeHealing(20);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && notleftwall)
        {
            if (!isHinting)
            {
                if (sr.flipX) //�ʵe��V��
                { //false���ܩ�����
                    sr.flipX = false;
                }
                isWalkPressed = true;
                if (!isJumping)
                {
                    ChangeAnimationState("Walk");
                }
                // transform.Translate(-MaxHorizonSpeed, 0, 0);
                horizontalspeed = -MaxHorizonSpeed;
            }  
        }
        else if (Input.GetKey(KeyCode.RightArrow) && notrightwall)
        {
            if (!isHinting)
            {
                if (!sr.flipX) //�ʵe��V��
                { //true���ܩ��k��
                    sr.flipX = true;
                }
                isWalkPressed = true;
                if (!isJumping)
                {
                    ChangeAnimationState("Walk");
                }
                // transform.Translate(MaxHorizonSpeed, 0, 0);
                horizontalspeed = MaxHorizonSpeed;
            }
        }
        else
        {
            isWalkPressed = false;
            horizontalspeed = 0;
        }
        rb2d.velocity = new Vector2(horizontalspeed, verticalSpeed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "LeftBound")
        {
            notleftwall = false;
        }
        if(col.gameObject.tag == "RightBound")
        {
            notrightwall = false;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "LeftBound")
        {
            notleftwall = true;
        }
        if(col.gameObject.tag == "RightBound")
        {
            notrightwall = true;
        }
    }

    public void TakeDamage(int damage)
    {
        healthSO.HealthValue -= damage;
        healthBar.SetHealth(healthSO.HealthValue);
    }
    public void TakeHealing(int healing)
    {
        healthSO.HealthValue += healing;
        healthBar.SetHealth(healthSO.HealthValue);
    }
}
