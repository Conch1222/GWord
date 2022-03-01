using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DeleteButtonClicked : MonoBehaviour
{
    public GameObject Btn;
    public Text[] letter = new Text[10];

    // Start is called before the first frame update
    void Start()
    {
        Btn.GetComponent<Button>().onClick.AddListener(delegate { OnBtnClicked(); });
    }

    public void OnBtnClicked()
    {
        if(Variable.curLetterCnt > 0)
        {
            Variable.userAns = Variable.userAns.Remove(Variable.curLetterCnt - 1);
            letter[(Variable.sureAnsCnt * 5) + Variable.curLetterCnt - 1].text = "";
            Variable.curLetterCnt--;
        }
        //Debug.Log(Variable.curLetterCnt);
    }
}
