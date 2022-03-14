using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RemptyTool.ES_MessageSystem;

[RequireComponent(typeof(ES_MessageSystem))]
public class UsageCase : MonoBehaviour
{
    private ES_MessageSystem msgSys;
    public UnityEngine.UI.Text uiText;
    public GameObject Message;
    private List<string> textList = new List<string>();
    private int textIndex = 0;

    void Start()
    {
        msgSys = this.GetComponent<ES_MessageSystem>();
        if (uiText == null)
        {
            Debug.LogError("UIText Component not assign.");
        }

        //add special chars and functions in other component.
        //msgSys.AddSpecialCharToFuncMap("UsageCase", CustomizedFunction); //可自訂關鍵字和function
        msgSys.AddSpecialCharToFuncMap("Close", CloseFunction); //定義[Close]到.txt可用於關閉對話
    }

    private void CustomizedFunction()
    {
        Debug.Log("Hi! This is called by CustomizedFunction!");
    }

    private void CloseFunction() //使用方法: 在.txt最後面加上 [Close]，即可在結束後關閉對話框
    {
        Message.SetActive(false);  // 關閉Message
    }

    public void ReadTextDataFromAsset(TextAsset _textAsset)
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
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    //You can sending the messages from strings or text-based files.
        //    if (msgSys.IsCompleted)
        //    {
        //        msgSys.SetText("Send the messages![lr] HelloWorld![w]");
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.X))
        {
            //Continue the messages, stoping by [w] or [lr] keywords.
            msgSys.Next();
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
