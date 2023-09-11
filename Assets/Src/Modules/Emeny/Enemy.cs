using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 0.0f;
    
    // Start is called before the first frame update
    protected void Start()
    {
        float x = Random.Range(-10.0f, 10.0f);
        float z = Random.Range(-10.0f, 10.0f);

        this.transform.position = new Vector3(x, 0, z);
    }

    // Update is called once per frame
    protected void Update()
    {
        this._ProcessMove();
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
        
        float x = Random.Range(-1.0f, 1.0f);
        float y = Random.Range(-1.0f, 1.0f);
        
        Vector3 direction = new Vector3(x, 0.0f, y);
        
        Rotate(direction);
        
        Move(this.speed * direction * Time.deltaTime);
    }
    
    protected void OnTriggerEnter(Collider other)
    {
        Utility.log("ENEMY", "ENTER");
    }
    
    protected void OnTriggerStay(Collider other)
    {
        Utility.log("ENEMY", "STAY");
    }
    
    protected void OnTriggerExit(Collider other)
    {
        Utility.log("ENEMY", "EXIT");
    }
}
