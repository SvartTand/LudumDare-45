using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListOfTypes : MonoBehaviour {

    public Text humanText;
    private string humanBaseText;
    private int humanKillCount = 0;

    public Text humanBornText;
    private string humanBornBaseText;
    private int humanBirthCount = 0;

    public Text houseText;
    private string houseBaseText;
    private int housesCount = 0;

    public Text MatterText;
    private string baseMatterText;
    private int matter = 0;

    public Text AnimalText;
    private string baseAnimal;
    private int animal = 0;

    public AudioSource eurika;

    public List<Type> types = new List<Type>();

    public GameObject completedPanel;
    private int count;


    public static int AIR = 0, WATER = 1, BEDROCK = 2, EARTH = 3, STONE = 4, LAVA = 5, STEAM = 6, SAND = 7, CLOUD = 8, LIGHTNING = 9, 
        ALGEE = 10, SOIL = 11, FIRE = 12, GRASS = 13, CACTUS = 14, TREE = 15, ANIMAL = 16, CLAY = 17, ASH = 18, MAN = 19, LEAVES = 20,
        GLASS = 21, BRICKS = 22, METAL = 23, LAVAROCK = 24, BLOOD = 25,BIRD = 26, LIME_STONE = 27, EGG = 28;


    public void Start()
    {
        houseBaseText = houseText.text;
        humanBaseText = humanText.text;
        humanBornBaseText = humanBornText.text;
        baseAnimal = AnimalText.text;
        baseMatterText = MatterText.text;
    }

    public void PlayEurika()
    {
        eurika.Play();
    }

    public void HumanKilled()
    {
        humanKillCount++;
        humanText.text = humanBaseText + " " + humanKillCount; 
    }

    public void HumanBorn()
    {
        humanBirthCount++;
        humanBornText.text = humanBornBaseText + " " + humanBirthCount;
    }

    public void HouseBuilt()
    {
        housesCount++;
        houseText.text = houseBaseText + " " + housesCount;

    }

    public void AddedMatter(int w)
    {
        matter += w;
        MatterText.text = baseMatterText + " " + matter;
    }

    public void AnimalKilled()
    {
        animal++;
        AnimalText.text = baseAnimal + " " + animal;
    }

    public void UpdateTypeList()
    {
        count++;
        if (count >= types.Count - 4)
        {
            completedPanel.active = true;
        }
    }

    public void PanelClick()
    {
        completedPanel.active = false;
    }


}
