using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenTest : MonoBehaviour
{
    private Vector3 _originalScale;
    private Vector3 _scaleTo;
    void Start()
    {
        _originalScale = transform.localScale;
        _scaleTo = _originalScale * 1.5f;


        onScale();
    }

    public void onScale()
    {
        transform.DOScale(_scaleTo, .5f)
            .SetEase(Ease.Flash)
            .OnComplete(() =>
            {

                transform.DOScale(_originalScale, .5f)
                .SetEase(Ease.OutElastic);

            });

    }
 
}
