using UnityEngine;
using System.Collections;

public class Debuffs : MonoBehaviour {
    


    IEnumerator DamageOverTimeCoroutine(int damageAmount, int duration)
    {
        int amountDamaged = 0;
        int damagePerLoop = damageAmount / duration;
        while (amountDamaged < damageAmount)
        {
            amountDamaged += damagePerLoop;
            gameObject.GetComponent<Character>().TakeDamage(damagePerLoop);
            yield return new WaitForSeconds(1.5f);
        }
    }

    public void DamageOverTime(int damageAmount, int damageTime)
    {
        StartCoroutine(DamageOverTimeCoroutine(damageAmount, damageTime));
    }

    IEnumerator TimedStunCoroutine(int duration)
    {
        int timeStunned = 0;
        while (timeStunned < duration)
        {
            gameObject.GetComponent<Character>().IsStunned = true;
            timeStunned++;            
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void TimedStun(int stunTime)
    {
        StartCoroutine(TimedStunCoroutine(stunTime));
    }

    IEnumerator TimedSlowCoroutine()
    {
        print("Starting Coroutine");
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<Character>().IsSlowed = false;
    }

    public void TimedSlow()
    {
        gameObject.GetComponent<Character>().IsSlowed = true;
        StartCoroutine(TimedSlowCoroutine());
        print("Stopping Coroutine");
    }

    IEnumerator TimedSnareCoroutine(int duration)
    {
        int timeSnared = 0;
        while (timeSnared < duration)
        {
            gameObject.GetComponent<Character>().IsSnared = true;
            timeSnared++;
            yield return new WaitForSeconds(1.0f);
        }
    }
    
    public void TimedSnare(int snareTime)
    {
        StartCoroutine(TimedSnareCoroutine(snareTime));
    }    
}
