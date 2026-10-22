using UnityEngine;

public class RebotePelota : MonoBehaviour
{
    public float velocidad = 8f;
    public Transform nave;                                  // arrastra aquí tu nave
    public Vector3 offsetInicial = new Vector3(0f, 0.6f, 0f);

    private Rigidbody2D rb;
    private bool lanzada;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // En rompeladrillos la gravedad debe ser 0

        // Si olvidaste arrastrar la nave en el Inspector, la busca automáticamente
        if (nave == null)
        {
            Nave n = Object.FindAnyObjectByType<Nave>();
            if (n != null) nave = n.transform;
        }
    }

    void Start()
    {
        Reiniciar();
    }

    void Update()
    {
        if (lanzada) return;

        // Antes de lanzar, la pelota sigue a la nave (Escena 1: transform.position)
        if (nave != null)
        {
            transform.position = nave.position + offsetInicial;
        }

        // Se lanza con Espacio (Escena 3: linearVelocity)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Lanzar();
        }
    }

    void FixedUpdate()
    {
        if (!lanzada) return;

        Vector2 v = rb.linearVelocity;

        // Evita que la pelota quede rebotando casi horizontal para siempre
        if (Mathf.Abs(v.y) < 0.3f)
            v.y = (v.y >= 0f ? 1f : -1f) * 0.3f;

        // Mantiene la velocidad constante (Escena 3: linearVelocity)
        rb.linearVelocity = v.normalized * velocidad;
    }

    void Lanzar()
    {
        lanzada = true;
        Vector2 direccion = new Vector2(Random.Range(-0.5f, 0.5f), 1f).normalized;
        rb.linearVelocity = direccion * velocidad;
    }

    public void Reiniciar()
    {
        lanzada = false;
        rb.linearVelocity = Vector2.zero;
        if (nave != null)
        {
            transform.position = nave.position + offsetInicial;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reto Final: Colisiones y rebotes
        if (collision.gameObject.CompareTag("Nave") || collision.gameObject.GetComponent<Nave>() != null)
        {
            // Según dónde golpee en la nave, cambia el ángulo (-1 izquierda ... 1 derecha)
            float ancho = collision.collider.bounds.size.x;
            float factor = (transform.position.x - collision.transform.position.x) / ancho * 2f;
            Vector2 direccion = new Vector2(factor, 1f).normalized;
            rb.linearVelocity = direccion * velocidad;
        }
        else if (collision.gameObject.CompareTag("Ladrillo") || collision.gameObject.name.Contains("Ladrillo") || collision.gameObject.name.Contains("Brick"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Suelo") || collision.gameObject.name.Contains("Suelo"))
        {
            Debug.Log("La pelota cayó al suelo.");
            Reiniciar();
        }
    }
}