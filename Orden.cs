using System.Security.Cryptography;
using UnityEngine;

public class Orden : MonoBehaviour

{
    public Registradora registradora;
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
   
    float thisNumOrder;

    [SerializeField] float x1;
    [SerializeField] float x2;
    [SerializeField] float y1;
    [SerializeField] float y2;

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
    randomSpawnPosition = new Vector3(Random.Range(x1, x2), Random.Range(y1, y2), 0);
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

    // Update is called once per frame
    void Update()
    {
        transform.position = camTransform.position + offsets + randomSpawnPosition;
    }
}

