public class CharacterData
{

    // 0: cost
    // 1: hp
    // 2: ap
    // 3: range
    public int[] Status { get; set; }

    float[] weigths;
    public float Brave { get { return weigths[0]; } }
    public float Hasty { get { return weigths[1]; } }
    
    public AttackPosition AttackPosition { get; private set; }
    public Character Avatar { get; set; }

    public CharacterData(int _cost, int _hp, int _ap, int _range, AttackPosition _attackPosition)
    {
        Status = new int[] { _cost, _hp, _ap, _range };
        AttackPosition = _attackPosition;
        weigths = new float[2];
    }

    public void ModifyWeight(bool isBrave, float value)
    {
        weigths[isBrave ? 0 : 1] = value;
    }
}
