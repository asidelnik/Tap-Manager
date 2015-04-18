﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerSceneScript : MonoBehaviour {

	private PlayerScript m_playerScript;
	public Text m_position;
	public Text m_NameText;
	//public Text m_lastName;
	public Text m_salary;
	private bool m_isInjured;
	public Text m_age;
	public Text m_gamePlayed;
	public Text m_goalScored ;
	public Text m_level;
	public Text m_price;
	public Text m_yearOfJoiningTheClub;
	public Image m_PlayerImage;
    public Slider m_BoostSlider;
    public Text m_DrugText;
    public Text m_BoostText;

	public GameObject m_releasePlayerMenu;

	// Use this for initialization
	void Start () {
		int i = PlayerPrefs.GetInt ("SelectedPlayer", 0);
		
		m_playerScript = GameManager.s_GameManger.m_MySquad.GetPlayerInIndex (i);

        setPositionText();
        m_NameText.text = m_playerScript.GetFullName();
        m_gamePlayed.text = m_playerScript.GetGamePlayed().ToString();
        m_yearOfJoiningTheClub.text = "" + m_playerScript.GetYearJoinedTheClub();
        m_age.text = m_playerScript.GetAge().ToString();
        m_goalScored.text = m_playerScript.GetGoalScored().ToString();
        m_salary.text = "$" + m_playerScript.GetSalary() + " p/w";
	    m_DrugText.text = "Drugs ($" + m_playerScript.GetPriceToBoostPlayer()/2 + ")";
        m_BoostText.text = "Boost ($" + m_playerScript.GetPriceToBoostPlayer() + ")";
	}

    void Update()
    {
        m_BoostSlider.value = m_playerScript.GetBoostLevel();
        
        
        //m_lastName.text = ""+m_playerScript.getPlayerLastName();
        
        m_isInjured = m_playerScript.isInjered();
        m_level.text = m_playerScript.GetLevel().ToString();
        m_price.text = "$" + m_playerScript.GetPlayerPrice();
        
        //m_PlayerImage.sprite = m_playerScript.getPlayerImage().sprite;
    }
	
	public void OnClickReleasePlayer(){
		m_releasePlayerMenu.SetActive (true);
	}

	public void OnClickNoReleasePlayer(){
		m_releasePlayerMenu.SetActive (false);
	}

	public void OnClickYesReleasePlayer(){
		m_releasePlayerMenu.SetActive (false);
		m_playerScript.InitYoungPlayer ();
		Application.LoadLevel ("New_Squad");
	}

	public void onClickBoost(){
		if (m_playerScript.GetPriceToBoostPlayer () <= GameManager.s_GameManger.GetCash ()) {
			m_playerScript.BoostPlayer(34);
			GameManager.s_GameManger.AddCash(-m_playerScript.GetPriceToBoostPlayer ());
		}
	}

	public void onClickDrugs(){
		//temp sol
		if (m_playerScript.GetPriceToBoostPlayer ()/2 <= GameManager.s_GameManger.GetCash ()) {
			m_playerScript.BoostPlayer(Random.Range(0,105));
			GameManager.s_GameManger.AddCash((int)-m_playerScript.GetPriceToBoostPlayer ()/2);
		}

	}

    private string getPosByEnum(ePosition i_Position)
    {
        switch (i_Position)
        {
            case ePosition.GK:
                return "GoalKeeper";
            case ePosition.D:
                return "Defender";
            case ePosition.MF:
                return "Midfielder";
            case ePosition.S:
                return "Striker";
            default:
                Debug.LogError("GOT UNKNOWN POS");
                return "UNKNOWN!";
        }
    }

    private void setPositionText()
    {
        switch (m_playerScript.getPlayerPosition())
        {
            case ePosition.GK:
                m_position.text = "GoalKeeper";
                m_position.color = Color.yellow;
                break;
            case ePosition.D:
                m_position.text = "Defender";
                m_position.color = Color.blue;
                break;
            case ePosition.MF:
                m_position.text = "Midfielder";
                m_position.color = Color.green;
                break;
            case ePosition.S:
                m_position.text = "Striker";
                m_position.color = Color.red;
                break;
            default:
                Debug.LogError("GOT UNKNOWN POS");
                break;
        }
    }
}
