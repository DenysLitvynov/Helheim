using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoMovimientoAliado : Estado_Base_ALIADO
{
    public float velocidad;
    private Espectro_Stats espectro;

    public override void EnterState(Controlador_De_Estados_ALIADOS aliado)
    {

    }

    public override void UpdateState(Controlador_De_Estados_ALIADOS aliado)
    {
        aliado.transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        float xCoordinate = aliado.transform.position.x;
        if (xCoordinate > 18.53277f)
        {
            StopMovement();
        }
    }

    public override void OnCollisionEnter(Controlador_De_Estados_ALIADOS aliado, Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            aliado.CambiarEstado(aliado.estadoCombate);
        }else if (espectro!=null)
        {
            aliado.estadoCombate.recibirDano(aliado, espectro.daсo_espectro);
        }
    }
    void StopMovement()
    {
    
        velocidad = 0f;
    }
}
