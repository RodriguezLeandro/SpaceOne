using UnityEngine;

public class chargingSkillScript : MonoBehaviour
{

    public float chargeDuration = 3f;
    public float endDuration = 4f;

    private float chargeTimer = 0f;
    private BoxCollider2D skillEffectBoxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        skillEffectBoxCollider2D = GetComponent<BoxCollider2D>();

        skillEffectBoxCollider2D.enabled = false;
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
            skillEffectBoxCollider2D.enabled = true;
        }

        if (chargeTimer > endDuration)
        {
            Color color = gameObject.GetComponent<SpriteRenderer>().material.color;
            color.a = 0f;
            gameObject.GetComponent<SpriteRenderer>().material.color = color;
            chargeTimer = 0f;
            skillEffectBoxCollider2D.enabled = false;
            GameObject setActive = gameObject.GetComponent<setActive>().gameObject;
            setActive.SetActive(false);
        }
    }
}
