using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public Projectile ProjectilePrefab;
    public BoxCollider2D colider;
    public float speed = 5f;
    void Update()
    {
        MoverNave();
        Atirar();
    }

    private void MoverNave()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        transform.Translate(Time.deltaTime * speed * new Vector2(horizontal, vertical));
    }

    private void Atirar()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(ProjectilePrefab,transform.position,Quaternion.identity);
        }
    }
}
