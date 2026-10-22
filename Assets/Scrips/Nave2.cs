using UnityEngine;

public class Nave2 : MonoBehaviour
{
    public float velocidadHorizontal = 10f;
    public Rigidbody2D rigidbody2;

    void Awake()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float direccion = 0f;

        if (Input.GetKey(KeyCode.LeftArrow) )
        {
            direccion = -1f;
        }

        if (Input.GetKey(KeyCode.RightArrow) )
        {
            direccion = 1f;
        }

        // Escena 3: linearVelocity para mover la nave
        rigidbody2.linearVelocity = new Vector2(direccion * velocidadHorizontal, 0f);
    }
}
