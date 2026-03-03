using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // y
    InputAction startGame;
    [SerializeField] string station;

    void Start()
    {
        startGame = InputSystem.actions.FindAction("Start");

        if (startGame == null)
        {
            Debug.LogError("No se encontró la acción 'Start' en el Input System");
        }
        else
        {
            startGame.Enable();
        }
    }

    void Update()
    {
        if (startGame == null) return;

        if (startGame.WasPressedThisFrame())
        {
            SceneManager.LoadScene(station);
        }
    }
}
