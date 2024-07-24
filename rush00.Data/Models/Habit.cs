using System;
using System.Collections.Generic;
using System.Linq;

namespace rush00.Models;

public class Habit
{	
	public int Id { get; set;}
	public string Title { get; set; }
	public string Motivation { get; set; }
	public DateTimeOffset StartDate { get; set;}
	public int TrackingDaysNumber { get;  set;}
	public bool IsFinished { get; set; }

	public List<HabitCheck> DaysList { get;  set;} 

	public Habit() {}

	public Habit(string title, string motivation, DateTimeOffset startDate, int daysNumber)
	{
		Title = title;
		Motivation = motivation;
		StartDate = startDate;
		TrackingDaysNumber = daysNumber;
		DaysList = new List<HabitCheck>(daysNumber);
		IsFinished = false;
	}

	public void IsAllDaysFinished(List<HabitCheck> daysList)
	{
		IsFinished = DaysList.Last().IsChecked || DaysList.Last().CurrentDate > DateTime.Now ? true : false;
	}
}
