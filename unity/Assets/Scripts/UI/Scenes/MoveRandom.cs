
using UnityEngine;
using UnityEngine.UI;

public class MoveRandom : MonoBehaviour
{
    private bool move = false;
    private float speed = 30f;
    private float wobble;
    private float spinnUpDefaultValue = 1.7f;
    private float spinnUp;
    private Vector3 scaleChange;
    public Image particles;

    private void Start()
    {
        speed = Screen.width / 3;
        wobble = speed / 10f;
        scaleChange = new Vector3(0.15f, 0.15f, 0);

        if (particles != null)
        {
            particles.gameObject.SetActive(false);
        }
    }

    public void StartMoving()
    {
        move = true;
        spinnUp = spinnUpDefaultValue;
    }

    void Update()
    {
        if (move)
        {
            if (spinnUp > 0)
            {
                spinnUp -= Time.deltaTime;
                Vector3 translation = Wobble();
                transform.Translate(translation);
            }
            else
            {
                Vector3 translation = GetRandomDirection();
                transform.Translate(translation);
                transform.localScale -= scaleChange * Time.deltaTime;
                if (particles != null)
                {
                    particles.gameObject.SetActive(true);
                }
            }
        }
    }

    private Vector3 Wobble()
    {
        float x = UnityEngine.Random.Range(-wobble, wobble);
        float y = UnityEngine.Random.Range(-wobble, wobble);
        return new Vector3(x * Time.deltaTime, y * Time.deltaTime, 0);
    }

    private Vector3 GetRandomDirection()
    {
        float x = UnityEngine.Random.Range(-speed, 3 * speed);
        float y = UnityEngine.Random.Range(-speed, speed);
        return new Vector3(x * Time.deltaTime, y * Time.deltaTime, 0);
    }
}
