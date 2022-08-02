using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class LevelManagerPrototype1 : MonoBehaviour
{
    public SoulSpawning soulSpawn;
    public int soulLimit;


    public bool allowShiftingSouls;
    public bool allowStillSouls;
    public bool allowProjectedSouls;
    public bool allowSoulSwap;

    private void Start()
    {
        if (!allowShiftingSouls)
        {
            soulSpawn.spawnShiftingSoul = KeyCode.None;
        }

        if (!allowStillSouls)
        {
            soulSpawn.spawnStillSoul = KeyCode.None;
        }

        if(!allowProjectedSouls)
        {
            soulSpawn.projectSoulHold = KeyCode.None;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(soulSpawn.souls.Count > soulLimit)
        {
            SceneManager.LoadScene("PrototypeLevel1");
        }
    }
}
