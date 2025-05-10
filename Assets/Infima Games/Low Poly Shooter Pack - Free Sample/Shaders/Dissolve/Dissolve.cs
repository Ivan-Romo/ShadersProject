using UnityEngine;

public class Dissolve : MonoBehaviour
{
    [SerializeField] Material m_Crystal;
    [SerializeField] Material m_Sphere;

    [SerializeField] private float dissolveSpeed = 0.5f;

    const float MIN_CRYSTAL = -1f;
    const float MAX_CRYSTAL = 1.5f;
    const float MIN_SPHERE = 0f;
    const float MAX_SPHERE = 1.35f;

    private float cutoffHeight = 0f;
    private bool isDissolving = false;
    private int dissolveDirection = 1;
    private void OnTriggerEnter(Collider other)
    {
        ToggleDissolve();
    }

    private void Update()
    {
        if (isDissolving)
        {
            cutoffHeight += Time.deltaTime * dissolveSpeed * dissolveDirection;
            cutoffHeight = Mathf.Clamp01(cutoffHeight);

            m_Crystal.SetFloat("_Cutoff_Height", Mathf.Lerp(MIN_CRYSTAL, MAX_CRYSTAL, cutoffHeight));
            m_Sphere.SetFloat("_Cutoff_Height", Mathf.Lerp(MIN_SPHERE, MAX_SPHERE, cutoffHeight));

            if (cutoffHeight == 0f || cutoffHeight == 1f) isDissolving = false;
        }
    }

    public void ToggleDissolve()
    {
        if (cutoffHeight == 0f) dissolveDirection = 1;
        else if (cutoffHeight == 1f) dissolveDirection = -1;

        isDissolving = true;        
    }
}
