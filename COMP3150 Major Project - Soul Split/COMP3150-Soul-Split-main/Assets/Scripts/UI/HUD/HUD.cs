using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class HUD : MonoBehaviour
{
    public Sprite faceNull;
    public Sprite face;
    public GameObject MaskPrefab;
    public LevelManager SceneManagerScript;
    public Text timeText;

    private List<GameObject> souls = new List<GameObject>();
    private int soulLimit;
    private int remainingSouls;
    private SoulSpawning player;
    private float timer;


    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {
        timer = 0;
        soulLimit = SceneManagerScript.soulLimit;
        remainingSouls = soulLimit;
        player = SceneManagerScript.player;
        float gap = 520f / soulLimit;
        for (int i = 0; i < soulLimit; i++)
        {
            GameObject mask = Instantiate(MaskPrefab, GameObject.Find("Bar").transform, false);
            souls.Add(mask);
            mask.transform.Translate(i*gap, 0, 0);
            mask.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSouls();
        timer += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(timer);
        timeText.text = time.ToString(@"mm\:ss\:ff");
    }

    void UpdateSouls()
    {
        remainingSouls = soulLimit - player.souls.Count;
        for (int i = 0; i < soulLimit; i++)
        {
            if (i < remainingSouls)
            {
                souls[i].GetComponent<Image>().sprite = face;
            }
            else
            {
                souls[i].GetComponent<Image>().sprite = faceNull;
            }
        }
    }
}
