using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _roadPrefab;
    [SerializeField] private float _speed;
    [SerializeField] private List<GameObject> _roads;


    private float _distance;
    private int _index;


    public float Speed { get => _speed; set => _speed = value;}

    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            Create();
            _distance += 15;
        }
    }

    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (transform.position.x < -_index * 15)
        {
            Create();
            _index++;
            Destroy(_roads[0]);
            _roads.RemoveAt(0);
        }
    }

    private void Create()
    {
        int rand = Random.Range(0, _roadPrefab.Length);
        GameObject road = Instantiate(_roadPrefab[rand], transform.right * _distance, _roadPrefab[rand].transform.rotation, transform);
        _roads.Add(road);

       
    }
}
