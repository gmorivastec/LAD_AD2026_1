// namespaces
// colecciones de código pre-hecho que podemos utilizar 
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{

    // EVENTOS DE UNITY 
    // mecanismo por medio del cual podemos "avisar" que algo sucedió
    // a otras entidades que estén suscritas

    // objetivo: evitar que nuestras clases estén fuertemente ligadas

    // cómo declarar un evento sin argumentos
    [SerializeField]
    private UnityEvent _eventoSinArgs;

    // cómo declarar un evento con argumentos
    // paso 1 - declarar una clase con los argumentos que necesitamos
    [System.Serializable]
    public class HuboDisparoEvent : UnityEvent<float, float> {}

    // paso 2 - declarar una variable de la clase que acabo de declarar
    [SerializeField]
    private HuboDisparoEvent _huboDisparo;


    // paso 1 de input
    // crear un objeto de la clase que se generó
    private InputSystem_Actions inputActions;

    // variables de objeto
    [SerializeField]
    private float _velocidad = 5;

    [SerializeField]
    private GameObject _proyectilOriginal;

    // agregar métodos de ciclo de vida
    // ciclo de vida?!
    // métodos / eventos que suceden en momentos
    // específicos de la vida de un script
    void Awake()
    {
        // 1er método en ser invocado
        // al crear un componente
        // - corre antes que start
        // - se invoca sin importar si el componente
        // está habilitado o no 

        // inicializar el objeto de input
        inputActions = new InputSystem_Actions();
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // capturar entrada
        // 2 opciones con el nuevo sistema de entrada
        // 1. polling - sondeo
        // le preguntamos a la entrada qué valor tiene
        // o si fue detonada
        // 2. callbacks - suscripción
        // agregar lógica que se invocara al momento
        // que una entrada suceda / cambie

        // capturar el movimiento
        // en entrada el rango está normalizado [-1, 1]
        Vector2 movimiento = inputActions.Player.Move.ReadValue<Vector2>();

        // Time.deltaTime?!?!?!?!
        // Time.deltaTime - la cantidad de tiempo que pasó
        // entre el frame anterior y el actual
        transform.Translate(
            movimiento * Time.deltaTime * _velocidad
        );

        // Instantiate?
        if(inputActions.Player.Jump.triggered)
        {
            print("PEW PEW");
            /*
            Instantiate(
                _proyectilOriginal,
                transform.position,
                transform.rotation
            );
            */

            // gracias a que es un singleton
            // puedo accederlo por medio de .Instance
            ProyectilPool.Instance.Activar(
                transform.position, 
                transform.rotation
            );

            // LO NUEVO CON EVENTOS:
            // detonar eventos 
            // "avisar"

            _eventoSinArgs.Invoke();
            _huboDisparo.Invoke(transform.position.x, transform.position.y);
        }
    }
}
