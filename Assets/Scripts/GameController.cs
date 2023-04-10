using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int maxPlanes = 10;
    public int planesDestroyed = 0;
    public int totalEggs = 0;
    public bool mouseControl = true;
    public Text canvasObject = null; 

    private int numberOfPlanes = 0;
    // Start is called before the first frame update
    void Start()
    {
        canvasObject = gameObject.GetComponent<Text>();            
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfPlanes < maxPlanes)
        {
            CameraSupport s = Camera.main.GetComponent<CameraSupport>();
            Assert.IsTrue(s != null);

            GameObject e = Instantiate(Resources.Load("Prefabs/Enemy") as GameObject);
            Vector3 pos;
            //               size           *  random(0-1)  * 80%  +    minimum value        +       10% of size
            pos.x = s.GetWorldBound().size.x * Random.value * 0.8f + s.GetWorldBound().min.x + (s.GetWorldBound().size.x * 0.1f);
            pos.y = s.GetWorldBound().size.y * Random.value * 0.8f + s.GetWorldBound().min.y + (s.GetWorldBound().size.y * 0.1f);
            
            pos.z = 0;
            e.transform.localPosition = pos;
            ++numberOfPlanes;
        }

        //canvasObject.text = "Control Mode: " + mouseControl;

        //Transform textTr = canvasObject.transform.Find("Control");
        //Text text = textTr.GetComponent<Text>();







    }

    public void EnemyDestroyed()
    {
        Debug.Log("Enemy Destroyed");
        numberOfPlanes--;
        planesDestroyed++;
    }
}