using UnityEngine;

public class Eventos : MonoBehaviour
{
    // para escuchar eventos necesitamos métodos compatibles

    // un evento sin argumentos
    public void OirEventoSinArgumentos()
    {
        print("SUCEDIÓ UN EVENTO SIN ARGUMENTOS");
    }

    // un evento con 2 floats
    public void OirEventoConArgumentos(float x, float y)
    {
        print($"variables: {x}, {y}");
    }
}
