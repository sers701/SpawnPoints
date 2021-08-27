using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _objectToSpawn;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _delayBetweenSpawn;
    [SerializeField] private bool _isWorking;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<Transform>();
        StartCoroutine(SpawnObjectsWithDelay());
    }

    private void SpawnObject(int numberOfPoint)
    {
        GameObject newObject = Instantiate(_objectToSpawn, _spawnPoints[numberOfPoint]);
    }

    private IEnumerator SpawnObjectsWithDelay()
    {
        WaitForSeconds seconds = new WaitForSeconds(_delayBetweenSpawn);
        int counter = 1;
        while (_isWorking)
        {
            if (counter >= _spawnPoints.Length )
            {
                counter = 1;
            }
                print(counter);
            SpawnObject(counter);
            yield return seconds;
            counter++;
        }
    }
}
