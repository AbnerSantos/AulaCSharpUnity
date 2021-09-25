using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pular : MonoBehaviour
{
    [SerializeField] float forca;
    [SerializeField] ChecagemDeChão checagemDeChão;
    Rigidbody2D rigidBody;
    Animator animator;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Só pode pular se estiver no chão, para não poder pular voando.
        if (Input.GetKeyDown(KeyCode.Space) && checagemDeChão.EstaNoChao)
        {
            rigidBody.AddForce(new Vector2(0f, forca), ForceMode2D.Impulse);
            animator.SetTrigger("Pular");
        }

        // Se não estiver no chào e estiver descendo, está caindo
        if (checagemDeChão.EstaNoChao == false)
        {
            if (rigidBody.velocity.y < -Mathf.Epsilon)
                animator.SetBool("Caindo", true);
        }
        else
            animator.SetBool("Caindo", false);
    }
}
