using UnityEngine;

public class Health : MonoBehaviour
{
    public int healthID { get; private set; }
    private static int nextID = 0;

    [SerializeField] private int lifeRecover;

    [Header("Read Only Inspector Info")]
    [SerializeField] private int InspectorHealthID;

    private void Start()
    {
        SetUpHealth();
    }

    private void Update()
    {
        UpdateInspectorInfo();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            GameManager.Instance.ModifyLife(lifeRecover);
        }
    }

    private void SetUpHealth()
    {
        healthID = nextID;
        nextID++;

        if (GameManager.Instance != null && !GameManager.Instance.healthInScene.Contains(this))
        {
            GameManager.Instance.healthInScene.Add(this);
            Debug.Log($"Health {healthID} added to GameManager.");
        }
    }

    private void UpdateInspectorInfo()
    {
        InspectorHealthID = healthID;
    }
}
