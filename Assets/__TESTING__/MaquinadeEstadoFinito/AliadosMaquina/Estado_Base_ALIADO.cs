
using UnityEngine;

public  abstract class Estado_Base_ALIADO
{
    //abstract on each method means we need to define their funcitonality in classes that derive from the base state
    public abstract void EnterState(Controlador_De_Estados_ALIADOS aliado);

    public abstract void UpdateState(Controlador_De_Estados_ALIADOS alidao);

    public abstract void OnCollisionEnter(Controlador_De_Estados_ALIADOS aliado, Collision collision);
}
