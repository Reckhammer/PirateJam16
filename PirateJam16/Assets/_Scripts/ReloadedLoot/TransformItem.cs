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

    [Header("SFX")]
    public AudioClip useSFX;
    private AudioSource audioSource;

    public virtual void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
        PlaySFX();
    }

    protected void PlayAnimation(string animId)
    {
        if (animator != null)
            animator.SetTrigger(animId);
    }

    protected void PlaySFX()
    {
        if (useSFX == null) return;

        audioSource.clip = useSFX;
        audioSource.Play();
    }
}
