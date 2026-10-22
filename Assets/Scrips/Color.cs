using UnityEngine;
using UColor = UnityEngine.Color;

public class Color : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [Header("Colores disponibles al chocar")]
    public UColor[] colores = new UColor[]
    {
        UColor.red,
        UColor.yellow,
        UColor.green,
        UColor.cyan,
        UColor.magenta,
        UColor.white
    };

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Reto Final: Se ejecuta automáticamente cada vez que la pelota choca con algo
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (spriteRenderer == null) return;

        // Elige un color aleatorio de la lista
        if (colores != null && colores.Length > 0)
        {
            int indice = Random.Range(0, colores.Length);
            spriteRenderer.color = colores[indice];
        }
        else
        {
            // O genera un color completamente al azar
            spriteRenderer.color = Random.ColorHSV();
        }
    }
}