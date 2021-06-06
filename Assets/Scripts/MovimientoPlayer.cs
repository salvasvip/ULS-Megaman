using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    [SerializeField] float velocidad = 5.0f;
    [SerializeField] float fuerzaSalto = 5.0f;
    Animator megaMan;
    SpriteRenderer flipPersonaje;
    Rigidbody2D PlayerRigi;
    void Start()
    {
        flipPersonaje = GetComponent<SpriteRenderer>();
        PlayerRigi = GetComponent<Rigidbody2D>();
        megaMan = GetComponent<Animator>();
        megaMan.SetBool("Espera",true);
    }
    void Update()
    {
        Camina();
    }

    void Camina()
    {
        if (Input.GetKey("d") || Input.GetKey("a"))
        {
            megaMan.SetBool("Espera", false);
            megaMan.SetBool("Camina", true);
        }
        else
        {
            megaMan.SetBool("Espera",true);
            megaMan.SetBool("Camina",false);
        }
        if (Input.GetKey("a"))
        {
            flipPersonaje.flipX = true;
            transform.Translate(Vector2.left * Time.deltaTime * velocidad);
        }

        if (Input.GetKey("d"))
        {
            flipPersonaje.flipX = false;
            transform.Translate(Vector2.right * Time.deltaTime * velocidad);
        }
        if (Input.GetKeyDown("space") && Mathf.Abs(PlayerRigi.velocity.y) < 0.01f)
        {
            megaMan.SetBool("Espera", false);
            megaMan.SetBool("Camina", false);
            megaMan.SetBool("Salto", true);
            PlayerRigi.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
        else
        {
            megaMan.SetBool("Salto",false);
        }
    }
}
