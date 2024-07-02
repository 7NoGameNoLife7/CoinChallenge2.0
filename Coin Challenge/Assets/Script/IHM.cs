using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IHM : MonoBehaviour
{
    public List<Transform> LifePanelTransform;
    public static IHM Instance;
    public GameObject[] lifes = new GameObject[3];
    [SerializeField] TextMeshProUGUI score;
    private int i;
    private int value;


    private void Awake()
    {
        Instance = this;
    }

    public void UpdateLife()
    {
        
        foreach (Transform child in LifePanelTransform)
        {
            child.gameObject.SetActive(false);
        }
        for (int i = 0; i < InfosPlayer.Instance.life; i++)
        {
            LifePanelTransform[i].gameObject.SetActive(true);

        }
    }
    public void UpdateScore()
    {
        score.text = "score" + InfosPlayer.Instance.score;
    }
}
