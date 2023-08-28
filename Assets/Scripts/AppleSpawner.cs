using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _applePrefab;
    [SerializeField] private Collider cube;
    private GameObject _apple;
    private float _posX;
    

    private float _posZ;
    // Update is called once per frame

    void Start()
    {
        _posX = transform.position.x;
        _posZ = transform.position.z;
        
    }

    void Update()
    {
        Debug.Log(transform.childCount);
        SpawnApples();
    }

    private GameObject SpawnApples()
    {
        Vector3 _spawnPos = new Vector3(Random.Range(_posX - 6, _posX + 6), transform.position.y,Random.Range(_posZ - 6, _posZ + 6));

        if (transform.childCount > 0)
        {
            if (transform.GetChild(0).gameObject.activeInHierarchy == false)
            {
                transform.GetChild(0).position = _spawnPos;
                transform.GetChild(0).gameObject.SetActive(true);
                
            }
            return transform.GetChild(0).gameObject;
        }
        
            GameObject _prefab = Instantiate(_applePrefab, _spawnPos, Quaternion.identity);
            _prefab.transform.parent = transform;
            return _prefab;
        

    } 

}
