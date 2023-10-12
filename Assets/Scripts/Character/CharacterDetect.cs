using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterDetect : MonoBehaviour
{
    [SerializeField] string enemyTagName, obstacleTagName;

    UnityEvent enemyDetectEvent;
    List<Obstacle> obstacles;
    List<Enemy> enemies;

    void Awake()
    {
        obstacles = new List<Obstacle>(10);
        enemies = new List<Enemy>(10);
        enemyDetectEvent = new UnityEvent();
    }

    public void AddEventListener(UnityAction action)
    {
        enemyDetectEvent.AddListener(action);
    }

    public Obstacle GetNearestObstacle()
    {
        if(obstacles.Count == 0)
            return null;

        float nearestDistance = float.MaxValue;
        float distacne;
        int nearestIndex = 0;

        for(int i = 1; i < obstacles.Count; i++)
        {
            distacne = Vector3.SqrMagnitude(transform.position - obstacles[i].transform.position);
            if (distacne < nearestDistance)
            {
                nearestDistance = distacne;
                nearestIndex = i;   
            }
        }

        return obstacles[nearestIndex];
    }

    public Enemy GetNearestEnemy()
    {
        if (enemies.Count == 0)
            return null;

        float nearestDistance = float.MaxValue;
        float distacne;
        int nearestIndex = 0;

        for (int i = 1; i < enemies.Count; i++)
        {
            distacne = Vector3.SqrMagnitude(transform.position - enemies[i].transform.position);
            if (distacne < nearestDistance)
            {
                nearestDistance = distacne;
                nearestIndex = i;
            }
        }

        return enemies[nearestIndex];
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTagName))
        {
            enemies.Add(other.GetComponent<Enemy>());
            enemyDetectEvent?.Invoke();
        }
        else if (other.CompareTag(obstacleTagName))
        {
            obstacles.Add(other.GetComponent<Obstacle>());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(enemyTagName))
        {
            try
            {
                enemies?.Remove(other.GetComponent<Enemy>());
            }
            catch
            {

            }
        }
        else if (other.CompareTag(obstacleTagName))
        {
            try
            {
                obstacles?.Remove(other.GetComponent<Obstacle>());
            }
            catch
            {

            }
        }
    }
}
