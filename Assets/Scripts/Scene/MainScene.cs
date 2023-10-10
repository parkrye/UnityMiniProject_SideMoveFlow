using UnityEngine;

public class MainScene : MonoBehaviour
{
    public static MainScene instance;

    [SerializeField] GameState gameState;
    public GameState State { get { return gameState; } set { gameState = value; } }

    [SerializeField] MainSceneTimer timer;
    [SerializeField] MainSceneUI ui;
    [SerializeField] CameraMovement cam;

    public MainSceneTimer Timer { get { return timer; } }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
        gameState = GameState.Ready;
    }

    private void Start()
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

                    State = GameState.Move;
                }
                return;
            case GameState.Battle:
                cam.ChangeMode(false);
                if (timer.TimeOver())
                {
                    State = GameState.Done;
                }
                break;
            case GameState.Move:
                cam.ChangeMode(true);
                break;
            default:
            case GameState.Done:
                return;
        }
    }
}
