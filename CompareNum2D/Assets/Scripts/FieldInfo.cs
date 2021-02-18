using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldInfo : MonoBehaviour
{
    public int fieldScore;
    private List<CardInfo> _cards = new List<CardInfo>();
    private int _temp;
    private void Start()
    {
        _temp = 0;
    }
    

    private void Update()
    {
        int childCount = transform.childCount;
        
        Debug.Log("CC" + transform.childCount);
        _temp = transform.childCount;
    }

    public void AddCardField(CardInfo cardInfo)
    {
        _cards.Add(cardInfo);
        CheckFieldScore();
    }
    public void RemoveCardField(CardInfo cardInfo)
    {
        _cards.Remove(cardInfo);
        CheckFieldScore();
    }

    private void CheckFieldScore()
    {
        Debug.Log("Counts="+_cards.Count+"Name="+ transform.name);
    }
}
