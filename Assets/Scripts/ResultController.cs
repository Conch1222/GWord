using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{
    private GameObject resultObj;
    private Text resultText;
    // Start is called before the first frame update
    void Start()
    {
        resultObj = GameObject.Find("ResultDialog").gameObject.transform.GetChild(0).gameObject;
        resultText= resultObj.GetComponent<Text>();

        string res = "";
        if (Variable.bingo)
        {
            switch(Variable.sureAnsCnt)
            {
                case 1:
                    res = "You are the Psychic King !";
                    break;
                case 2:
                    res = "Incredible !";
                    break;
                case 3:
                    res = "Marvelous !";
                    break;
                case 4:
                    res = "Cool !";
                    break;
                case 5:
                    res = "Good";
                    break;
                case 6:
                    res = "Okay ...";
                    break;
                default:
                    res = "Error";
                    break;
            }
        }
        else
        {
            res = "The answer is \n" + Variable.systemAns;
        }
        resultText.text = res;

        print(Variable.bingo + " " + Variable.sureAnsCnt);
        ScoreBoradHandler.newRecord(Variable.bingo, Variable.sureAnsCnt);
    }
}
