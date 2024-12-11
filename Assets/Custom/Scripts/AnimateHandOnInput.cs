using UnityEngine;


public class AnimateHandOnInput : MonoBehaviour
{
    Animator handAnimator;

    public enum MyEnum // *
    {
        Left,
        Right
    }
    public MyEnum myHand;



    // Update is called once per frame
    private void Start()
    {
        handAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        handAnimator.SetFloat("Grip", Input.GetAxis("XRI_" + myHand.ToString() + "_Grip"));
        handAnimator.SetFloat("Trigger", Input.GetAxis("XRI_" + myHand.ToString() + "_Trigger"));



    }
}
