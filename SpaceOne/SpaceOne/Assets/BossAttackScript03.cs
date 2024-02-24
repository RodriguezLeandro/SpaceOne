using UnityEngine;

public class BossAttackScript03 : BossAttackScript
{

    private GameObject finalBossLaser01;
    private GameObject finalBossLaser02;

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
        finalBossLaser01 = gameObject.transform.parent.Find("FinalBossAttack03").gameObject;
        finalBossLaser02 = gameObject.transform.parent.Find("FinalBossAttack04").gameObject;

        if (finalBossLaser01 != null)
        {
            finalBossLaser01.SetActive(true);
            Invoke("deactivateLaser01", 4f);
        }
        if (finalBossLaser02 != null)
        {
            finalBossLaser02.SetActive(true);
            Invoke("deactivateLaser02", 4f);
        }
    }

    private void deactivateLaser01() 
    {
        finalBossLaser01.SetActive(false);
    }

    private void deactivateLaser02()
    {
        finalBossLaser02.SetActive(false);
    }
}
