using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public float _timeToWaitBeforeExit;

    public void OnPlayerDied()
    {
        Invoke(nameof(EndGame),_timeToWaitBeforeExit);


    }

    private void EndGame()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
