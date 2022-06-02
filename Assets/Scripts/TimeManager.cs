using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeManager : MonoBehaviour
{
    public Text txt_time;
    public Text txt_timeFloored;
    public Text txt_min;
    public Text txt_segs;
    public GameObject txt_perdiste;
    public float TimeToDoSomething;
    public float timeToWait;

    public float elapsedTime; //este no deberia ser publico pero Jero lo puso aca.

    public bool isCounting;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0;
        isCounting = false;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;

        txt_time.text = currentTime.ToString();

        txt_timeFloored.text = Mathf.Floor(currentTime).ToString();
        //Con esto se logra realizar un cronometro.
       // txt_min.text = Mathf.Floor(((currentTime + 100) / 60)).ToString(); sacamos los minutos que van
        int minutos = Mathf.FloorToInt(((currentTime) / 60));
        txt_min.text = minutos.ToString();

        txt_segs.text = Mathf.Floor(currentTime % 60).ToString();

        if(isCounting)
        {
            elapsedTime += Time.deltaTime;
        }
        if(currentTime > 3)
        {
            txt_perdiste.SetActive(true);
        }
        if(currentTime > TimeToDoSomething)
        {
            TimeToDoSomething += timeToWait;
            txt_perdiste.GetComponent <Text>().text = "Cambiare en " + TimeToDoSomething.ToString();
        }
    }
}
