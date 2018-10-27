using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class UILevelSelect : MonoBehaviour {

    [SerializeField]
    private UILevel levelUI;
    [SerializeField]
    private LevelPopup levelPopup;

    private int maxPage;
    private int pageSize = 12;

    private Transform levelSelectPanel;
    private int currentPage;
    private List<UILevel> levelList = new List<UILevel>();


	// Use this for initialization
	void Start () {
        levelSelectPanel = transform;

        for (int i = 0; i < LevelController.instance.levels.Count; i++) {
            levelList.Add(levelUI);
        }

        maxPage = levelList.Count / pageSize;

        BuildLevelPage(0);
	}
	
    private void BuildLevelPage(int page) {
 
        if (page >= 0 && page <= maxPage) {
            RemoveItemsFromPage();

            currentPage = page;

            List<UILevel> pageList = levelList.Skip(page * pageSize).Take(pageSize).ToList();

            for (int i = 0; i < pageList.Count; i++) {
                Level level = LevelController.instance.levels[(page * pageSize) + i];

                UILevel instance = Instantiate(pageList[i]);
                instance.SetStars(level.Stars);
                instance.transform.SetParent(levelSelectPanel);
                instance.transform.localScale = new Vector3(1f, 1f, 1f);
                instance.GetComponent<Button>().onClick.AddListener(() => SelectLevel(level));

                if (!level.Locked) {
                    instance.lockImage.SetActive(false);
                    instance.levelIDText.text = (level.ID + 1).ToString();
                } else {
                    instance.lockImage.SetActive(true);
                    instance.levelIDText.text = "";
                }
            }
        }
    }

    private void RemoveItemsFromPage() {
        for (int i = 0; i < levelSelectPanel.childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void NextPage() {
        BuildLevelPage(currentPage + 1);
    }

    public void PreviousPage() {
        BuildLevelPage(currentPage - 1);
    }

    private void SelectLevel(Level level) {
        if (level.Locked) {
            levelPopup.gameObject.SetActive(true);
            levelPopup.SetText("Level " + (level.ID + 1) + " is currently locked.\nComplete level " + level.ID + " to unlock it!");
            Debug.Log("Level locked.");
        } else {
            Debug.Log("Go to level: " + level.ID);

            LevelController.instance.StartLevel(level.LevelName);
        }
    }
}
