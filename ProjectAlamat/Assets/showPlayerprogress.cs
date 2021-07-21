using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class showPlayerprogress : MonoBehaviour
{
    [SerializeField] Image expbar;
    [SerializeField] TextMeshProUGUI expText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   public void expbareffect(float currExp,float MaxExp,float expIncrease)
    {
        StartCoroutine(increaseExpBar(currExp, MaxExp, expIncrease));
    
    }

    IEnumerator increaseExpBar(float currExp, float MaxExp, float expIncrease)
    {
        float temp=currExp;
        while (temp < (currExp + expIncrease))
        {

            temp += 1;
            yield return new WaitForSeconds(0.1f);
            expbar.fillAmount = temp / MaxExp;
            expText.text = temp.ToString() + "/" + MaxExp.ToString();



        }
    }
}
