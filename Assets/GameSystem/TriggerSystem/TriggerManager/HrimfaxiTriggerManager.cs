using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HrimfaxiTriggerManager : MonoBehaviour
{
    public ConditionCounterSO conditionCounterSO;
    public Item charm_item;
    public BoxCollider2D bc;
    public List<GameObject> conversationTriggers = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if(!charm_item.isAcquired){
            conversationTriggers[0].SetActive(true);
            conversationTriggers[1].SetActive(false);
            conversationTriggers[2].SetActive(false);
        }
        else //有護身符之後
        {
            bc.isTrigger = true;
            conditionCounterSO.count += 1;
            if(conditionCounterSO.count == 1){
                
                conversationTriggers[0].SetActive(false);
                conversationTriggers[1].SetActive(true);
                conversationTriggers[2].SetActive(true);
            }
            if (conditionCounterSO.count > 1)
            {
                conversationTriggers[0].SetActive(false);
                conversationTriggers[1].SetActive(false);
                conversationTriggers[2].SetActive(false);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
