using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterButtonClicked : MonoBehaviour
{
    public Button btn;
    public Text letter;
    public string txt,all;
    // Start is called before the first frame update
    void Start()
    { 
        btn.onClick.AddListener(OnBtnClick);
        txt = GameObject.Find(btn.name).GetComponentInChildren<Text>().text;
    }
    public void OnBtnClick()
    {
        all += txt;
        letter.text = all;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
