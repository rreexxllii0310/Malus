using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RemptyTool.ES_MessageSystem;

[RequireComponent(typeof(ES_MessageSystem))]
public class OpeningController : MonoBehaviour
{
    
    private ES_MessageSystem msgSys;
    public UnityEngine.UI.Text uiText;
    private int enterCounter;

    //public TextAsset opwords;
    //public TextAsset Title;
    public TextAsset textAssetA;
    public TextAsset textAssetB;
    private List<string> textList = new List<string>();
    private int textIndex = 0;

    void Start()
    {
        msgSys = this.GetComponent<ES_MessageSystem>();
        if (uiText == null)
        {
            Debug.LogError("UIText Component not assign.");
        }
        else
            ReadTextDataFromAsset(textAssetA);

        //add special chars and functions in other component.
        msgSys.AddSpecialCharToFuncMap("UsageCase", CustomizedFunction);
    }

    private void CustomizedFunction()
    {
        Debug.Log("Hi! This is called by CustomizedFunction!");
    }

    private void ReadTextDataFromAsset(TextAsset _textAsset)
    {
        textList.Clear();
        textList = new List<string>();
        textIndex = 0;
        var lineTextData = _textAsset.text.Split('\n');
        foreach (string line in lineTextData)
        {
            textList.Add(line);
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Continue the messages, stoping by [w] or [lr] keywords.
            msgSys.Next();
            enterCounter++;
        }

        //If the message is complete, stop updating text.
        if (msgSys.IsCompleted == false)
        {
            uiText.text = msgSys.text;
        }

        //Auto update from textList.
        if (msgSys.IsCompleted == true && textIndex < textList.Count)
        {
            msgSys.SetText(textList[textIndex]);
            textIndex++;
        }
    }
}