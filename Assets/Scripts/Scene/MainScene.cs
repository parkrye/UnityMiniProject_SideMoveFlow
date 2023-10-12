using UnityEngine;
using UnityEngine.Events;

public class MainScene : MonoBehaviour
{
    public static MainScene instance;

    [SerializeField] GameState gameState;

    [SerializeField] MainSceneTimer timer;
    [SerializeField] MainSceneUI ui;
    [SerializeField] CameraMovement cam;

    public MainSceneTimer Timer { get { return timer; } }
    UnityEvent<GameState> GameStateEvent;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
        gameState = GameState.Ready;
        GameStateEvent = new UnityEvent<GameState>();
    }

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            timer.AddEventListenerOnTimeScaleChangeEvent(GameManager.Data.Party[i].Avatar.ChangeTimeScaleAction);
        }
        ui.SpeedButtonEvent.AddListener(timer.ChangeTimeScale);
    }

    void Update()
    {
        switch (gameState)
        {
            case GameState.Ready:
                if (timer.ReadyOver())
                {
                    for (int i = 0; i < 4; i++)
                    {
                        GameManager.Data.Party[i].Avatar.StartMove();
                    }
                    cam.StartMove();

                    gameState = GameState.Move;
                    GameStateEvent?.Invoke(gameState);
                }
                return;
            case GameState.Battle:
                cam.ChangeMode(false);
                if (timer.TimeOver())
                {
                    gameState = GameState.Done;
                    GameStateEvent?.Invoke(gameState);
                }
                break;
            case GameState.Move:
                if (timer.TimeOver())
                {
                    cam.ChangeMode(false);
                    gameState = GameState.Done;
                    GameStateEvent?.Invoke(gameState);
                }
                else
                {
                    cam.ChangeMode(true);
                }
                break;
            default:
            case GameState.Done:
                return;
        }
    }
}
