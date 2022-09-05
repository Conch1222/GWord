using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class ScoreBoradHandler : MonoBehaviour
{
    public GameObject warningDialog;


    private string[] item = new string[] { "1Num", "2Num", "3Num", "4Num", "5Num", "6Num" };
    private static int[] itemNum = new int[8]; 
    private GameObject winRateObj,timesNumObj;
    private Text winRateText, timesNumText;
    private static string path = System.Environment.CurrentDirectory + "\\Assets\\Files\\ScoreBoard.csv";
    void Start()
    {
        warningDialog.SetActive(false);

        print(path);

        StreamReader reader = new StreamReader(@path);
        int index = 0;
        while(!reader.EndOfStream)
        {
            string str = reader.ReadLine();
            print(str);
            itemNum[index++]=int.Parse(str);
        }

        float winRate = calculateWinRate(itemNum[0], itemNum[1]);
        setWinRateText(winRate);
        print(winRate);

        for(int i=2;i<=7;i++)
        {
            setTimesNumText(itemNum[i].ToString(), i-2);
        }
        reader.Close();
    }

    private void setTimesNumText(string line, int itemIdx)
    {
        timesNumObj = GameObject.Find(item[itemIdx]);
        timesNumText = timesNumObj.GetComponent<Text>();
        timesNumText.text = line;
    }

    private float calculateWinRate(int win, int totalPlayed)
    {
        float winRate = 0;

        if (totalPlayed != 0)
            winRate = (float)(win * 1.0f / totalPlayed * 100);

        return winRate;
    }

    private void setWinRateText(float winRate)
    {
        winRateObj = GameObject.Find("WinRateNumber");
        winRateText = winRateObj.GetComponent<Text>();
        winRateText.text = winRate.ToString("#0.0") + " %";
    }

    static public void newRecord(bool bingo, int sureAnsCnt)
    {
        if(bingo)
        {
            itemNum[0]++;
            itemNum[sureAnsCnt + 1]++;
        }
        itemNum[1]++;

        System.IO.FileStream fs = new System.IO.FileStream(path, FileMode.Create, FileAccess.Write);
        System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.UTF8);
        for(int i=0;i<8;i++)
        {
            sw.WriteLine(itemNum[i]);
        }
        sw.Close();
        fs.Close();
    }

    public void OnWarningDialogDeleteClicked()
    {
        warningDialog.SetActive(true);
    }

    public void OnWarningDialogSureClicked()
    {
        System.IO.FileStream fs = new System.IO.FileStream(path, FileMode.Create, FileAccess.Write);
        System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.UTF8);
        for (int i = 0; i < 8; i++)
        {
            itemNum[i] = 0;
            sw.WriteLine(0);
        }
        sw.Close();
        fs.Close();

        float winRate = calculateWinRate(itemNum[0], itemNum[1]);
        setWinRateText(winRate);

        for (int i = 2; i <= 7; i++)
        {
            setTimesNumText(itemNum[i].ToString(), i - 2);
        }
        warningDialog.SetActive(false);
    }

    public void OnWarningDialogCancelClicked()
    {
        warningDialog.SetActive(false);
    }
}
