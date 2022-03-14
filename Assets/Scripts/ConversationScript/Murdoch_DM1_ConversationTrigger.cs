using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murdoch_DM1_ConversationTrigger : ConversationTrigger
{
    public Item condition_item;
    public override bool GetCoversationState(){
        return true;
    }
}
