using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollection : MonoBehaviour
{
    public List<Card> Cards = new List<Card>();
    public static List<Card> Intern_Cards = new List<Card>();

    private void Start()
    {
        Intern_Cards = new List<Card>();
        Intern_Cards = Cards;
    }

    public static Card GetRandomCard()
    {
        Card cache = null;
        if (Intern_Cards == null || Intern_Cards.Count == 0) return cache;
        int Card = Random.Range(0, Intern_Cards.Count-1);
        if (Card < 0) Card = 0;
        cache = Intern_Cards[Card];
        Intern_Cards.Remove(Intern_Cards[Card]);
        return cache;
    }
}
