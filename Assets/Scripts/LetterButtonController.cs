using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class LetterButtonController : MonoBehaviour
{
    public GameObject[] arrBtn= new GameObject[26];

    private static Image[] arrButton = new Image[26];

    private GameObject temporaryBtn;
    private string singleLetter;
    private static Color gray = new Color((130 / 255f), (130 / 255f), (130 / 255f), (255 / 255f));
    private static Color yellow = new Color((230 / 255f), (217 / 255f), (51 / 255f), (255 / 255f));
    private static Color green = new Color((154 / 255f), (205 / 255f), (50 / 255f), (255 / 255f));
    private static Color black = Color.black;

    void Start()
    {
        foreach (GameObject btn in arrBtn)
        {
            btn.GetComponent<Button>().onClick.AddListener(delegate { OnBtnClicked(); });
        }
        for (int i= 0;i<26;i++)
        {
            arrButton[i] = arrBtn[i].GetComponent<Image>();
        }
    }
    public void OnBtnClicked()
    {
        if(Variable.curLetterCnt >= 0 && Variable.curLetterCnt < 5)
        {
            temporaryBtn = EventSystem.current.currentSelectedGameObject;
            singleLetter = GameObject.Find(temporaryBtn.name).GetComponentInChildren<Text>().text;
            Variable.userAns += singleLetter;
            Variable.letter[(Variable.sureAnsCnt * 5)+Variable.curLetterCnt].text = singleLetter;
            Variable.curLetterCnt++;
        }
        //Debug.Log(Variable.userAns);
    }

    public static void judgeLetterbgColor(char letter, Color color)
    {
        if(color.r==green.r && color.g == green.g && color.b == green.b) //green
        {
            arrButton[letter - 'A'].color = green;
        }
        else if(color.r == yellow.r && color.g == yellow.g && color.b == yellow.b) //yellow
        {
            Color currentColor = arrButton[letter - 'A'].color;
            if ((currentColor.r == green.r && currentColor.g == green.g && currentColor.b == green.b) || (currentColor.r == yellow.r && currentColor.g == yellow.g && currentColor.b == yellow.b))
                return;

            arrButton[letter - 'A'].color = yellow;
        }
        else //black
        {
            Color currentColor = arrButton[letter - 'A'].color;
            if (currentColor.r == gray.r && currentColor.g == gray.g && currentColor.b == gray.b)
            {
                arrButton[letter - 'A'].color = black;
            }
        }
    }
}
