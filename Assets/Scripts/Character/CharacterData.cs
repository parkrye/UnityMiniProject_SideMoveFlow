using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Data/CharacterData")]
public class CharacterData : ScriptableObject
{
    public int[] status = new int[10];
    // cost,    life,      damage,  guard,  heal,
    // hitRate, avoidRate, criRate, criMul, range
    public Color characterColor;
    public AttackPosition attackPosition;
}
