using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool faciingLeft = true;
    public float moveSpeed = 5f;
    public Transform checkPoint;
    public float distance = 1f;
    public LayerMask groundLayer;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);

        RaycastHit2D hit = Physics2D.Raycast(checkPoint.position, Vector2.down, distance, groundLayer);
        
        if (hit == false && faciingLeft)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            faciingLeft = false;
        }
        else if (hit == false && !faciingLeft)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            faciingLeft = true;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        if (checkPoint == null)
            return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(checkPoint.position, checkPoint.position + Vector3.down * distance);
    }
}
