using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{

    [SerializeField]
    private UnityEngine.UI.Image m_Image;
    public void UpdateHealthBar(HealthController healthController)
    {
        m_Image.fillAmount = healthController.PorcentageHealth;
    }
}
