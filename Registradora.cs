using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Registradora : MonoBehaviour
{
    [SerializeField] BarraVida[] corazones;

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
    //[SerializeField] Sprite vasoNormal;
public List<GameObject> ordenes = new List<GameObject>();
public void QuitarOrden(GameObject orden)
{
    if (ordenes.Contains(orden))
    {
        ordenes.Remove(orden);
    }
}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (loadOrder1 == null)
        {
            Debug.LogError("loadOrder1 no asignado en Registradora");
            return;
        }

        Instantiate(order, loadOrder1.position, loadOrder1.rotation, null);
        numOrder++;
        numOrderWorld++;
        orderForTimer++;

        timer = 10; // IMPORTANTE ELI NO TOQUES

        ActivaCorazones(hp);
    }

    public void Pain()
    {
        hp--;
        ActivaCorazones(hp);
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
        if (corazones == null) return;

        for (int i = 0; i < corazones.Length; i++)
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
    {
        //esto regula la vida y te hace perder
        if (hp <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }

        if (numOrderWorld > 10)
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

        //for (float numOrder = 0; numOrder % 10 == 0; seconds--); ESTO NO SE DESCOMENTA

        if (timer <= 0)
        {
            //  aumentar contador de zapes si no lees esto
            if (numOrder != 50 && numOrder != 100)
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
    



