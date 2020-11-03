using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    private Rigidbody MeuRigidbody;

    // Start is called before the first frame update
    void Awake()
    {
        MeuRigidbody = GetComponent<Rigidbody>();
    }

    public void Movimentar(Vector3 direcao, float velocidade)
    {
        MeuRigidbody.MovePosition(MeuRigidbody.position + direcao.normalized * velocidade * Time.deltaTime);
    }

    public void Rotacionar(Vector3 direcao)
    {
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        MeuRigidbody.MoveRotation(novaRotacao);
    }

    public void RotacionarJogador(LayerMask Mascarachao)
    {

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 300, Mascarachao))
        {
            Vector3 PosicaoMiraJogador = impacto.point - transform.position;

            PosicaoMiraJogador.y -= transform.position.y;

            Rotacionar(PosicaoMiraJogador);

        }

    }

}
