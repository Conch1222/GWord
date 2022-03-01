using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Variable : MonoBehaviour
{
    public static string userAns;
    public static int curLetterCnt, sureAnsCnt;
    public static string[] sureAns = new string[6];

    public GameObject[] letterBg = new GameObject[10];
    // Start is called before the first frame update
    void Start()
    {
        userAns = "";
        curLetterCnt = 0;
        sureAnsCnt = 0;
 
        foreach (GameObject img in letterBg)
        {
            img.GetComponent<Image>().color = new Color((130 / 255f), (130 / 255f), (130 / 255f), (255 / 255f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
