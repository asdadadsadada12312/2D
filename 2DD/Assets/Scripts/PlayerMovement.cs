using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 

    private Rigidbody2D rb2d;

    public Joystick joystick;

    [SerializeField] private InventoryUI inventoryUI;
    private Inventory inventory;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        inventory = new Inventory(UseItem);
        inventoryUI.SetInventory(inventory);
    }
    private void UseItem(Item item)
    {

    }
    void FixedUpdate()
    {
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;
       
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
  
        movement.Normalize();

        rb2d.velocity = movement * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld itemWorld = collision.gameObject.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
            Debug.Log("Item has been picked up!");
        }
 
    }
}