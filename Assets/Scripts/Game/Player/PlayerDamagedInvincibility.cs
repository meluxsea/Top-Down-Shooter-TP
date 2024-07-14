using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedInvincibility : MonoBehaviour
{
    [SerializeField]
    private float invincibility;

    private InvincibleController _invincibilityController;


    private void Awake()
    {
        _invincibilityController = GetComponent<InvincibleController>();
    }



    public void StartInvincibility()
    {
        _invincibilityController.StartInvincibility(invincibility);
    }

}
