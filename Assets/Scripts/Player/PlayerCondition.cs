using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void TakePhysicalDamage(int damage);
}

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UICondition UICondition;

    private Condition health { get { return UICondition.health; } }
    private Condition stamina { get { return UICondition.stamina; } }

    public event Action onTakeDamage;

    private void Update()
    {
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if (health.curValue <= 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    private void Die()
    {
        Debug.Log("»ç¸Á");
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();

    }

    public void EatApple()
    {
        StartCoroutine(SpeedBuff());
    }

    private IEnumerator SpeedBuff()
    {
        int speedBuff = 20;
        CharacterManager.Instance.Player.controller.moveSpeed += speedBuff;
        yield return new WaitForSecondsRealtime(5);
        CharacterManager.Instance.Player.controller.moveSpeed -= speedBuff;
    }
}
