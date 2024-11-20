using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeftPlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    private SpriteRenderer rabbit;
    private int point = 0;
    public float horizontalMove = 0f;

    public Joystick joystick;

    public TextMeshProUGUI textMeshProUGUI;

    private Rigidbody2D rb;

    private int numOfCarrot = 0;

    public SpriteRenderer[] carrot = new SpriteRenderer[6];
    public SpriteRenderer[] heart = new SpriteRenderer[3];

    private int numOfHearts = 3;

    public SpriteRenderer explosion;
    private Animator explosionAnim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rabbit = GetComponent<SpriteRenderer>();
        explosionAnim = explosion.GetComponent<Animator>();
    }
    void Update()
    {
        if (joystick.Horizontal > 0.1f)
        {
            horizontalMove = moveSpeed;
        }
        else if (joystick.Horizontal < -0.1f)
        {
            horizontalMove = -moveSpeed;
        }
        else
        {
            horizontalMove = 0;
        }
        Vector2 movement = new Vector2(horizontalMove, 0);

        rb.velocity = movement;
        
        point = int.Parse(textMeshProUGUI.text);
        switch (numOfCarrot)
        {
            case 0:
                foreach (SpriteRenderer carrots in carrot)
                {
                    carrots.enabled = false;
                }
                break;
            case 1:
                carrot[0].enabled = true;
                break;
            case 2:
                carrot[1].enabled = true;
                break;
            case 3:
                carrot[2].enabled = true;
                break;
            case 4:
                carrot[3].enabled = true;
                break;
            case 5:
                carrot[4].enabled = true;
                break;
            case 6:
                carrot[5].enabled = true;
                break;
            default:
                break;
        }

        if (heart[0].enabled == false)
        {
            numOfHearts = 2;
        }
        if (heart[1].enabled == false)
        {
            numOfHearts = 1;
        }
        if (heart[2].enabled == false)
        {
            numOfHearts = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Carrot")
        {
            point++;
            numOfCarrot++;
            textMeshProUGUI.text = point.ToString();
        }
        if (collision.gameObject.name == "Bomb(Clone)")
        {
            explosionAnim.SetTrigger("Boom");
            // point -= numOfCarrot;
            numOfHearts--;
            switch (numOfHearts)
            {
                case 0:
                    heart[2].enabled = false;
                    ButtonManager.Instance.SetCoins(point);
                    ButtonManager.Instance.SetScore(point);

                    SceneManager.LoadScene("Lose");
                    break;
                case 1:
                    heart[1].enabled = false; break;
                case 2:
                    heart[0].enabled = false; break;
                default: break;
            }
            numOfCarrot = 0;
            textMeshProUGUI.text = point.ToString();
        }
        ButtonManager.Instance.SetStars(numOfHearts);

    }
}