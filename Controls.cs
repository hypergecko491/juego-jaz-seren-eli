using System.Collections;
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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    // Update is called once per frame
    void Update()
    {

        float numOrder = registradora.GetnumOrder();
        //Esto cambia estaciones
        if (changeStationR.WasPressedThisFrame())
        {
            switch (numStation)
            {
                //estas en vasos, vas a toppings
                case 0:
                    camara.transform.position = toppingCamara.transform.position;
                    numStation = 1;
                    break;
                //estas en toppings, vas a salsa
                case 1:
                    camara.transform.position = salsaCamara.transform.position;
                    numStation = 2;
                    break;
                //estas en salsa, vas a camaron
                case 2:
                    camara.transform.position = camaronCamara.transform.position;
                    numStation = 3;
                    break;
                //estas en camaron, vas a vasos
                case 3:
                    camara.transform.position = vasoCamara.transform.position;
                    numStation = 0;
                    break;
            }
        }

        if (changeStationL.WasPressedThisFrame())
        {
            switch (numStation)
            {
                //estas en vasos, vas a camaron
                case 0:
                    camara.transform.position = camaronCamara.transform.position;
                    numStation = 3;
                    break;
                //estas en toppings, vas a vasos
                case 1:
                    camara.transform.position = vasoCamara.transform.position;
                    numStation = 0;
                    break;
                //estas en salsa, vas a toppings
                case 2:
                    camara.transform.position = toppingCamara.transform.position;
                    numStation = 1;
                    break;
                //estas en camaron, vas a salsa
                case 3:
                    camara.transform.position = salsaCamara.transform.position;
                    numStation = 2;
                    break;
            }
        }
        //Ingredientes
        if (putIngr1.WasPressedThisFrame())
        {

            switch (numStation)
            {
                //station vasos, vasoChico
                case 0:
                    if (cantVasos == 0)
                    {
                        Instantiate(vasoChico, ingrLoad.position, ingrLoad.rotation);
                        is_Grande = false;
                        cantVasos++;
                        vasoPlayer = "chico";
                    }
                    break;
                //station toppings, pepino
                case 1:

                    if (is_Grande == false && cantVasos == 1)
                    {
                        Instantiate(pepinoChico, ingrLoadChicoTopping.position, ingrLoadChicoTopping.rotation);
                        toppingPlayer = "pepino";
                    }
                    if (is_Grande == true && cantVasos == 1)
                    {
                        Instantiate(pepinoGrande, ingrLoadGrandeTopping.position, ingrLoadGrandeTopping.rotation);
                        toppingPlayer = "pepino";
                    }

                    break;
                //station salsas, clamato
                case 2:
                    if (is_Grande == false && cantVasos == 1)
                    {
                        Instantiate(clamatoChico, ingrLoadChicoSalsa.position, ingrLoadChicoSalsa.rotation);
                        salsaPlayer = "clamato";
                    }
                    if (is_Grande == true && cantVasos == 1)
                    {
                        Instantiate(clamatoGrande, ingrLoadGrandeSalsa.position, ingrLoadGrandeSalsa.rotation);
                        salsaPlayer = "clamato";
                    }

                    break;
                //station camaron, crudo
                case 3:
                    if (is_Grande == false && cantVasos == 1)
                    {
                        Instantiate(crudoChico, ingrLoadChicoCamaron.position, ingrLoadChicoCamaron.rotation);
                        camaronPlayer = "crudo";
                    }
                    if (is_Grande == true && cantVasos == 1)
                    {
                        Instantiate(crudoGrande, ingrLoadGrandeCamaron.position, ingrLoadGrandeCamaron.rotation);
                        camaronPlayer = "crudo";
                    }

                    break;

            }
        }
        if (putIngr2.WasPressedThisFrame())
        {
            switch (numStation)
            {
                //station vasos, vasoGrande
                case 0:
                    if (cantVasos == 0 && numOrder == 50)
                    {
                        Instantiate(vasoGrandeMarco, ingrLoad.position, ingrLoad.rotation);
                        is_Grande = true;
                        cantVasos++;
                        vasoPlayer = "grande";
                    }
                    else if (cantVasos == 0 && numOrder != 50)
                    {
                        Instantiate(vasoGrande, ingrLoad.position, ingrLoad.rotation);
                        is_Grande = true;
                        cantVasos++;
                        vasoPlayer = "grande";
                    }

                    break;
                //station toppings, aguacate
                case 1:

                    if (is_Grande == false && cantVasos == 1)
                    {
                        Instantiate(aguacateChico, ingrLoadChicoTopping.position, ingrLoadChicoTopping.rotation);
                        toppingPlayer = "aguacate";
                    }
                    if (is_Grande == true && cantVasos == 1)
                    {
                        Instantiate(aguacateGrande, ingrLoadGrandeTopping.position, ingrLoadGrandeTopping.rotation);
                        toppingPlayer = "aguacate";
                    }
                    break;
                //station salsas, chevecha
                case 2:
                    if (is_Grande == false && cantVasos == 1)
                    {
                        Instantiate(chevechaChico, ingrLoadChicoSalsa.position, ingrLoadChicoSalsa.rotation);
                        salsaPlayer = "chevecha";
                    }
                    if (is_Grande == true && cantVasos == 1)
                    {
                        Instantiate(chevechaGrande, ingrLoadGrandeSalsa.position, ingrLoadGrandeSalsa.rotation);
                        salsaPlayer = "chevecha";
                    }
                    break;
                //station camaron, cocido
                case 3:
                    if (is_Grande == false && cantVasos == 1)
                    {
                        Instantiate(cocidoChico, ingrLoadChicoCamaron.position, ingrLoadChicoCamaron.rotation);
                        camaronPlayer = "cocido";
                    }
                    if (is_Grande == true && cantVasos == 1)
                    {
                        Instantiate(cocidoGrande, ingrLoadGrandeCamaron.position, ingrLoadGrandeCamaron.rotation);
                        camaronPlayer = "cocido";
                    }
                    break;
            }
        }
        if (putIngr3.WasPressedThisFrame())
        {
            switch (numStation)
            {
                //station toppings, chile
                case 1:

                    if (is_Grande == false && cantVasos == 1)
                    {
                        Instantiate(chileChico, ingrLoadChicoTopping.position, ingrLoadChicoTopping.rotation);
                        toppingPlayer = "chile";
                    }
                    if (is_Grande == true && cantVasos == 1)
                    {
                        Instantiate(chileGrande, ingrLoadGrandeTopping.position, ingrLoadGrandeTopping.rotation);
                        toppingPlayer = "chile";
                    }
                    break;
                //station salsas, aguaChile
                case 2:
                    if (is_Grande == false && cantVasos == 1)
                    {
                        Instantiate(aguaChileChico, ingrLoadChicoSalsa.position, ingrLoadChicoSalsa.rotation);
                        salsaPlayer = "aguaChile";
                    }
                    if (is_Grande == true && cantVasos == 1)
                    {
                        Instantiate(aguaChileGrande, ingrLoadGrandeSalsa.position, ingrLoadGrandeSalsa.rotation);
                        salsaPlayer = "aguaChile";
                    }
                    break;
                //station camaron, empanizado
                case 3:
                    if (is_Grande == false && cantVasos == 1)
                    {
                        Instantiate(empaChico, ingrLoadChicoCamaron.position, ingrLoadChicoCamaron.rotation);
                        camaronPlayer = "empanizado";
                    }
                    if (is_Grande == true && cantVasos == 1)
                    {
                        Instantiate(empaGrande, ingrLoadGrandeCamaron.position, ingrLoadGrandeCamaron.rotation);
                        camaronPlayer = "empanizado";
                    }
                    break;
            }

            if (putIngr4.WasPressedThisFrame())
            {
                switch (numStation)
                {
                    //station salsas, breMis
                    case 2:
                        if (is_Grande == false && cantVasos == 1)
                        {
                            Instantiate(breMisChico, ingrLoadChicoSalsa.position, ingrLoadChicoSalsa.rotation);
                            salsaPlayer = "breMis";
                        }
                        if (is_Grande == true && cantVasos == 1)
                        {
                            Instantiate(breMisGrande, ingrLoadGrandeSalsa.position, ingrLoadGrandeSalsa.rotation);
                            salsaPlayer = "breMis";
                        }
                        break;
                    //station camaron, eliminar objeto
                    case 3:
                        orden = GameObject.FindFirstObjectByType<Orden>();
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

                            Destroy(sP);
                            Destroy(cP);
                            Destroy(vP);
                            Destroy(tP);

                            cantVasos--;
                        }
                        else
                        {
                            SceneManager.LoadScene(sceneName);
                        }




                        break;
                }
            }







        }
    }
}
    

