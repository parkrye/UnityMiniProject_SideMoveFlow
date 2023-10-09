using UnityEngine;

public abstract class Equipment : MonoBehaviour
{
    protected EquipmentData equipmentData;

    public string GetEquipmentName()
    {
        if (equipmentData == null)
            return "";

        return equipmentData.equipmentName;
    }

    public int GetEquipmentIndex()
    {
        if (equipmentData == null)
            return -1;

        return equipmentData.effectIndex;
    }

    public float GetEquipmentRate()
    {
        if (equipmentData == null)
            return -1f;

        return equipmentData.effectRate;
    }

    public Color GetEquipmentColor()
    {
        if (equipmentData == null)
            return Color.black;

        return equipmentData.equipmentColor;
    }
}
