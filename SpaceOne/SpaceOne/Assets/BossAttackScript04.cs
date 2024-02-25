using UnityEngine;

public class BossAttackScript04 : BossAttackScript
{
    private GameObject finalBossFinalAttack;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void ExecuteAttack()
    {
        finalBossFinalAttack = gameObject.transform.parent.Find("FinalBossAttack05").gameObject;

        if (finalBossFinalAttack != null)
        {
            finalBossFinalAttack.SetActive(true);
            Invoke("deactivateFinalBossAttack", 4f);
        }
    }

    private void deactivateFinalBossAttack()
    {
        finalBossFinalAttack.SetActive(false);
    }
}
