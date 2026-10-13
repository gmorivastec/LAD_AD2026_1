using UnityEngine;

// scriptable object - definición de un objeto contenedor de información
// usado cuando tenemos entidades que tienen el mismo comportamiento pero diferentes datos

// nos permite hacer definiciones de datos en los assets sin necesidad de hacer un nuevo
// prefab 

[CreateAssetMenu(fileName = "Cartita", menuName = "Scriptable Objects/CartaSO")]
public class CartaSO : ScriptableObject
{
    
    // aquí van los datos que puedes usar 
    public string nombre;
    public int poder;
    public Texture2D imagen;
    public string descripcion;
}
