using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    Vector2 direccion;

    [SerializeField]
    float impulse = 10f;

    [SerializeField]
    TextMeshProUGUI labelFuel;

    [SerializeField]
    float fuel = 100f;

    bool isPlaying = false;

    [SerializeField]
    GameObject prefabParticles;

    [SerializeField]
    GameObject pantallaLost;

    [SerializeField]
    GameObject musicBackground;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        //body.AddForce(transform.right, ForceMode2D.Impulse);
    }


    // Update is called once per frame
    void Update()
    {
        labelFuel.text = fuel.ToString("0") + "%";

        if (fuel > 0)
        {
            isPlaying = true;

            if (isPlaying == true)
            {
                direccion.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;

                direccion.y = Input.GetAxis("Vertical") * Time.deltaTime * impulse;

                //fuel -= Time.deltaTime;

                fuel = fuel - 5 * Time.deltaTime;
            }
            
        }

        else
        {
            isPlaying = false;
            fuel = 0f;
            pantallaLost.SetActive(true);
            musicBackground.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        body.AddForce(direccion, ForceMode2D.Impulse);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
         if (collision.gameObject.tag == "Gasolina")
         {
             fuel += 10f;
             if (fuel > 100f)
             {
                 fuel = 100f;
             }

                //collision.GetComponent<AudioSource>().Play();
         }
        

        Instantiate(prefabParticles, collision.transform.position, collision.transform.rotation);

        Destroy(collision.gameObject);

    }

    public void ClickButtom()
    {
        Debug.Log("Ha clicado");
        SceneManager.LoadScene(0);
    }
}
