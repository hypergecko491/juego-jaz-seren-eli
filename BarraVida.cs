using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    [SerializeField] Image imagenCorazon;
    [SerializeField] bool isActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ActivateHp()
    {
        imagenCorazon.enabled = true;
        isActive = true;
    }

    public void DeactivateHp()
    {
        imagenCorazon.enabled = false;
        isActive = false;
    }

    public bool IsActive()
    { return isActive; }
    
}
