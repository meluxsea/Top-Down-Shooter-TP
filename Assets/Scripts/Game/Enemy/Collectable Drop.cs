using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableDrop : MonoBehaviour
{
    [SerializeField]
    private float _chanceOfCollectableDrop;

    private CollectableSpawner _CBspawner;


    private void Awake()
    {
        _CBspawner = FindObjectOfType<CollectableSpawner>();

    }

    public void RandomlyDropCollectable()
    {
        float random = Random.Range(0f, 1f);

        if(_chanceOfCollectableDrop >= random)
        {
            _CBspawner.SpawnCollectable(transform.position);
        }
    }



}
