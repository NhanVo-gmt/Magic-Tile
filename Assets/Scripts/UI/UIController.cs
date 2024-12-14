using System;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private static UIController Instance;
    
    private static List<UIPage>             pages = new();
    private static Dictionary<Type, UIPage> pagesLink = new();
    
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
        
        pages     = new List<UIPage>();
        pagesLink = new Dictionary<Type, UIPage>();
        for (int i = 0; i < transform.childCount; i++)
        {
            UIPage uiPage = transform.GetChild(i).GetComponent<UIPage>();
            if(uiPage != null)
            {
                uiPage.CacheComponents();

                pagesLink.Add(uiPage.GetType(), uiPage);

                pages.Add(uiPage);
            }
            
            uiPage.Initialise();
        }
    }
    
    public static void ShowPage<T>() where T : UIPage
    {
        Type   pageType = typeof(T);
        UIPage page     = pagesLink[pageType];
        if (!page.IsPageDisplayed)
        {
            page.PlayShowAnimation();
            page.EnableCanvas();
            page.GraphicRaycaster.enabled = true;
        }
    }
    
    public static void HidePage<T>(Action onPageClosed = null)
    {
        Type   pageType = typeof(T);
        UIPage page     = pagesLink[pageType];
        if (page.IsPageDisplayed)
        {
            page.GraphicRaycaster.enabled = false;
            page.PlayHideAnimation();
        }
        else
        {
            onPageClosed?.Invoke();
        }
    }
    
    public static T GetPage<T>() where T : UIPage
    {
        return pagesLink[typeof(T)] as T;
    }
}