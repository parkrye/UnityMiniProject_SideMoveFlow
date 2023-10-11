using TMPro;
using UnityEngine;

public class CharacterStateDialog : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    public void ChangeStateText(CharacterState characterState)
    {
        text.text = characterState.ToString();
    }
}
