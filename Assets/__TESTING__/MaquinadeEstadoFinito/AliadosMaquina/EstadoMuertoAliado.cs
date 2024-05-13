using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoMuertoAliado : Estado_Base_ALIADO
{
    //abstract on each method means we need to define their funcitonality in classes that derive from the base state
    public override void EnterState(Controlador_De_Estados_ALIADOS aliado) { }

    public override void UpdateState(Controlador_De_Estados_ALIADOS alidao) { }

    public override void OnCollisionEnter(Controlador_De_Estados_ALIADOS aliado, Collision collision) { }
}
