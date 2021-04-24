
using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class GameStateInformation : MonoBehaviour
{
    public Text turnText;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        this.turnText.text = Core.GameState.CurrentTurn.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
