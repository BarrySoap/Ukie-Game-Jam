using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMaker : MonoBehaviour
{
    public float gridScale = 0.5f;
    public Dictionary<Color32, Transform> relations = new Dictionary<Color32, Transform>();
    public Texture2D world;
    public Transform player;
    public Transform thornss;
    public Transform thornsl;
    public Transform cactuss;
    public Transform cactusl;
    public Transform ant;
    public Transform mole;
    public Transform bird;
    public Transform cat;
    public Transform end;
    private Color32 spawn = new Color32(0, 255, 255, 255);

    // Upon starting create the world
    void Start()
    {
        // Thorn(s) colour
        Color32 key = new Color32(0, 127, 14, 255);
        relations.Add(key, thornss);
        // Thorn(l) colour
        key = new Color32(0, 91, 9, 255);
        relations.Add(key, thornsl);
        // Cactus (s) colour
        key = new Color32(0, 198, 19, 255);
        relations.Add(key, cactuss);
        // Cactus(l) colour
        key = new Color32(0, 211, 21, 255);
        relations.Add(key, cactusl);
        // Ant colour
        key = new Color32(226, 93, 56, 255);
        relations.Add(key, ant);
        // Mole colour
        key = new Color32(140, 92, 44, 255);
        relations.Add(key, mole);
        // Bird colour
        key = new Color32(132, 165, 165, 255);
        relations.Add(key, bird);
        // Cat colour
        key = new Color32(255, 131, 0, 255);
        relations.Add(key, cat);
        // end colour
        key = new Color32(124, 0, 116, 255);
        relations.Add(key, end);
        // End

        MakeWorld();
    }
    // Function for making the world
    private void MakeWorld()
    {
        Color32 mapPixel;
        // Go through pixel by pixel and use their colours to populate the world
        for (int x = 0; x < world.width; ++x)
        {
            for (int y = 0; y < world.height; ++y)
            {
                // Get a pixel from the world map to be tested
                mapPixel = world.GetPixel(x, y);
                FindColour(x, y, mapPixel);
            }
        }
    }
    // Spawn in a prefab
    private void SpawnEntity(int x, int y, Transform t)
    {
        Instantiate(t, new Vector3(x * gridScale, y * gridScale, 0), Quaternion.identity);
    }
    // Function to choose the prefab type to make
    private void FindColour(int x, int y, Color32 pixel)
    {
        if (pixel.Equals(spawn))
        {
            player.position = new Vector3(x * gridScale, (y + 1) * gridScale, 0);
        }
        else
        {
            if (relations.ContainsKey(pixel))
            {
                Transform make = relations[pixel];
                SpawnEntity(x, y, make);
            }
        }
    }
}
