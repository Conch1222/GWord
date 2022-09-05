using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Define a trie for loading vocabulary use
public class Trie
{
    private static Trie instance = null;

    private class TNode
    {
        public TNode[] next;
        public string word;
        public int childCnt;
        public TNode()
        {
            next=new TNode[26];
            word = null;
            childCnt = 0; //root.childCnt==total vocabulary
        }  
    }

    public static Trie getInstance
    {
        get
        {
            if (instance == null)
                instance = new Trie();
            
            return instance;
        }
    }

    private TNode root;
    private System.Random rand;
    private Trie()
    {
        root = new TNode();
        rand = new System.Random();
    }
    public void Add(string word)
    {
        TNode cur = root;
        cur.childCnt++;

        for(int i=0;i<word.Length;i++)
        {
            if(cur.next[word[i]-'a']==null)
            {
                cur.next[word[i] - 'a'] = new TNode();
            }
            cur = cur.next[word[i] - 'a'];
            cur.childCnt++;
        }
        cur.word = word;
    }
    public bool Search(string word)
    {
        TNode cur = root;
        for (int i = 0; i < word.Length; i++)
        {
            if (cur.next[word[i] - 'a'] == null)
            {
                return false;
            }
            cur = cur.next[word[i] - 'a'];
        }
        if (cur.word == null)
            return false;
        else
            return true;
    }

    public string getRandomWord()
    {
        int index = rand.Next(root.childCnt);
        return getWordAtIndex(index);
    }

    private string getWordAtIndex(int index)
    {
        if (index >= root.childCnt) return null;

        int curCnt = 0;
        TNode cur = root;
        while(true)
        {
            foreach(TNode Tn in cur.next)
            {
                if(Tn!=null)
                {
                    if(curCnt+Tn.childCnt>index+1)
                    {
                        cur = Tn;
                        break;
                    }
                    else if(curCnt + Tn.childCnt == index + 1)
                    {
                        if (Tn.word != null)
                            return Tn.word;

                        cur = Tn;
                        break;
                    }
                    curCnt += Tn.childCnt;
                }
            }
        }
    }
}
