using UnityEngine;

public class PorteriaMovil : MonoBehaviour
{
    [Header("Escena 1: Movimiento cinemático con Transform")]
    public float velocidad = 2.5f;
    public float distanciaMovimiento = 2.5f;
    public bool moverEnEjeY = true; // Si es true se mueve arriba/abajo, si es false izq/der

    private Vector3 posicionInicial;
    private int direccion = 1;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        // ESCENA 1: Usamos transform.Translate para mover el arco/portero de forma cinemática
        Vector3 desplazamiento = (moverEnEjeY ? Vector3.up : Vector3.right) * (direccion * velocidad * Time.deltaTime);
        transform.Translate(desplazamiento);

        // Control de límites para cambiar el sentido de movimiento
        float distanciaActual = moverEnEjeY 
            ? Mathf.Abs(transform.position.y - posicionInicial.y) 
            : Mathf.Abs(transform.position.x - posicionInicial.x);

        if (distanciaActual >= distanciaMovimiento)
        {
            direccion *= -1; // Invierte el sentido
        }
    }
}
