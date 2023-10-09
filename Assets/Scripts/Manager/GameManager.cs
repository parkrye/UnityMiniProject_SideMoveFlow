using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    void Awake()
    {
        if (instance)
        {
            Destroy(this);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
        InitializeManager();
    }

    void OnDestroy()
    {
        if(instance == this)
            instance = null;
    }

    static DataManager dataManager;

    public static GameManager Instance { get { return instance; } }
    public static DataManager Data { get { return dataManager; } }

    void InitializeManager()
    {
        dataManager = gameObject.AddComponent<DataManager>();
        dataManager.Initialize();
    }
}
