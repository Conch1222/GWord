using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Threading;

public class EnterButtonEvent : MonoBehaviour
{
    public GameObject enterBtn;
    public GameObject deleteBtn;
    public GameObject warningDialog;

    private GameObject[] arrGameObj = new GameObject[26];
    private Button[] arrButton = new Button[26];

    private Color yellow = new Color((230 / 255f), (217 / 255f), (51 / 255f), (255 / 255f));
    private Color green = new Color((154 / 255f), (205 / 255f), (50 / 255f), (255 / 255f));
    private Color black = Color.black;

    void Start()
    {
        warningDialog.SetActive(false);
        enterBtn.GetComponent<Button>().onClick.AddListener(delegate { OnEnterBtnClicked(); });
       
        for (int i=0;i<26;i++)
        {
            char tmp = (char)('A'+i);
            arrGameObj[i] = GameObject.Find(tmp.ToString());
            arrButton[i] = arrGameObj[i].GetComponent<Button>();
        }
    }
    void Update()
    {
        if (warningDialog.active)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                OnWarningDialogOkClicked();
        }
        else if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            OnEnterBtnClicked();

    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.3f);

        Dictionary<char, int> tmp = new Dictionary<char, int>(Variable.ansDic);

        for (int i = 0; i < 5; i++) //for green
        {
            judgeIfGreen(tmp, i);
        }

        for (int i=0;i<5;i++)
        {
            judgeBgColor(tmp,i);
            yield return new WaitForSeconds(0.7f);
        }

        if (Variable.sureAnsCnt == 6 || Variable.sureAns[Variable.sureAnsCnt - 1].Equals(Variable.systemAns))
        {
            if (Variable.sureAns[Variable.sureAnsCnt - 1].Equals(Variable.systemAns))
                Variable.bingo = true;

            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene("ResultScene");
        }

        Variable.isEnterClicked = false;
        for (int i = 0; i < 26; i++)
        {
            arrButton[i].interactable = true;
        }
    }

    private void judgeIfGreen(Dictionary<char, int> tmp, int i)
    {
        char currentLetter = Variable.sureAns[Variable.sureAnsCnt - 1][i];
        if (currentLetter == Variable.systemAns[i])
            tmp[currentLetter]--;

        if (tmp.ContainsKey(currentLetter) && tmp[currentLetter] == 0)
            tmp.Remove(Variable.sureAns[Variable.sureAnsCnt - 1][i]);
    }

    private void judgeBgColor(Dictionary<char, int> tmp, int i)
    {
        char currentLetter = Variable.sureAns[Variable.sureAnsCnt - 1][i];
        if (currentLetter == Variable.systemAns[i])
        {
            Variable.letterBg[((Variable.sureAnsCnt - 1) * 5) + i].GetComponent<Image>().color = green;
            LetterButtonController.judgeLetterbgColor(currentLetter,green);
        }
        else if (tmp.ContainsKey(currentLetter))
        {
            Variable.letterBg[((Variable.sureAnsCnt - 1) * 5) + i].GetComponent<Image>().color = yellow;
            LetterButtonController.judgeLetterbgColor(currentLetter, yellow);
            tmp[currentLetter]--;
        }
        else
        {
            Variable.letterBg[((Variable.sureAnsCnt - 1) * 5) + i].GetComponent<Image>().color = black;
            LetterButtonController.judgeLetterbgColor(currentLetter, black);
        }

        if (tmp.ContainsKey(currentLetter) && tmp[currentLetter] == 0)
            tmp.Remove(currentLetter);
    }

    public void OnEnterBtnClicked()
    { 
        if (Variable.curLetterCnt == 5)
        {
            Variable.isEnterClicked = true;
            for (int i = 0; i < 26; i++)
            {
                arrButton[i].interactable = false;
            }

            Variable.sureAns[Variable.sureAnsCnt] = Variable.userAns;
            print(Variable.sureAns[Variable.sureAnsCnt]);

            Trie Vocabulary = Trie.getInstance;
            if (!Vocabulary.Search(Variable.sureAns[Variable.sureAnsCnt].ToLower()))
            {
                openWarningDialog(true);
                return;
            }

            Variable.userAns = "";
            Variable.curLetterCnt = 0;
            Variable.sureAnsCnt++;
            
            StartCoroutine(Timer());
            
        }
        //Debug.Log(Variable.curLetterCnt);
    }

    private void openWarningDialog(bool flag)
    {
        warningDialog.SetActive(flag);
        enterBtn.SetActive(!flag);
        deleteBtn.SetActive(!flag);
    }

    public void OnWarningDialogOkClicked()
    {
        for (int i = 0; i < 26; i++)
        {
            arrButton[i].interactable = true;
        }
        Variable.isEnterClicked = false;
        openWarningDialog(false);
    }
}
