using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class LetterButtonClicked : MonoBehaviour
{
    public GameObject[] arrBtn= new GameObject[4];
    public Text[] letter=new Text[10];

    private GameObject temporaryBtn;
    private string singleLetter;

    void Start()
    {
        foreach (GameObject btn in arrBtn)
        {
            btn.GetComponent<Button>().onClick.AddListener(delegate { OnBtnClicked(); });
        }
    }
    public void OnBtnClicked()
    {
        if(Variable.curLetterCnt >= 0 && Variable.curLetterCnt < 5)
        {
            temporaryBtn = EventSystem.current.currentSelectedGameObject;
            singleLetter = GameObject.Find(temporaryBtn.name).GetComponentInChildren<Text>().text;
            Variable.userAns += singleLetter;
            letter[(Variable.sureAnsCnt * 5)+Variable.curLetterCnt].text = singleLetter;
            Variable.curLetterCnt++;
        }
        //Debug.Log(Variable.userAns);
    }
}
