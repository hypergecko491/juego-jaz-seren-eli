using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    InputAction loadMenu;
    [SerializeField] string menuScene;

    void Start()
    {
        loadMenu = InputSystem.actions.FindAction("GoMenu");

        if (loadMenu == null)
        {
            Debug.LogError("No se encontró la acción 'GoMenu' en el Input System");
        }
        else
        {
            loadMenu.Enable();
        }
    }

    void Update()
    {
        if (loadMenu == null) return;

        if (loadMenu.WasPressedThisFrame())
        {
            SceneManager.LoadScene(menuScene);
        }
    }
}
