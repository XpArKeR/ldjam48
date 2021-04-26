using System;

using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class SaveGameSlotMenu : MonoBehaviour
{
    public Text Title;
    public Text SavedOn;

    private GameState gameState;
    public GameState GameState
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

    }

    private void FixedUpdate()
    {
        if (this.GameState != default)
        {
            this.Title.text = String.Format("Planets visited: {0}", this.GameState.PlanetsVisited);
            this.SavedOn.text = this.GameState.SavedOn.ToString("G");
        }
        else
        {
            this.Title.text = "";
            this.SavedOn.text = "Empty";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
