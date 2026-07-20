using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnpoints;
    [SerializeField] private List<Transform> _busySpawnpoints;
    [SerializeField] private List<GameObject> _objects;

    public void RandomSpawn()
    {
        foreach (GameObject obj in _objects)
        {
            Transform randomPos = RandomPosition();

            obj.transform.position = randomPos.position;
        }
    }

    public void PlaceObject(GameObject obj)
    {
        obj.transform.position = RandomPosition().position;
    }

    private Transform RandomPosition()
    {
        Transform randomPos = _spawnpoints[Random.Range(0, _spawnpoints.Count)];

        while (_busySpawnpoints.Contains(randomPos))
        {
            randomPos = _spawnpoints[Random.Range(0, _spawnpoints.Count)];
        }

        _busySpawnpoints.Add(randomPos);

        return randomPos;
    }
}
