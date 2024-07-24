using System;
using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;
using rush00.Models;
using rush00.Views;
using rush00.Data;

namespace rush00.ViewModels;

public class HabitViewModel : ViewModelBase
{
	private ObservableAsPropertyHelper<bool> _startBtnEnable;
	public bool StartButtonEnable
	{
		get { return _startBtnEnable.Value; }
	}
	
	private string _title;
	public string Title
	{
		get => _title;
		set
		{
			var result = this.RaiseAndSetIfChanged(ref _title, value);
			Console.WriteLine("resultTitle = {0}", result);
		}
	}

	private string _motivation;
	public string Motivation
	{
		get => _motivation;
		set
		{
			var result = this.RaiseAndSetIfChanged(ref _motivation, value);
			Console.WriteLine("result = {0}", result);
		}
	}

	private DateTimeOffset _startDate = new DateTimeOffset(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0, 
		new TimeSpan(1, 0, 0));
	public DateTimeOffset StartDate 
	{
		get => _startDate.DateTime;
		set
		{
			var result = this.RaiseAndSetIfChanged(ref _startDate, value.DateTime);
			Console.WriteLine("result = {0}", result);
		}
	}
	

    private int _trackingDaysNumber;
    public int TrackingDaysNumber
    {
        get => _trackingDaysNumber;
        set
        {
	        
	       var result = this.RaiseAndSetIfChanged( ref _trackingDaysNumber, value); 
	       Console.WriteLine("DaysNumber = {0}", result);

        }
    }

    private bool _isFinished;
    public bool IsFinished
    {
	    get => _isFinished;
	    set =>this.RaiseAndSetIfChanged( ref _isFinished, value);
    }
    
    public HabitViewModel()
    {
	    this.WhenAnyValue(
			    x => x.Title,
			    x => x.Motivation,
			    x => x.TrackingDaysNumber,
			    (title, motiv, days) => !string.IsNullOrWhiteSpace(title) &&
			                            !string.IsNullOrWhiteSpace(motiv) && days > 0)
		    .ToProperty(this, x => x.StartButtonEnable, out _startBtnEnable);
			
    }
}
