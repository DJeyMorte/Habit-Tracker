using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using rush00.Models;
using rush00.Data;
using rush00.Views;
using System.IO;

namespace rush00.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public HabitViewModel HabitViewModel { get; }
    
    public HabitCheckListViewModel HabitCheckListViewModel { get; set; }
    public MainWindowViewModel()
    {   
        using (var context = new HabitDbContext())
        {
            try
            {  
                var x = context.Habits.First().Id;
                var d = context.HabitChecks.SingleOrDefault(b => b.Id == 1);
                if (d is not null)
                {
                    // HabitCheck habit = new HabitCheck(d.CurrentDate, d.IsChecked);
                    // Content = HabitCheckListViewModel(habit);
                    StartCommand();
                }
            } catch {
                Content = HabitViewModel = new HabitViewModel();
            }
        }
    }
    
    private ViewModelBase _content;
    public ViewModelBase Content
    {
        get => _content;
        private set
        {
           var res  =  this.RaiseAndSetIfChanged( ref _content, value);
           Console.WriteLine("Content is changed");
        } 
    }

    public void StartCommand()
    {
        using (var db = new HabitDbContext()) {
            var countDays = this.HabitViewModel.TrackingDaysNumber;
        var habit = new Habit(this.HabitViewModel.Title, this.HabitViewModel.Motivation, this.HabitViewModel.StartDate,
            this.HabitViewModel.TrackingDaysNumber);
        habit.DaysList  = new List<HabitCheck>(countDays);
        
        for (int i = 0; i < countDays; i++)
        {
            habit.DaysList.Add(new HabitCheck(habit.StartDate.AddDays((double)i), false));
            System.Console.WriteLine(habit.StartDate.AddDays((double)i));
        }
        HabitCheckListViewModel  = new HabitCheckListViewModel(habit.DaysList );
        HabitCheckListViewModel.Habit = habit;

        System.Console.WriteLine(HabitCheckListViewModel.CurrentDate);

        
        db.Add(habit);
        db.SaveChanges();
        
        Content = HabitCheckListViewModel;
         //WindowTitle = habit.Title;
        Console.WriteLine("I try to create HabitChecklistViewModel");

        }
    }
    public void FinishCommand()
    {
        var days = HabitCheckListViewModel.Days;
        HabitCheckListViewModel.Habit.IsFinished = days.Last().IsChecked || days.Last().CurrentDate > DateTime.Now ? true : false;
        var congratulationsViewModel = new CongratulationsViewModel(days, HabitCheckListViewModel.Habit.Motivation);
        Content = congratulationsViewModel;

    }
}



/*
https://habr.com/ru/articles/303650/
Здесь стоит сказать пару слов о том, что это за IObservable. 
Это реактивные (push-based) провайдеры уведомлений. Принцип довольно прост: 
в классической модели (pull-based) мы сами бегаем к провайдерам данных 
и опрашиваем их на наличие обновлений. В реактивной – 
мы подписываемся на такой вот канал уведомлений и не беспокоимся об опросе, все обновления придут к нам сами:
public interface IObservable<out T>
{
    IDisposable Subscribe(IObserver<T> observer);
}
*/
    
