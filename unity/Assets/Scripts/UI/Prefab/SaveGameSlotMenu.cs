using System;

using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class SaveGameSlotMenu : MonoBehaviour
{
    public Text Title;
    public Text SavedOn;

    private Savegame gameState;
    public Savegame Savegame
    {
        get
        {
            return this.gameState;
        }
        set
        {
            if (this.gameState != value)
            {
                this.gameState = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (this.Savegame != default)
        {
            this.Title.text = String.Format("Planets visited: {0}", this.Savegame.PlanetsVisited);
            this.SavedOn.text = this.Savegame.SavedOn.ToString("G");
        }
        else
        {
            this.Title.text = "";
            this.SavedOn.text = "Empty";
        }
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.Savegame != default)
        {
            this.Title.text = String.Format("Planets visited: {0}", this.Savegame.PlanetsVisited);
            this.SavedOn.text = this.Savegame.SavedOn.ToString("G");
        }
        else
        {
            this.Title.text = "";
            this.SavedOn.text = "Empty";
        }
    }
}
