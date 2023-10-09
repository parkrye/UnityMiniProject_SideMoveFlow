using UnityEngine;

public class Character : MonoBehaviour, IHitable, ITimeScalable
{
    [SerializeField] int index;
    CharacterData characterData;

    [SerializeField] Animator animator;

    void Awake()
    {
        characterData = GameManager.Data.Party[index];
        characterData.Avatar = this;
        animator = GetComponentInChildren<Animator>();
    }

    public void Hit(int damage)
    {
        characterData.Status[1] -= damage;
    }

    public void ChangeTimeScaleAction(float timeScale)
    {
        animator.speed = timeScale;
    }
}
