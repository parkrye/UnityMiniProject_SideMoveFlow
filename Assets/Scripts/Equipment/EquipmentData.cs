using UnityEngine;

[CreateAssetMenu (fileName = "EquipmentData", menuName = "Data/EquipmentData")]
public class EquipmentData : ScriptableObject
{
    public string equipmentName;
    public int effectIndex;
    // cost,    life,      damage,  guard,  heal,
    // hitRate, avoidRate, criRate, criMul, range
    public float effectRate;
    public Color equipmentColor;
}
