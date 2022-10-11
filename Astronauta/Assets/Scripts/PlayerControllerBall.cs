using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerControllerBall : MonoBehaviour
{
    Rigidbody2D body;

    Vector2 posicion;

    [SerializeField]
    float impulse = 10f;

    [SerializeField]
    TextMeshProUGUI diamondsText;

    int diamonds;

    [SerializeField]
    TextMeshProUGUI tiempoText;

    [SerializeField]
    float tiempo;

    [SerializeField]
    GameObject lostScreen;

    [SerializeField]
    GameObject puertas;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();

        diamondsText.text = "Diamantes: 0"; 
    }

    private void Update()
    {
        tiempo -= Time.deltaTime;
        tiempoText.text = "Tiempo: " + tiempo.ToString("00.00");
        posicion.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;
        posicion.y = Input.GetAxis("Vertical") * Time.deltaTime * impulse;

        diamondsText.text = "Diamantes: " + diamonds.ToString() + " /10";

        if(tiempo <= 0)
        {
            tiempo = 0f;
            this.enabled = false;
            lostScreen.SetActive(true);
        }

        if(diamonds >= 9)
        {
            puertas.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Diamond")
        {
            diamonds++;
            Destroy(collision.gameObject);
            tiempo += 20f;
        }
    }

    private void FixedUpdate()
    {
        body.AddForce(posicion, ForceMode2D.Impulse);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }


}
