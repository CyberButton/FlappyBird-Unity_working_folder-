using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;              // 3 dimensional vector to represent direction
    private float rotationSpeed = 5f;      // to rotate the bird
    private SpriteRenderer sRender;         // for animation
    private int currSpriteIndex;
    [SerializeField]private AudioSource wingFlap;
    [SerializeField]private AudioSource hitPipe;
    [SerializeField]private AudioSource addScore;

    // public variables are availabe for customization in the editor
    public float gravity = -10f;           
    public float strength = 5f;
    public Sprite[] sprites;    

    // called before Strat() and called only once in the lifetime of a script, when the script is first loaded
    private void Awake() {
        sRender = GetComponent<SpriteRenderer>();
    } 

    //reset y-pos after each death
    private void OnEnable() {
        Vector3 resetPos = transform.position;
        resetPos.y = 0;
        transform.position = resetPos;
        direction = Vector3.zero;
    }

    // called before the first frame
    private void Start() {
        //repeatedly calls "AnimateBird" after 0.15s, with delay before the first call
        InvokeRepeating(nameof(AnimateBird), 0.1f, 0.17f);
    }

    // updates each frame
    private void Update() { 
        //if "Space" key is pressed
        if(Input.GetKeyDown(KeyCode.Space)) { 
            wingFlap.Play();  
            direction = Vector3.up * strength;
        }

        //apply gravity at each unit of time ( ignores frame-rate )
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * rotationSpeed;
        transform.eulerAngles = rotation;
    }

    //flying bird animation
    private void AnimateBird() {
        currSpriteIndex++;

        //loop back
        if(currSpriteIndex == sprites.Length) {
            currSpriteIndex = 0;
        }
        //update sprites
        sRender.sprite = sprites[currSpriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Pipe") {
            hitPipe.Play();
            FindObjectOfType<GameManager>().HitObstacle();
        } else if(other.gameObject.tag == "Score") {
            addScore.Play();
            FindObjectOfType<GameManager>().IncrementScore();
        }
    }
}
