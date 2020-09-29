﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour
{
    [SerializeField] //mostra no editor mesmo sem estar público
    private int velocidade = 10;
    [SerializeField]
    private int forcaDoPulo = 1250;
    private float moveX;
    private bool direita = true;

    void Update()
    {
        moveJogador();
    }

    private void LateUpdate()
    {
        viraJogador();
    }

    void moveJogador()
    {
        moveX = Input.GetAxis("Horizontal");
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * velocidade,
                                                                     gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            pula();
        }

    }

    void pula()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * forcaDoPulo);
    }

    void viraJogador()
    {
        if (moveX > 0)
        {
            direita = true;
        }
        else if (moveX < 0)
        {
            direita = false;
        }
        Vector2 escala = transform.localScale;
        if ((escala.x > 0 && !direita) || (escala.x < 0 && direita))
        {
            escala.x = escala.x * -1;
            transform.localScale = escala;
        }
    }
}
