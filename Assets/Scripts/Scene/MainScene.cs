using UnityEngine;

public class MainScene : MonoBehaviour
{
    [SerializeField] GameState gameState;
    public GameState State { get { return gameState; } set { gameState = value; } }

    [SerializeField] MainSceneTimer timer;
    [SerializeField] MainSceneUI ui;

    private void Awake()
    {
        gameState = GameState.Ready;
    }

    void Start()
    {

    }

    void Update()
    {
        if (gameState == GameState.Done)
            return;

        if (gameState == GameState.Ready)
        {
            if (timer.ReadyOver())
            {
                for(int i = 0; i < 4; i++)
                {
                    timer.AddEventListenerOnTimeScaleChangeEvent(GameManager.Data.Party[0].Avatar.ChangeTimeScaleAction);
                }
                ui.SpeedButtonEvent.AddListener(timer.ChangeTimeScale);

                State = GameState.Move;
            }
            return;
        }

        if (timer.TimeOver())
        {
            State = GameState.Done;
        }
    }
}
