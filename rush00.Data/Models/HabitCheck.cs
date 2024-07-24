using System;

namespace rush00.Models;

public class HabitCheck
{	
	public int Id {get; set; }
	public DateTimeOffset CurrentDate {get; set; }
	public bool IsChecked {get; set; }

	public HabitCheck(DateTimeOffset currentDate, bool isChecked)
	{
		CurrentDate = currentDate;
		IsChecked = isChecked;
	}
}
