using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class app : MonoBehaviour {

    [SerializeField] Text textoUI;


    System.DateTime dataAbertura;
    string textoVar;

    // Start is called before the first frame update
    void Start() {
        dataAbertura = System.DateTime.Now; //.ToString("yyyy-MM-dd h:mm tt");


        //abre a folder do save game
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo() {
            FileName = (Application.persistentDataPath),
            UseShellExecute = true,
            Verb = "open"
        });

        //limpo o arquivo
        File.WriteAllText(Application.persistentDataPath + "/teste.txt", "inicio");

    }



    // Next update in second
    private int nextUpdate = 1;
    private readonly int interval = 1;

    // Update is called once per frame
    void Update() {

        // If the next update is reached
        if (Time.time >= nextUpdate) {

            // Change the next update (current second+1)
            nextUpdate = Mathf.FloorToInt(Time.time) + interval;


            string tempoDeInicioReal = ((int)(System.DateTime.Now - dataAbertura).TotalSeconds).ToString("0");
            textoVar = "intervalo de:" + interval + "segundos, eu ja rodei " + nextUpdate + " vezes. comecei a " + tempoDeInicioReal + "segs em " + dataAbertura.ToString("yyyy-MM-dd h:mm tt");
            //Debug.Log(Time.time + ">=" + nextUpdate);
            Debug.Log(textoVar);
            AtualizaUI(textoVar);
            AtualizaTxt(textoVar);



        }

    }


    void AtualizaUI(string textoVar) {
        textoUI.text = textoVar;
    }

    void AtualizaTxt(string textoVar) {

        textoVar = System.Environment.NewLine + textoVar;

        File.AppendAllText(Application.persistentDataPath + "/teste.txt", textoVar);

    }


}
