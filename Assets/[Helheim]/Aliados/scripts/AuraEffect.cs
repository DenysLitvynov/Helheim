using UnityEngine;

public class AuraEffect : MonoBehaviour
{
    public Color auraColor = new Color(1.0f, 0.84f, 0.0f, 1.0f); // Colore oro

    void Start()
    {
        // Aggiungi un componente ParticleSystem all'oggetto se non esiste già
        ParticleSystem ps = gameObject.GetComponent<ParticleSystem>();
        if (ps == null)
        {
            ps = gameObject.AddComponent<ParticleSystem>();
        }

        var main = ps.main;
        main.startColor = auraColor;
        main.startSize = 0.5f;
        main.startLifetime = 1.0f;
        main.simulationSpace = ParticleSystemSimulationSpace.World;

        var emission = ps.emission;
        emission.rateOverTime = 10;

        var shape = ps.shape;
        shape.shapeType = ParticleSystemShapeType.Sphere;
        shape.radius = 1.0f; // Raggio regolato per un valore ragionevole

        // Assicurati che il ParticleSystemRenderer abbia un materiale
        var renderer = ps.GetComponent<ParticleSystemRenderer>();
        if (renderer == null)
        {
            renderer = ps.gameObject.AddComponent<ParticleSystemRenderer>();
        }
        renderer.material = new Material(Shader.Find("Particles/Standard Unlit"));
        renderer.material.color = auraColor;
    }
}

