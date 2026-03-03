using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Registradora : MonoBehaviour
{
    [SerializeField]BarraVida[] corazones;

    [SerializeField] string sceneName;
    public int hp = 3;
    [SerializeField] GameObject order;
    [SerializeField] GameObject ordenMarco;
    [SerializeField] GameObject ordenChris;
    [SerializeField] Transform loadOrder1;
    //GameObject[] loadOrder;
    [SerializeField] int numOrderWorld;
    public int numOrder;
    [SerializeField] int orderForTimer;
    [SerializeField] float timeMax;
    [SerializeField] float timer;

    [SerializeField] float streak;
    //[SerializeField] SpriteRenderer vasoEyes;
    //[SerializeField] SpriteRenderer vasoGrandeEyes;
    //[SerializeField] Sprite googlyEyes;
   // [SerializeField] Sprite vasoNormal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(order, loadOrder1.position, loadOrder1.rotation, null);
        numOrder++;
        numOrderWorld++;
        orderForTimer++;

        timer = 10; // IMPORTANTE ELI NO TOQUES

    }
    public void Pain()
    {
        hp--;
    }
    public void AddStreak()
    {
        streak += Time.deltaTime;
    }
    public void RemoveStreak()
    {
        streak = 0;
    }
   
    public int Hp()
    {

        return hp;
    }
    public int GetnumOrder()
    {
        return numOrder;
    }
    public void AddOrder()
        {
        orderForTimer++;
    }
    public void ActivaCorazones(int hp)
    {
        for(int i = 0; i < corazones.Length; i++)
        {
            if (i < hp)
            { 
                corazones[i].ActivateHp(); 
            }
            else
            {
                corazones[i].DeactivateHp();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {   //esto regula la vida y te hace perder
        if (hp <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }

        if(numOrderWorld > 10)
        {
            SceneManager.LoadScene(sceneName);
        }

        //esto es el final del juego
        if (numOrder >= 102)
        {
            Destroy(gameObject);
        }
        // esto maneja el tiempo
        if (orderForTimer > 9 && timeMax > 2)
        {
            orderForTimer = 0;
            timeMax--;
        }
        //esto maneja el tiempo x2
        timer -= Time.deltaTime;

        //esto maneja el streak

        //if (numOrder > 25 && numOrderWorld <= 4)
        //{
            //AddStreak();
        //}
        //else if (numOrder > 25 && numOrderWorld > 4)
        //{
       //     RemoveStreak();
       // }

       // if (streak > 5F)
       // {
       //     vasoEyes.sprite = googlyEyes;
       //     vasoGrandeEyes.sprite = googlyEyes;
       // }
       // else
       // {
       //     vasoEyes.sprite = vasoNormal;
       //     vasoEyes.sprite = vasoNormal;
       // }


        //for (float numOrder = 0; numOrder % 10 == 0; seconds--); ESTO NO SE DESCOMENTA

       if (timer <= 0)
        {
            if (numOrder != 50 || numOrder != 100)
            {
                Instantiate(order, loadOrder1.position, loadOrder1.rotation, null);

            }
            if (numOrder == 50)
            {
                Instantiate(ordenMarco, loadOrder1.position, loadOrder1.rotation, null);

            }

            if (numOrder == 100)
            {
                Instantiate(ordenChris, loadOrder1.position, loadOrder1.rotation, null);

            }
            numOrder++;
            numOrderWorld++;
            orderForTimer++;

            timer = timeMax;

        }

      
    }
}
    

