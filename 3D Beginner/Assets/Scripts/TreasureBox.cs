using UnityEngine;
using UnityEngine.UI;

public class TreasureBox : MonoBehaviour
{
    private GameObject Background;
    private void OnTriggerEnter(Collider other)
    {
        Background = GameObject.Find("Background");
        GameObject.Find("Content").GetComponent<Text>().text = "按E开启宝箱";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
