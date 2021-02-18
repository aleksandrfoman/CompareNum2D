using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardInfo : MonoBehaviour
{
    public int ScoreCard;
    [SerializeField]
    private TextMeshProUGUI _textScoreCard;
    
    private void Start()
    {
        _textScoreCard.text = ScoreCard.ToString();
    }
}
