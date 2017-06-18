using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class playerController : MonoBehaviour {
    public float speed;
    public Text countText;
    public Text winText;

    float x;
    float y;

    private playerController joy_Stick;
	private Rigidbody rb;
    private int count;

    SerialPort seri = new SerialPort("COM3", 9600);
    private void Awake()
    {
        seri.Open();
        StartCoroutine(ReadDataFromSerialPort());
        joy_Stick = GetComponent<playerController>();
    }
    IEnumerator ReadDataFromSerialPort()
    {
        while (true)
        { 
            string[] values = seri.ReadLine().Split(',');
            x = (float.Parse(values[0]));
            y = (float.Parse(values[1]));
            yield return new WaitForSeconds(.015f);
        }
    }
    void Start ()
	{
		rb = GetComponent<Rigidbody> ();
        count = 0;
        SetCountText();
        winText.text = "";
	}

	void FixedUpdate ()//physics code
	{
		Vector3 movement = new Vector3 (y, 0.0f, x);

		rb.AddForce (movement * speed);

	}
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            winText.text = "YOU WIN!";
        }
    }
}
