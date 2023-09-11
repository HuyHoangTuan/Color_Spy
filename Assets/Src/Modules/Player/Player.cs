using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 0.0f;
    [SerializeField] private float minSpeed = 0.0f;
    [SerializeField] private float acceleration = 0.0f;
    [SerializeField] private float speed = 0.0f;

    private Vector2 _input = Vector2.zero;
    // Start is called before the first frame update
    protected void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        this._ProcessMove();
    }

    protected void OnMove(InputValue inputValue)
    {
        this._input = inputValue.Get<Vector2>();
    }

    private void _ProcessMove()
    {
        void Rotate(Vector3 direction)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.15f);
        }
        
        void Move(Vector3 delta)
        {
            this.transform.Translate(delta, Space.World);
        }
        
        if (this._input != Vector2.zero)
        {
            this.speed = this.speed + this.acceleration * Time.deltaTime;
            this.speed = Mathf.Clamp(this.speed, this.minSpeed, this.maxSpeed);
            
            Vector3 direction = new Vector3(this._input.x, 0.0f, this._input.y);
            
            Rotate(direction);

            Move(direction * this.speed * Time.deltaTime);
        }
    }

    protected void OnTriggerEnter(Collider other)
    {
        // print("ENTER");
    }
    
    protected void OnTriggerStay(Collider other)
    {
        // print("STAY");
    }
    
    protected void OnTriggerExit(Collider other)
    {
        // print("Exit");
    }

   
}
