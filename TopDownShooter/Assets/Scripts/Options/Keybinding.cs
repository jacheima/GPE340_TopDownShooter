using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keybinding : MonoBehaviour
{
    public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public TextMeshProUGUI forward, backward, left, right;

    private GameObject currentKey;

    // Start is called before the first frame update
    void Start()
    {
        keys.Add("Forward", KeyCode.W);
        keys.Add("Backward", KeyCode.S);
        keys.Add("Left", KeyCode.A);
        keys.Add("Right", KeyCode.D);

        forward.text = keys["Forward"].ToString();
        backward.text = keys["Backward"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if(currentKey != null)
        {
            Event e = Event.current;

            if(e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = e.keyCode.ToString();
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
    }
}
