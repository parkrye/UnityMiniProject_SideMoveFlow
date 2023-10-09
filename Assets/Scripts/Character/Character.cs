using UnityEngine;

public class Character : MonoBehaviour
{
    CharacterData characterData;

    Equipment[] equipments;

    void Awake()
    {
        equipments = new Equipment[2];
    }

    public void EquipEquipment(int index, Equipment equipment)
    {
        equipments[index] = equipment;
    }

    public void RemoveEquipment(int index)
    {
        equipments[index] = null;
    }

    public int GetStatus(int index)
    {
        if (characterData == null)
            return -1;

        float returnValue = characterData.status[index];

        for(int i = 0; i < 2; i++)
        {
            if (equipments[i] == null)
                continue;

            if (equipments[i].GetEquipmentIndex() != index)
                continue;

            if (equipments[i].GetEquipmentRate() < 0)
                continue;

            returnValue *= equipments[i].GetEquipmentRate();
        }

        return (int)returnValue;
    }
}
