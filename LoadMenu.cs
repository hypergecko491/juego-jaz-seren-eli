using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class LoadMenu : MonoBehaviour
{
    InputAction loadMenu;
    [SerializeField] string menuScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        loadMenu = InputSystem.actions.FindAction("GoMenu");
    }

    // Update is called once per frame
    void Update()
    {
     if(loadMenu.WasPressedThisFrame())
        {
            SceneManager.LoadScene(menuScene);
        }
    }
}
