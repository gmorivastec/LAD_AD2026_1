using UnityEngine;
using System.Collections.Generic;

public class ProyectilPool : MonoBehaviour
{
    // singleton

    // mecanismo para evitar crear más de 2 veces un tipo de objeto
    // ventajas:
    // - acceso rápido a objeto
    // - evita redundancia (si no es necesaria)

    // requisitos de singleton:
    // - instancia estática
    // - mecanismo que evita la creación de otras instancias

    public static ProyectilPool Instance
    {
        get;
        private set;
    }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Pool
    // 1. un lugar donde almacenar las instancias
    
    // queue - cola / fila
    // (como la del banco, la de la cafetería, etc)
    // es una estructura de datos (un lugar para guardar información)
    // FIFO - first in, first out
    private Queue<GameObject> _pool;

    [SerializeField]
    private GameObject _proyectilOriginal;

    [SerializeField]
    private int _poolSize = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // inicializamos pool
        _pool = new Queue<GameObject>();

        // ciclo para crear los proyectiles y agregarlos a la fila
        for(int i = 0; i < _poolSize; i++)
        {
            // creo un nuevo objeto
            GameObject nuevo = Instantiate(_proyectilOriginal);

            // agrego a pool
            _pool.Enqueue(nuevo);

            // deshabilito
            nuevo.SetActive(false);
        }

    }

    public void Activar(Vector3 posicion, Quaternion rotacion)
    {
        // si no hay objetos disponibles no activamos nada
        if(_pool.Count == 0)
            return;

        // sacar objeto de queue / fila 
        GameObject siguiente = _pool.Dequeue();

        // colocamos en posicion
        siguiente.transform.position = posicion;
        siguiente.transform.rotation = rotacion;

        // activamos
        siguiente.SetActive(true);
    }

    public void Desactivar(GameObject proyectil)
    {
        // agregamos a cola
        _pool.Enqueue(proyectil);

        // desactivamos
        proyectil.SetActive(false);
    }


}
