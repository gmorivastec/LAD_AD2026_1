using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Carta : MonoBehaviour
{
    [Header("Fuente de datos")]
    [SerializeField]
    private CartaSO _datos;
    
    [Header("Elementos de GUI")]
    [SerializeField]
    private Image _imagen; 

    [SerializeField]
    private TMP_Text _nombre;

    [SerializeField]
    private TMP_Text _poder;

    [SerializeField]
    private TMP_Text _descripcion;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // asignar textos a elementos de UI
        _nombre.text = _datos.nombre;
        _poder.text = _datos.poder + "";
        _descripcion.text = _datos.descripcion;

        // crear sprite
        Sprite nuevoSprite = Sprite.Create(
            _datos.imagen,
            new Rect(0, 0, _datos.imagen.width, _datos.imagen.height),
            new Vector2(0.5f, 0.5f)
        );

        // asignar sprite
        _imagen.sprite = nuevoSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
