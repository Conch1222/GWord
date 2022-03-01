using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Threading;

public class EnterButtonClicked : MonoBehaviour
{
    public GameObject Btn;
    public GameObject[] letter = new GameObject[10];
    private GameObject[] letterBg=new GameObject[10];

    void Start()
    {
        Btn.GetComponent<Button>().onClick.AddListener(delegate { OnBtnClicked(); });

        for (int i=0;i<10;i++)
        {
            letterBg[i] = letter[i].transform.parent.gameObject;    
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < 5; i++)
        {
            letterBg[(Variable.sureAnsCnt * 5) + i].GetComponent<Image>().color = new Color((0 / 255f), (0 / 255f), (0 / 255f), (255 / 255f));
            yield return new WaitForSeconds(0.7f);
        }
        Variable.sureAnsCnt++;

        if (Variable.sureAnsCnt == 2)
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("ResultScene");
        }
    }
    public void OnBtnClicked()
    {
        if (Variable.curLetterCnt == 5)
        {
            Variable.sureAns[Variable.sureAnsCnt] = Variable.userAns;
            Variable.userAns = "";
            Variable.curLetterCnt = 0;

            StartCoroutine(Timer());
        }
        //Debug.Log(Variable.curLetterCnt);
    }
}
