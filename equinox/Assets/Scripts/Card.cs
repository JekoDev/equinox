using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Equinox/Card", order = 1)]
public class Card : ScriptableObject
{
    public string CardName;
    public Sprite CardImage;
    public string Meaning1;
    public string Meaning2;
    public string Meaning3;
}