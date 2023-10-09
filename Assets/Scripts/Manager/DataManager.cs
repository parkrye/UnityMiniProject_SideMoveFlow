using System;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    CharacterData[] party;

    public CharacterData[] Party { get {  return party; } }

    public void Initialize()
    {
        party = new CharacterData[4];

        party[0] = new CharacterData(1, 100, 10, 100, AttackPosition.Front);
        party[1] = new CharacterData(2, 100, 10, 100, AttackPosition.Middle);
        party[2] = new CharacterData(3, 100, 10, 400, AttackPosition.Middle);
        party[3] = new CharacterData(4, 100, 10, 400, AttackPosition.Back);
    }

    public void ResetData()
    {
        party[0] = new CharacterData(1, 100, 10, 100, AttackPosition.Front);
        party[1] = new CharacterData(2, 100, 10, 100, AttackPosition.Middle);
        party[2] = new CharacterData(3, 100, 10, 400, AttackPosition.Middle);
        party[3] = new CharacterData(4, 100, 10, 400, AttackPosition.Back);

        GC.Collect();
    }
}
