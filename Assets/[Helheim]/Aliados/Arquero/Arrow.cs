using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f; // Velocidad de la flecha

    void Update()
    {
        // Mueve la flecha hacia la derecha a la velocidad especificada
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Destruye la flecha si choca con un enemigo o con el entorno
        if (collision.gameObject.tag == "Enemigo" || collision.gameObject.tag == "Entorno")
        {
            Destroy(gameObject);
        }
    }
}
