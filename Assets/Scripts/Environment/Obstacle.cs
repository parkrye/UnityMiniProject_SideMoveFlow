using UnityEngine;

public class Obstacle : MonoBehaviour, IHitable
{
    int life;
    public bool IsAlive { get { return (life > 0); } }

    void Awake()
    {
        if (life == 0)
            life = 10;
    }

    public void Hit(int damage)
    {
        life -= damage;
    }
}
