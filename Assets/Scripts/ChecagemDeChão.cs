using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Existem maneiras melhores de fazer checagem de chão. Mais especificamente,
// BoxCast é bem melhor que usar colisão, uma vez que colisão com triggers é
// inconsistente, muitas vezes.
public class ChecagemDeChão : MonoBehaviour
{
    /*
        Todo GameObject possui um "Layer". Esse layer fica logo abaixo do nome,
        do objeto no inspector. Com ele, podemos limitar colisões, fazendo
        alguns layers não colidirem com outros layers. Aqui, por exemplo,
        não queremos que a checagem de chão colida com o jogador, apenas o chão.
    */
    [SerializeField] LayerMask mascaraDeColisão;

    bool estaNoChao;
    public bool EstaNoChao => estaNoChao;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(PodeColidir(other))
            estaNoChao = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(PodeColidir(other))
            estaNoChao = false;
    }

    private bool PodeColidir(Collider2D colisor)
    {
        // Só aceite :P mas se estiver curioso, a forma que máscaras funcionam é bem
        // interessante. Envolve binários e trues e falses. Pesquise!
        return mascaraDeColisão == (mascaraDeColisão | (1 << colisor.gameObject.layer));
    }
}
