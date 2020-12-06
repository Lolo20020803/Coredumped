using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Player player;
    public GameObject target;
    public Vector3 offset;
    public Image verde;
    public Text diamantes_tx;
    RectTransform rt;
    // Start is called before the first frame update
    void Start()
    {
   
        rt = GetComponent<RectTransform>();
        player = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + offset;
        verde.fillAmount = player.vida / player.vidaStart;
        
    }
    
}
