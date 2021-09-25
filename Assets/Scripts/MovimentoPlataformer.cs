using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlataformer : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rigidBody;
    Animator animator;

    bool estavaAndandoDireita = true; // Ele começa virado para direita

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rigidBody.velocity.y);

        // Não podemos comparar floats com 0, pois o erro do float faz com que não fiquem no zero,
        // mas sim valores como 0.00000546, por exemplo.
        bool estaAndando = Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon; // Epsilon é um float muito pequeno
        animator.SetBool("Andando", estaAndando);

        // Se mudou de direção, troca personagem de lado
        bool andandoDireita = rigidBody.velocity.x > 0f;
        if (estaAndando && andandoDireita != estavaAndandoDireita)
        {
            TrocaLado();
            estavaAndandoDireita = andandoDireita;
        }
    }

    void TrocaLado()
    {
        // Todo game object já possui uma referência ao seu transform
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
