using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour
{
    //para obtener numOrder
    public Registradora registradora;
    public Orden orden;
    public int hp;

    //lo de la lista dinamica
    public List<GameObject> ordenes = new ();
    GameObject newOrder;
    [SerializeField] int numOrderComplete;
    [SerializeField] int listNum;

    public string vasoOrder;
    public string salsaOrder;
    public string camaronOrder;
    public string toppingOrder;

    [SerializeField] GameObject sP;
    [SerializeField] GameObject tP;
    [SerializeField] GameObject vP;
    [SerializeField] GameObject cP;

    [SerializeField] string sceneName;
   
    //valores para calificar 
    public string vasoPlayer;
    public string toppingPlayer;
    public string salsaPlayer;
    public string camaronPlayer;

    //estas son las posiciones de las camaras para las estaciones
    [SerializeField] Camera camara;
    [SerializeField] Transform vasoCamara;
    [SerializeField] Transform toppingCamara;
    [SerializeField] Transform salsaCamara;
    [SerializeField] Transform camaronCamara;
    
    //esto es para mover la camara
    [SerializeField] int numStation;

    //Este es el lugar donde se ponen los ingredientes
    [SerializeField] Transform ingrLoad;
    [SerializeField] Transform ingrLoadGrandeTopping;
    [SerializeField] Transform ingrLoadChicoTopping;
    [SerializeField] Transform ingrLoadGrandeSalsa;
    [SerializeField] Transform ingrLoadChicoSalsa;
    [SerializeField] Transform ingrLoadGrandeCamaron;
    [SerializeField] Transform ingrLoadChicoCamaron;

    //cantidad de objetos
    public int cantVasos;
    public int cantToppings;
    public int cantSalsa;
    public int cantCamaron;
    public bool is_Grande;

    //Esto son los ingredientes
    //Vasos
    [SerializeField] GameObject vasoChico;
    [SerializeField] GameObject vasoGrande;
    [SerializeField] GameObject vasoGrandeMarco;
    //Toppings
    [SerializeField] GameObject pepinoChico;
    [SerializeField] GameObject pepinoGrande;
    [SerializeField] GameObject aguacateChico;
    [SerializeField] GameObject aguacateGrande;
    [SerializeField] GameObject chileChico;
    [SerializeField] GameObject chileGrande;
    //Salsas
    [SerializeField] GameObject clamatoChico;
    [SerializeField] GameObject clamatoGrande;
    [SerializeField] GameObject chevechaChico;
    [SerializeField] GameObject chevechaGrande;
    [SerializeField] GameObject aguaChileChico;
    [SerializeField] GameObject aguaChileGrande;
    [SerializeField] GameObject breMisChico;
    [SerializeField] GameObject breMisGrande;

    //Camaron
    [SerializeField] GameObject crudoChico;
    [SerializeField] GameObject crudoGrande;
    [SerializeField] GameObject cocidoChico;
    [SerializeField] GameObject cocidoGrande;
    [SerializeField] GameObject empaChico;
    [SerializeField] GameObject empaGrande;

    InputAction changeStationR;
    //D
    InputAction changeStationL;
    //A

    InputAction putIngr1;
    //H
    InputAction putIngr2;
    //J
    InputAction putIngr3;
    //K
    InputAction putIngr4;
    //L

    void Start()
    {
        registradora = GameObject.Find("Registradora").GetComponent<Registradora>();

        changeStationR = InputSystem.actions.FindAction("ChangeR");
        changeStationL = InputSystem.actions.FindAction("ChangeL");

        putIngr1 = InputSystem.actions.FindAction("ingr1");
        putIngr2 = InputSystem.actions.FindAction("ingr2");
        putIngr3 = InputSystem.actions.FindAction("ingr3");
        putIngr4 = InputSystem.actions.FindAction("ingr4");
    }

    public void AddOrdenList()
    {
        newOrder = GameObject.FindGameObjectWithTag("Orden");
        ordenes.Add(newOrder);
        listNum++;
    }

    void Update()
    {
        int numOrder = registradora.GetnumOrder();
        if (listNum < numOrder)
        { AddOrdenList(); }

        //station camaron, eliminar objeto
        if (putIngr4.WasPressedThisFrame() && numStation == 3)
        {
            if (numOrderComplete >= ordenes.Count) return;

            GameObject thisOrder = ordenes[numOrderComplete];
            orden = thisOrder.GetComponent<Orden>();

            toppingOrder = orden.GetOrderTop();
            salsaOrder = orden.GetOrderSalsa();
            vasoOrder = orden.GetOrderVaso();
            camaronOrder = orden.GetOrderCamaron();

            sP = GameObject.FindGameObjectWithTag("salsa");
            cP = GameObject.FindGameObjectWithTag("camaron");
            vP = GameObject.FindGameObjectWithTag("vaso");
            tP = GameObject.FindGameObjectWithTag("topping");

            if (salsaOrder == salsaPlayer && toppingOrder == toppingPlayer && vasoOrder == vasoPlayer && camaronOrder == camaronPlayer)
            {
                print("yay");
            }
            else
            {
                registradora.Pain();
                hp = registradora.Hp();
                registradora.ActivaCorazones(hp);
            }

            //  ahora solo destruye la orden correcta
            Destroy(thisOrder);
            ordenes.RemoveAt(numOrderComplete);
//me voy a suicidar, marco no me funes
            //reinicio de valores
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
}
