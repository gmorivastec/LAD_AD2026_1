using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.SceneManagement;

public class CambiadorEscena : EditorWindow
{

    [MenuItem("Utilidades/Cambiador de Escenas")]
    public static void ShowWindow()
    {
        GetWindow<CambiadorEscena>("Cambiador de Escenas");
    }

    public void CreateGUI()
    {
        Label lEnEditor = AgregarSeccion("Cambios de escena en editor");

        Button bEscena1Ed = AgregarBoton("Escena 1");
        bEscena1Ed.clicked += () => CambiarEscenaEditor("Assets/Scenes/Capsula.unity");

        Button bEscena2Ed = AgregarBoton("Escena 2");
        bEscena2Ed.clicked += () => CambiarEscenaEditor("Assets/Scenes/SampleScene.unity");

        Label lEnEjecucion = AgregarSeccion("Cambios de escena en ejecución");

        Button bEscena1Ej = AgregarBoton("Escena 1");
        bEscena1Ej.clicked += () => SceneManager.LoadScene(0);
        
        Button bEscena2Ej = AgregarBoton("Escena 2");
        bEscena2Ej.clicked += () => SceneManager.LoadScene(1);

        ScrollView scrollView = new ScrollView();
        rootVisualElement.Add(scrollView);

        scrollView.Add(lEnEditor);
        scrollView.Add(bEscena1Ed);
        scrollView.Add(bEscena2Ed);
        scrollView.Add(lEnEjecucion);
        scrollView.Add(bEscena1Ej);
        scrollView.Add(bEscena2Ej);
    }

    public void CambiarEscenaEditor(string path)
    {
        if(EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(path);
        }
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
    
}
