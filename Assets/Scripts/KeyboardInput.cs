using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{ 
    void Update()
    {
        if(!Variable.isEnterClicked)
            detectPressedKeyOrButton();
    }

    public void detectPressedKeyOrButton()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            bool isAlpha = kcode.ToString().Length == 1;
            if (isAlpha && Input.GetKeyDown(kcode) && Variable.curLetterCnt >= 0 && Variable.curLetterCnt < 5)
            {
                //Debug.Log("KeyCode down: " + kcode);
                Variable.userAns += kcode;
                Variable.letter[(Variable.sureAnsCnt * 5) + Variable.curLetterCnt].text = kcode.ToString();
                Variable.curLetterCnt++;
            }
                
        }
    }
}
