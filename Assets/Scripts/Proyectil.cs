using UnityEngine;

public class Proyectil : MonoBehaviour
{

    [SerializeField]
    private float _velocidad = 5.2f;
    // private double _velocidad2 = 5.2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_velocidad * Time.deltaTime, 0, 0);        
    }

    void OnBecameInvisible()
    {
        // Destroy(gameObject);
        ProyectilPool.Instance.Desactivar(gameObject);       
    }
}
