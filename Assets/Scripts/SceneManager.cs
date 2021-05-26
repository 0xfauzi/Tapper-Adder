using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
    public GameObject gameState;

    //Target panel
    public GameObject targetPanel;
    private Animator targetPanelAnimator;

    //Game panel
    public GameObject gamePanel;
    private Animator gamePanelAnimator;

    // report panel
    public GameObject reportPanel;
    private Animator reportPanelAnimator;

    void Start()
    {
        targetPanelAnimator = targetPanel.GetComponent<Animator>();
        gamePanelAnimator = gamePanel.GetComponent<Animator>();
        reportPanelAnimator = reportPanel.GetComponent<Animator>();
        changeWrapModesToOnce(targetPanelAnimator, gamePanelAnimator, reportPanelAnimator);
    }


    public void loadTargetPanel()
    {
        targetPanelAnimator.enabled = true;
        gamePanelAnimator.Play(SupportedAnimations.GAME_SCREEN_OUT);
        reportPanelAnimator.Play(SupportedAnimations.REPORT_SCREEN_OUT);
        targetPanelAnimator.Play(SupportedAnimations.TARGET_SCREEN_IN);
        // Debug.Log("SCENE_MANAGER:: Loading Target Panel");
    }

    public void loadGamePanel()
    {
        gamePanelAnimator.enabled = true;
        targetPanelAnimator.Play(SupportedAnimations.TARGET_SCREEN_OUT);
        gamePanelAnimator.Play(SupportedAnimations.GAME_SCREEN_IN);
        // Debug.Log("SCENE_MANAGER:: Loading Game Panel");
    }

    public void loadReportPanel()
    {
        reportPanelAnimator.enabled = true;
        reportPanelAnimator.Play(SupportedAnimations.REPORT_SCREEN_IN);
        // Debug.Log("SCENE_MANAGER:: Loading Report Panel");
    }

    public void loadStartPanel()
    {
        // Debug.Log("SCENE_MANAGER:: Loading Start Panel");
        

    }

    private void changeWrapModesToOnce(Animator targetPanelAnimator, Animator gamePanelAnimator, Animator reportPanelAnimator)
    {
        RuntimeAnimatorController targetPanelAnimaorController = targetPanelAnimator.runtimeAnimatorController;
        AnimationClip[] targetPanelAnimationClips = targetPanelAnimaorController.animationClips;
        for (int i = 0; i < targetPanelAnimationClips.Length; i++)
        {
            targetPanelAnimationClips[i].wrapMode = WrapMode.Once;
        }

        RuntimeAnimatorController gamePanelAnimaorController = gamePanelAnimator.runtimeAnimatorController;
        AnimationClip[] gamePanelAnimationClips = gamePanelAnimaorController.animationClips;
        for (int i = 0; i < gamePanelAnimationClips.Length; i++)
        {
            gamePanelAnimationClips[i].wrapMode = WrapMode.Once;
        }

        RuntimeAnimatorController reportPanelAnimaorController = reportPanelAnimator.runtimeAnimatorController;
        AnimationClip[] reportPanelAnimationClips = reportPanelAnimaorController.animationClips;
        for (int i = 0; i < reportPanelAnimationClips.Length; i++)
        {
            reportPanelAnimationClips[i].wrapMode = WrapMode.Once;
        }
    }
}
