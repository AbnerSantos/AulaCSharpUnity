using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Sprite portaAberta;

    SpriteRenderer spriteRenderer;
    Collider2D boxCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<Collider2D>();

        // Coletavel.OnGetKey += Abre;
    }

    public void Abre()
    {
        boxCollider.enabled = false;
        spriteRenderer.sprite = portaAberta;

        // É importante desinscrever o evento em algum momento.
        // Se não a referência fica pra sempre em memória, é um vazamento de memória
        // Coletavel.OnGetKey -= Abre;
    }
}
