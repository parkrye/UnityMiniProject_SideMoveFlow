using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MainSceneTimer : MonoBehaviour
{
    // 0: nowTime
    // 1: delayTime
    // 2: timeScale
    // 3: reverse 60
    // 4: timeLimit
    public float[] times { get; private set; }
    [SerializeField] TMP_Text timeText;

    UnityEvent<float> timeScaleChangeEvent;

    bool start;

    void Awake()
    {
        times = new float[] { 0f, 5f, 1f, 1f / 60f, 300f };
        timeScaleChangeEvent = new UnityEvent<float>();
        start = false;
    }

    void Update()
    {
        times[0] += Time.deltaTime * times[2];
        if (!start)
            return;
        timeText.text = $"{((int)((times[4] - times[0]) * times[3])).ToString()}:{((int)((times[4] - times[0]) % 60)).ToString()}";
    }

    public void ChangeTimeScale(float time)
    {
        Debug.Log($"{name} : {time}");

        times[2] = time;
        timeScaleChangeEvent?.Invoke(times[2]);
    }

    public void AddEventListenerOnTimeScaleChangeEvent(UnityAction<float> action)
    {
        timeScaleChangeEvent.AddListener(action);
    }

    public void RemoveEventListenerOnTimeScaleChangeEvent(UnityAction<float> action)
    {
        timeScaleChangeEvent.RemoveListener(action);
    }

    public bool ReadyOver()
    {
        if (times[0] > times[1])
        {
            times[0] = 0f;
            start = true;
            ChangeTimeScale(1f);
            return true;
        }
        return false;
    }

    public bool TimeOver()
    {
        if (times[0] > times[4])
        {
            ChangeTimeScale(0.5f);
            return true;
        }
        return false;
    }
}
