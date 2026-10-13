using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

/*
    Algunas ideas para uso:
    - Debuggear comportamiento extraño a baja velocidad
    - Colocar al jugador en puntos específicos de un nivel
    - Cambios de status de jugador (buff, debuff)
    - God mode (hacerlo inmortal)
*/
public class PruebasVelocidad : EditorWindow
{
    [MenuItem("Utilidades/Control de velocidad")]
    public static void ShowWindow()
    {
        GetWindow<PruebasVelocidad>("Control de velocidad");
    }

    public void CreateGUI()
    {
        Label lTitulo = AgregarSeccion("Control de velocidad");

        Button b01 = AgregarBoton("0.1x");
        b01.clicked += () => Time.timeScale = 0.1f;

        Button b05 = AgregarBoton("0.5x");
        b05.clicked += () => Time.timeScale = 0.5f;

        Button b10 = AgregarBoton("1.0x");
        b10.clicked += () => Time.timeScale = 1.0f;

        Button b20 = AgregarBoton("2.0x");
        b20.clicked += () => Time.timeScale = 2.0f;

        Button b50 = AgregarBoton("5.0x");
        b50.clicked += () => Time.timeScale = 5.0f;

        Button bPausaPlay = AgregarBoton("Pausa / Play");
        bPausaPlay.clicked += () => Time.timeScale = Time.timeScale == 0f ?  1.0f :  0;

        rootVisualElement.Add(lTitulo);
        rootVisualElement.Add(b01);
        rootVisualElement.Add(b05);
        rootVisualElement.Add(b10);
        rootVisualElement.Add(b20);
        rootVisualElement.Add(b50);
        rootVisualElement.Add(bPausaPlay);
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
