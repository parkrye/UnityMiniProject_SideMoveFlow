using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] float timeLimit;
    Character[] party;

    public float TimeLimit { get { return timeLimit; } }
    public Character[] Party { get {  return party; } }

    public void Initialize()
    {
        party = new Character[6];
    }

    public void SettingLimitTime(float _time)
    {
        timeLimit = _time;
    }

    public void AddParty(int index, Character character)
    {
        if (index < 0 || index >= 6)
            return;

        party[index] = character;
    }

    public void RemoveParty(int index)
    {
        if (index < 0 || index >= 6 || party[index] == null)
            return;

        party[index] = null;
    }
}
