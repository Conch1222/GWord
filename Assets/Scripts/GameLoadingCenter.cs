using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoadingCenter : MonoBehaviour
{
    void Start()
    {
        Trie Vocabulary = Trie.getInstance;
        Variable.systemAns = Vocabulary.getRandomWord().ToUpper();
        print(Variable.systemAns);

        for(int i=0;i<5;i++)
        {
            if (!Variable.ansDic.ContainsKey(Variable.systemAns[i]))
                Variable.ansDic.Add(Variable.systemAns[i], 1);
            else
                Variable.ansDic[Variable.systemAns[i]]++;
        }
        foreach (var OneItem in Variable.ansDic)
        {
            print("Key = " + OneItem.Key + ", Value = " + OneItem.Value);
        }
    }
}
