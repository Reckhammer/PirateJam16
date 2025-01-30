using UnityEngine;

public class Hacker : TransformItem
{
    public override void UseItem()
    {
        // empty to prevent animation
    }

    public void HackTriggered()
    {
        animator.SetBool("Hack", true);
    }

    public void HackExited()
    {
        animator.SetBool("Hack", false);
    }
}
