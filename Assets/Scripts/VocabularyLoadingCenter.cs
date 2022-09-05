using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class VocabularyLoadingCenter : MonoBehaviour
{
    private static bool firstLoad = true;
    void Start()
    {
        if (firstLoad)
        {
            loadVocabulary();
            firstLoad = false;
        }
    }
    private void loadVocabulary()
    {
        Trie Vocabulary = Trie.getInstance;
        string path = System.Environment.CurrentDirectory;
        path += "\\Assets\\Files\\Vocabulary.txt";
        print(path);

        StreamReader reader = new StreamReader(@path);

        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        sw.Reset();
        sw.Start();

        string line = reader.ReadLine();
        while (line != null)
        {
            Vocabulary.Add(line);
            line = reader.ReadLine();
        }
        reader.Close();
        sw.Stop();
        string result1 = sw.Elapsed.TotalMilliseconds.ToString();
        print("Loading complete, spend time:" + result1);
    }
}
