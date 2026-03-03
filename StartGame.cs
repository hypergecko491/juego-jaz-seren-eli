using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    //y
    InputAction startGame;
    [SerializeField] string station;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startGame = InputSystem.actions.FindAction("Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame.WasPressedThisFrame())
        {
            SceneManager.LoadScene(station);
        }
    }
}
