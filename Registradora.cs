using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Registradora : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] GameObject order;
    [SerializeField] GameObject ordenMarco;
    [SerializeField] GameObject ordenChris;
    [SerializeField] Transform loadOrder1;
    //GameObject[] loadOrder;
    [SerializeField] int numOrderWorld;
    public float numOrder;
    [SerializeField] int orderForTimer;
    [SerializeField] float timeMax;
    [SerializeField] float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
{
    Instantiate(order, loadOrder1.position, loadOrder1.rotation);
    numOrder++;
    numOrderWorld++;
    orderForTimer++;
    timer = timeMax; // IMPORTANTE ELI NO TOQUES
}
    public float GetnumOrder()
    {
        return numOrder;
    }
    public void AddOrder()
        {
        orderForTimer++;
    }

    // Update is called once per frame
    void Update()
    {

        if(numOrderWorld > 10)
        {
            SceneManager.LoadScene(sceneName);
        }
      
       if (orderForTimer > 9)
        {
            orderForTimer = 0;
            timeMax--;
        }
       
        if (numOrder >= 102)
        {
            Destroy(gameObject);
        }
        timer -= Time.deltaTime;

        //for (float numOrder = 0; numOrder % 10 == 0; seconds--);

if (timer <= 0)
{
    if (numOrder != 50 && numOrder != 100)
    {
        Instantiate(order, loadOrder1.position, loadOrder1.rotation);
    }
    else if (numOrder == 50)
    {
        Instantiate(ordenMarco, loadOrder1.position, loadOrder1.rotation);
    }
    else if (numOrder == 100)
    {
        Instantiate(ordenChris, loadOrder1.position, loadOrder1.rotation);
    }

    numOrder++;
    numOrderWorld++;
    orderForTimer++;

    timer = timeMax;
}

      
    }
}
    


