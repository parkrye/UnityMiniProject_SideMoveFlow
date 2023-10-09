using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyScene : MonoBehaviour
{
    [SerializeField] string moveSceneName;
    public void OnStartButtonClicked()
    {
        if (moveSceneName.Length == 0)
            return;

        try
        {
            SceneManager.LoadScene(moveSceneName);
        }
        catch
        {
            SceneManager.LoadScene(1);
        }
    }

    public void OnChangeSliderValue(int index, bool isBrave, float value)
    {
        GameManager.Data.Party[index].ModifyWeight(isBrave, value);
    }

    public void OnChangeRedBraveSliderValue(float value)
    {
        OnChangeSliderValue(0, true, value);
    }
    public void OnChangeRedHastySliderValue(float value)
    {
        OnChangeSliderValue(0, false, value);
    }
    public void OnChangeBlueBraveSliderValue(float value)
    {
        OnChangeSliderValue(1, true, value);
    }
    public void OnChangeBlueHastySliderValue(float value)
    {
        OnChangeSliderValue(1, false, value);
    }
    public void OnChangeGreenBraveSliderValue(float value)
    {
        OnChangeSliderValue(2, true, value);
    }
    public void OnChangeGreenHastySliderValue(float value)
    {
        OnChangeSliderValue(2, false, value);
    }
    public void OnChangeYellowBraveSliderValue(float value)
    {
        OnChangeSliderValue(3, true, value);
    }
    public void OnChangeYellowHastySliderValue(float value)
    {
        OnChangeSliderValue(3, false, value);
    }
}
