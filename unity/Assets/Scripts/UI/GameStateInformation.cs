
using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class GameStateInformation : MonoBehaviour
{
    public Text turnText;
    public Text shipTypeText;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        this.turnText.text = Core.GameState.CurrentTurn.ToString();
        this.shipTypeText.text = Core.GameState.Ship.TypeName;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
