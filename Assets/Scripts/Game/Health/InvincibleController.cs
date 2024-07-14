using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleController : MonoBehaviour
{
    private HealthController _healthController;

    private void Awake()
    {
        _healthController = GetComponent<HealthController>();
    }
    public void StartInvincibility(float invincibility)
    {
        StartCoroutine(InvincibilityCoroutine(invincibility));
    }
    private IEnumerator InvincibilityCoroutine(float invincibility)
    {
        _healthController.IsInvincible = true;
        yield return new WaitForSeconds(invincibility);
        _healthController.IsInvincible = false;

    }

}
