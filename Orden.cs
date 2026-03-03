using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Orden : MonoBehaviour

{
    public Registradora registradora;
    //[SerializeField] GameObject otraOrden;
    //public float numOrder;

    public Sprite[] topping;
    public Sprite[] salsa;
    public Sprite[] camaron;
    public Sprite[] vasos;

    public string toppingOrder;
    public string vasoOrder;
    public string salsaOrder;
    public string camaronOrder;

    [SerializeField] SpriteRenderer toppingPlace;
    [SerializeField] SpriteRenderer salsaPlace;
    [SerializeField] SpriteRenderer camaronPlace;
    [SerializeField] SpriteRenderer vasosPlace;

    [SerializeField] Transform camTransform;
    [SerializeField] Vector3 offsets;
    [SerializeField] Vector3 randomSpawnPosition;
    [SerializeField] Vector3 moveAway;
   
    public int thisNumOrder;

    [SerializeField] float x1;
    [SerializeField] float x2;
    [SerializeField] float y1;
    [SerializeField] float y2;


    //[SerializeField] TMP_Text  textoNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        registradora = GameObject.Find("Registradora").GetComponent<Registradora>();
        camTransform = GameObject.Find("Camara1").transform;



        int randomTopping = Random.Range(0, topping.Length);
        toppingPlace.sprite = topping[randomTopping];

        int randomSalsa = Random.Range(0, salsa.Length);
        salsaPlace.sprite = salsa[randomSalsa];

        int randomCamaron = Random.Range(0, camaron.Length);
        camaronPlace.sprite = camaron[randomCamaron];

        int randomVaso = Random.Range(0, vasos.Length);
        vasosPlace.sprite = vasos[randomVaso];

        switch (randomTopping)
        {
            case 0: toppingOrder = "pepino"; break;
            case 1: toppingOrder = "aguacate"; break;
            case 2: toppingOrder = "chile"; break;
        }

        switch (randomVaso)
        {
            case 0: vasoOrder = "chico"; break;
            case 1: vasoOrder = "grande"; break;
        }

        switch (randomSalsa)
        {
            case 0: salsaOrder = "clamato"; break;
            case 1: salsaOrder = "chevecha"; break;
            case 2: salsaOrder = "aguaChile"; break;
            case 3: salsaOrder = "breMis"; break;
        }

        switch (randomCamaron)
        {
            case 0: camaronOrder = "crudo"; break;
            case 1: camaronOrder = "cocido"; break;
            case 2: camaronOrder = "empanizado"; break;
        }

        thisNumOrder = registradora.GetnumOrder();

        //textoNum.text = "00" + thisNumOrder.ToString();


        randomSpawnPosition = new Vector3(Random.Range(x1, x2), Random.Range(y1, y2), Random.Range(0, 2F));
    }
    public string GetOrderTop()
    {
        return toppingOrder;
    }
    public string GetOrderVaso()
    {
        return vasoOrder;
    }
    public string GetOrderSalsa()
    {
        return salsaOrder;
    }
    public string GetOrderCamaron()
    {
        return camaronOrder;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camTransform.position + offsets + randomSpawnPosition;

    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Orden"))
        {
            print("Me muevo " + thisNumOrder);
            print(transform.position);
            transform.position += randomSpawnPosition;
            print(transform.position);
        }
    }
}

