using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    private ICollectableBehaviour mCollectable;

    private void Awake()
    {
        mCollectable = GetComponent<ICollectableBehaviour>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement>();

        if(player != null)
        {
            mCollectable.OnCollected(player.gameObject);
            Destroy(gameObject);
        }
    }




}
