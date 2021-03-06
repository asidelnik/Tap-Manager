﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TableScript : MonoBehaviour {

	public RectTransform m_contentPanel;
	public GameObject m_rowPrefab;
	private GameObject[] m_lines;

	void Start()
	{
		GameManager.s_GameManger.updateTableLeague ();
	}


	public void InitTable(int i_numOfTeams){
		m_lines = new GameObject[i_numOfTeams];
		m_lines[0] = Instantiate(m_rowPrefab);
	    m_lines[0].gameObject.transform.SetParent(m_contentPanel.transform);
		for (int i = 1; i < m_lines.Length ; i++) {
			m_lines[i] = Instantiate(m_rowPrefab);
            m_lines[i].gameObject.transform.SetParent(m_contentPanel.transform);
		}


	}
	public void UpdateLine(int i_lineNum,int i_place,string i_team,int
	                             i_played,int i_won,int i_lost, int i_drawn,int i_for,int i_against,
	                             int i_points){

		OneLineUITableScript oneLineUITableScript = m_lines [i_lineNum].GetComponent<OneLineUITableScript> ();
		oneLineUITableScript.m_place.text = "" +i_place;
		oneLineUITableScript.m_team.text = "" +i_team;
		oneLineUITableScript.m_played.text = ""+ i_played;
		oneLineUITableScript.m_won.text = ""+ i_won;
		oneLineUITableScript.m_lost.text = ""+ i_lost;
		oneLineUITableScript.m_drawn.text =  ""+ i_drawn;
		oneLineUITableScript.m_for.text =  ""+ i_for;
		oneLineUITableScript.m_against.text =  ""+ i_against;
		oneLineUITableScript.m_points.text =  ""+ i_points;
	}



}
