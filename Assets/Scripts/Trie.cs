using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trie : MonoBehaviour
{
    private class TNode
    {
        public TNode[] next;
        public bool isEnd = false;
        public TNode()
        {
            next=new TNode[26];
            isEnd = false;
        }  
    }
    private TNode root = null;

    public Trie()
    {
        root = new TNode();
    }
    public void Add(string word)
    {
        TNode cur = root;
        for(int i=0;i<word.Length;i++)
        {
            if(cur.next[word[i]-'a']==null)
            {
                cur.next[word[i] - 'a'] = new TNode();
            }
            cur = cur.next[word[i] - 'a'];
        }
        cur.isEnd = true;
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
        return cur.isEnd;
    }
}
