using UnityEngine;
using System.Collections;
public class InventorySummon : MonoBehaviour
{
    [SerializeField] private GameObject _bag;
    [SerializeField] private float DestroyDelay = 2f;
    [SerializeField] private float SpawnDistanceX;
    [SerializeField] private float SpawnDistanceY;

    private GameObject _bagClone;
    private Animator _bagAnim;

    private bool _bagSpawned = false;
    private bool isBagClone;

    private Vector3 _spawnPosition;

    void DelayForDestoy()
    {
        Destroy(_bagClone);
        _bagSpawned = false;
    }

    private void Update()
    {
        _spawnPosition.x = transform.position.x + SpawnDistanceX;
        _spawnPosition.y = transform.position.y - SpawnDistanceY;

        if (Input.GetKeyDown(KeyCode.I) && _bagSpawned == false)
        {

            _bagClone = Instantiate(_bag,_spawnPosition, _bag.transform.rotation);
            _bagAnim = _bagClone.GetComponent<Animator>();
            _bagSpawned = true;
        }
        if (Input.GetKey(KeyCode.E) && _bagSpawned == true && isBagClone == true)
        {
            _bagAnim.SetBool("isClosing", true);
            Invoke("DelayForDestoy", DestroyDelay);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bag")
        {
            _bagSpawned = true;
            isBagClone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "bag")
            isBagClone = false;
    }

}
