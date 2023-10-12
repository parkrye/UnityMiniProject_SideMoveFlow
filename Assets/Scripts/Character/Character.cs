using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour, IHitable, ITimeScalable
{
    [SerializeField] int index;
    CharacterData characterData;
    CharacterStateDialog characterStateDialog;
    CharacterDetect characterDetect;
    Animator animator;

    bool start;
    float speed;
    Vector3 moveDir;
    CharacterState state;

    UnityEvent<CharacterState> stateEvent;

    void Awake()
    {
        characterData = GameManager.Data.Party[index];
        characterData.Avatar = this;
        animator = GetComponentInChildren<Animator>();
        characterStateDialog = GetComponentInChildren<CharacterStateDialog>();
        characterDetect = GetComponentInChildren<CharacterDetect>();
        start = false;
        stateEvent = new UnityEvent<CharacterState>();
        stateEvent.AddListener(characterStateDialog.ChangeStateText);
        characterDetect.AddEventListener(FindEnemy);
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

    void FindEnemy()
    {

    }
}
