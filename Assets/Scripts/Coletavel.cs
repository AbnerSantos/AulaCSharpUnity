using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coletavel : MonoBehaviour
{
    [SerializeField] Door porta;

    // Eu só criei essa simple action para introduzir delegates.
    // public delegate void SimpleAction();

    // Você pode usar direto a Action, que já é um delegate padrão do sistema!
    // public static event Action OnGetKey;

    // Chamado pela Unity
    void OnTriggerEnter2D(Collider2D other)
    {
        porta.Abre();

        // No caso de usar eventos
        // OnGetKey();

        Destroy(gameObject);
    }
}
