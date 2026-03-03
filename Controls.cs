using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    //para obtener numOrder
    public Registradora registradora;
    public Orden orden;

    //valores para calificar 
    public string vasoPlayer;
    public string toppingPlayer;
    public string salsaPlayer;
    public string camaronPlayer;

    public string vasoOrder;
    public string salsaOrder;
    public string camaronOrder;
    public string toppingOrder;

    //cantidad de objetos
    public int cantVasos;
    public int cantToppings;
    public int cantSalsa;
    public int cantCamaron;
    public bool is_Grande;

    InputAction putIngr4;

    void Start()
    {
        registradora = GameObject.Find("Registradora").GetComponent<Registradora>();
        putIngr4 = InputSystem.actions.FindAction("ingr4");
    }

    void Update()
    {
        // ENTREGAR ORDEN (estación camarón)
        if (putIngr4.WasPressedThisFrame())
        {
            CalificarOrden();
        }
    }

    void CalificarOrden()
    {
        // si no hay órdenes
        if (registradora.ordenes.Count == 0) return;

        // siempre tomamos la PRIMERA
        GameObject thisOrder = registradora.ordenes[0];
        orden = thisOrder.GetComponent<Orden>();

        toppingOrder = orden.GetOrderTop();
        salsaOrder = orden.GetOrderSalsa();
        vasoOrder = orden.GetOrderVaso();
        camaronOrder = orden.GetOrderCamaron();

        bool correcta =
            salsaOrder == salsaPlayer &&
            toppingOrder == toppingPlayer &&
            vasoOrder == vasoPlayer &&
            camaronOrder == camaronPlayer;

        if (correcta)
        {
            Debug.Log("Orden correcta");
        }
        else
        {
            registradora.Pain();
            registradora.ActivaCorazones(registradora.Hp());
        }

        //me voy a matar si no jala esta vez
        registradora.ordenes.RemoveAt(0);
        Destroy(thisOrder);

        // reiniciar plato
        cantVasos = 0;
        cantCamaron = 0;
        cantSalsa = 0;
        cantToppings = 0;

        vasoPlayer = "";
        toppingPlayer = "";
        salsaPlayer = "";
        camaronPlayer = "";
    }
}
