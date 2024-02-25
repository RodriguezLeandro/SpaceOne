using UnityEngine;

public class chargingSkillScript : MonoBehaviour
{

    public float chargeDuration = 3f;
    public float endDuration = 4f;

    private float chargeTimer = 0f;
    private BoxCollider2D[] skillEffectsBoxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        disableBoxColliders();
    }

    // Update is called once per frame
    void Update()
    {
        // Increment the charge timer
        chargeTimer += Time.deltaTime;

        if (chargeTimer < chargeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, chargeTimer / chargeDuration / 4);
            Color color = gameObject.GetComponent<SpriteRenderer>().material.color;
            color.a = alpha;
            gameObject.GetComponent<SpriteRenderer>().material.color = color;
        }

        if (chargeTimer > chargeDuration)
        {
            Color color = gameObject.GetComponent<SpriteRenderer>().material.color;
            color.a = 1f;
            gameObject.GetComponent<SpriteRenderer>().material.color = color;
            enableBoxColliders();
        }

        if (chargeTimer > endDuration)
        {
            Color color = gameObject.GetComponent<SpriteRenderer>().material.color;
            color.a = 0f;
            gameObject.GetComponent<SpriteRenderer>().material.color = color;
            chargeTimer = 0f;
            disableBoxColliders();
            gameObject.SetActive(false);
        }
    }

    private void disableBoxColliders() 
    {
        skillEffectsBoxCollider2D = GetComponentsInChildren<BoxCollider2D>();

        foreach (BoxCollider2D boxCollider in skillEffectsBoxCollider2D)
        {
            boxCollider.enabled = false;
        }
    }

    private void enableBoxColliders()
    {
        skillEffectsBoxCollider2D = GetComponentsInChildren<BoxCollider2D>();

        foreach (BoxCollider2D boxCollider in skillEffectsBoxCollider2D)
        {
            boxCollider.enabled = true;
        }
    }
}
