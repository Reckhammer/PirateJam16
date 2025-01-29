using UnityEngine;

public class TransformItem : EquippableObject
{
    [Header("Transform Item")]
    public GameObject defaultModel;
    public GameObject transformModel;
    public bool isTransformed = false;

    private Rigidbody m_rigidbody;

    [Header("Animations")]
    public Animator animator;

    public virtual void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    public override void Interact()
    {
        base.Interact();

        defaultModel.SetActive(false);
        transformModel.SetActive(true);
    }

    public override void Equip()
    {
        base.Equip();

        PlayAnimation("Ready");

        m_rigidbody.isKinematic = true;
        m_rigidbody.useGravity  = false;
    }

    public override void Unequip()
    {
        base.Unequip();

        m_rigidbody.isKinematic = false;
        m_rigidbody.useGravity  = true;
    }

    public override void UseItem()
    {
        PlayAnimation("Fire");
    }

    private void PlayAnimation(string animId)
    {
        if (animator != null)
            animator.SetTrigger(animId);
    }
}
