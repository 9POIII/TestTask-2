using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelData : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public List<GameObject> PlayerPrefabs;
        public List<GameObject> WallPrefabs;
        public List<GameObject> ShuffledWalls;
    }
    
    public static LevelData Instance;
    
    [SerializeField] private GameObject _roadModel;
    private int _roadLength;
    public List<Pool> Pools;
    
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SpawnPlayer(0);
        _roadLength = (int)_roadModel.transform.localScale.x;
    }

    public void SpawnBarrier(Vector3 place)
    {
        var randomPool = Random.Range(0, 2);
        var randomShuffle = Random.Range(0, 100);
        
        Pools[randomPool].ShuffledWalls = Pools[randomPool].WallPrefabs.OrderBy(_ => randomShuffle).ToList();
        
        for (int i = 50; i < _roadLength - 50; i += 50)
        {
            Instantiate(Pools[randomPool].ShuffledWalls[Random.Range(0, Pools[randomPool].ShuffledWalls.Count)], 
                new Vector3(i, place.y, place.z), Quaternion.identity);
        }
    }

    private void SpawnPlayer(int randomPool)
    {
        Instantiate(Pools[randomPool].PlayerPrefabs[0], new Vector3(14, -5, -2.5f), Quaternion.identity);
    }
}
