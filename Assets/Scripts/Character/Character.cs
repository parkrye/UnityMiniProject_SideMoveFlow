using UnityEngine;

public class Character : MonoBehaviour, IHitable, ITimeScalable
{
    [SerializeField] int index;
    CharacterData characterData;
    Animator animator;

    bool start;
    float speed;
    Vector3 moveDir;

    void Awake()
    {
        characterData = GameManager.Data.Party[index];
        characterData.Avatar = this;
        animator = GetComponentInChildren<Animator>();
        start = false;
    }

    public void Hit(int damage)
    {
        characterData.Status[1] -= damage;
    }

    public void ChangeTimeScaleAction(float timeScale)
    {
        speed = timeScale;
        animator.speed = speed;
    }

    public void StartMove()
    {
        start = true;
    }

    void Update()
    {
        moveDir = -Vector3.right * Time.fixedDeltaTime * speed;
        animator.SetFloat("Speed", 1f);
    }

    void FixedUpdate()
    {
        if (!start)
            return;

        transform.LookAt(transform.position + moveDir);
        transform.Translate(moveDir, Space.World);
    }
}
