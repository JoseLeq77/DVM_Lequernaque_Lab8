using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinID { get; private set; }
    private static int nextID = 0;

    [Header("Read Only Inspector Info")]
    [SerializeField] private int InspectorCoinID;

    private Vector3 AngleRotations = new Vector3(0, 90, 0);

    private void Start() 
    {
        SetUpCoin();
    }

    private void Update()
    {
        UpdateInspectorInfo();
        QuaternionRotation();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            GameManager.Instance.GainCoin();
        }
    }

    private void QuaternionRotation()
    {
        transform.Rotate(AngleRotations * Time.deltaTime, Space.World);
    }

    private void SetUpCoin()
    {
        coinID = nextID;
        nextID++;
    
        if (GameManager.Instance != null && !GameManager.Instance.coinsInScene.Contains(this))
        {
            GameManager.Instance.coinsInScene.Add(this);
            Debug.Log($"Coin {coinID} added to GameManager.");
        }
    }

    private void UpdateInspectorInfo()
    {
        InspectorCoinID = coinID;
    }
}
