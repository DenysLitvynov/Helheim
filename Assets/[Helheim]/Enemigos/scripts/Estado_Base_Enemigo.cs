
using UnityEngine;

public abstract class Estado_Base_Enemigo
{
    //abstract on each method means we need to define their funcitonality in classes that derive from the base state
    public abstract void EnterState(Controlador_de_Estados enemigo);

    public abstract void UpdateState(Controlador_de_Estados enemigo);

    public abstract void OnCollisionEnter(Controlador_de_Estados enemigo,Collision collision);

}
