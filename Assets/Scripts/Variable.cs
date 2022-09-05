using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Variable : MonoBehaviour
{
    public static string systemAns;
    public static bool bingo;
    public static string userAns;
    public static int curLetterCnt, sureAnsCnt;
    public static string[] sureAns;

    public static bool isEnterClicked;

    public GameObject[] arrGameObj = new GameObject[30];
    public static Text[] letter = new Text[30];

    public static GameObject[] letterBg = new GameObject[30];

    public static Dictionary<char, int> ansDic;
    // Start is called before the first frame update
    void Start()
    {
        bingo = false;
        userAns = "";
        curLetterCnt = 0;
        sureAnsCnt = 0;
        ansDic = new Dictionary<char, int>();
        sureAns = new string[6];

        isEnterClicked = false;

        for (int i = 0; i < 30; i++)
        {
            letterBg[i] = arrGameObj[i].transform.parent.gameObject;
            letterBg[i].GetComponent<Image>().color = new Color((130 / 255f), (130 / 255f), (130 / 255f), (255 / 255f));
            letter[i] = arrGameObj[i].GetComponent<Text>();
        }
    }
}
