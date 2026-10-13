using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

// en este ejemplo estamos haciendo un script para crear una nueva ventana del editor
// este script NO se va a agregar a un game object por lo que no necesita ser un MonoBehaviour
public class VentanaSimple : EditorWindow
{
   
    // método para crear ventanita
    [MenuItem("Utilidades/Ejemplo Simple")]
    public static void ShowWindow()
    {
        GetWindow<VentanaSimple>("Ventana Ejemplo");
    }

    // este método se tiene que llamar así
    // es donde vamos a crear toda la GUI (graphical user interface)
    public void CreateGUI()
    {
        // aquí va toda la UI! 

        // no necesitan pero podemos - agregar scrollview
        // si la cantidad de elementos se excede del espacio se muestra un scroll
        ScrollView scrollView = new ScrollView();
        rootVisualElement.Add(scrollView);

        // categoria general
        Label lAgregarSeccion = AgregarSeccion("General");

        // agregamos buttons dummy
        Button bSaludar = AgregarBoton("Saludar");
        bSaludar.clicked += () => Debug.Log("Hola amiguitos!");

        // agregamos botón para probar función
        Button bDummy = AgregarBoton("Dummy");
        bDummy.clicked += FuncionDummy;

        // agregamos otra sección de prueba
        Label lPruebas = AgregarSeccion("Pruebas");

        Button bWarning = AgregarBoton("Warning");
        bWarning.clicked += () => Debug.LogWarning("Esta es una advertencia!");

        Button bError = AgregarBoton("Error");
        bError.clicked += () => Debug.LogError("Este es un error!!!!");

        // agregar elementos a scrollview para que se vean
        // (si no hacemos este paso nunca se van a ver)
        scrollView.Add(lAgregarSeccion);
        scrollView.Add(bSaludar);
        scrollView.Add(bDummy);
        scrollView.Add(lPruebas);
        scrollView.Add(bWarning);
        scrollView.Add(bError);
    }

    private Button AgregarBoton(string texto)
    {
        // creamos objeto 
        Button button = new Button();
        
        // agregamos texto
        button.text = texto;
        
        // cambiamos estilo si queremos
        button.style.marginTop = 2;
        button.style.marginBottom = 2;

        // regresamos objeto creado
        return button;
    }

    private Label AgregarSeccion(string texto)
    {
        // creamos objeto
        Label label = new Label();

        // agregamos texto
        label.text = texto;

        // cambiar estilo
        label.style.unityFontStyleAndWeight = FontStyle.Bold;
        label.style.fontSize = 16;
        label.style.marginTop = 12;
        label.style.marginBottom = 4;
        
        // regresamos objeto creado
        return label;
    }

    private void FuncionDummy()
    {
        Debug.Log("Esta función existe sólo como ejemplo.");
    }
}
