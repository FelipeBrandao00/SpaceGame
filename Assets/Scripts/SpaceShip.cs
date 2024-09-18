using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public Projectile ProjectilePrefab;
    public float speed = 5f;
    private SpriteRenderer _spriteRenderer;
    private Bounds _CameraBounds;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        var height = Camera.main.orthographicSize * 2;
        var width = height * Camera.main.aspect;

        _CameraBounds = new Bounds(Vector3.zero,new Vector3(width,height));
    }
    void Update()
    {
        MoverNave();
        Atirar();
    }

    private void LateUpdate()
    {
        var novaPosicao = transform.position;

        var spriteWidht = _spriteRenderer.sprite.bounds.extents.x;
        var spriteHeight = _spriteRenderer.sprite.bounds.extents.y;

        novaPosicao.x = Mathf.Clamp(novaPosicao.x, _CameraBounds.min.x + spriteWidht, _CameraBounds.max.x - spriteWidht);
        novaPosicao.y = Mathf.Clamp(novaPosicao.y, _CameraBounds.min.y + spriteHeight, _CameraBounds.max.y - spriteHeight);

        transform.position = novaPosicao;

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
