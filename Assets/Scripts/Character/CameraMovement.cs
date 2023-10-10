using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float nowX;
    Vector3 camPos;
    int count;
    bool start, isMove;

    private void Awake()
    {
        start = false;
    }

    public void StartMove()
    {
        start = true;
        camPos = transform.position;
    }

    public void ChangeMode(bool _isMove)
    {
        isMove = _isMove;
    }

    void Update()
    {
        if (!start || !isMove)
            return;

        count = 0;
        nowX = 0f;
        for (int i = 0; i < 4; i++)
        {
            if (GameManager.Data.Party[i].Status[1] > 0)
            {
                nowX += GameManager.Data.Party[i].Avatar.transform.position.x;
                count++;
            }
        }
        switch (count)
        {
            default:
            case 0:
                nowX *= 0f;
                break;
            case 1:
                break;
            case 2:
                nowX *= 0.5f;
                break;
            case 3:
                nowX *= 0.33f;
                break;
            case 4:
                nowX *= 0.25f;
                break;
        }

        camPos.x = nowX;
    }

    void LateUpdate()
    {
        if (!start || !isMove)
            return;

        transform.position = camPos;
    }
}
