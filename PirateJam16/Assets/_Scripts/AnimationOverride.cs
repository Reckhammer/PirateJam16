using UnityEngine;

public class AnimationOverride : MonoBehaviour
{
    public Animator animator;
    public AnimatorOverrideController overrideControllerTemplate;

    // Todo: make this a list of {StateName, Clip}
    public AnimationClip readyClip;
    public AnimationClip idleClip;
    public AnimationClip fireClip;

    void Start()
    {
        // Create a new instance of the override controller (so changes don't affect all instances)
        AnimatorOverrideController overrideController = new AnimatorOverrideController(overrideControllerTemplate);

        // Assign it to the Animator
        animator.runtimeAnimatorController = overrideController;

        // Todo put this into a function
        // Override specific animations
        overrideController["Ready"] = readyClip;
        overrideController["Idle"]  = idleClip;
        overrideController["Fire"]  = fireClip;
    }
}