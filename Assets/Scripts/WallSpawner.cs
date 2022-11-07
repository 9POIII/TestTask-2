using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private GameObject _roadModel;
    [SerializeField] private GameObject _finishPlane;

    private void Start()
    {
        Application.targetFrameRate = 60;
        
        var length = (int)_roadModel.transform.localScale.x;
        
        for (int i = 50; i <= length - 100; i += 50)
        {
            Instantiate(_wallPrefab, new Vector3(i, 0, 0), Quaternion.identity);
        }

        Instantiate(_finishPlane, new Vector3(length - 50, 0.001f, 0), Quaternion.identity);
        
        LevelData.Instance.SpawnBarrier(new Vector3(100, 0, 0));
    }
}
