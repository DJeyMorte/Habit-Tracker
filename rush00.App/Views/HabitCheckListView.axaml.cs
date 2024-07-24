using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using rush00.ViewModels;
using rush00.Data;
using System.Linq;

namespace rush00.Views;

public partial class HabitCheckListView : UserControl
{
    public HabitCheckListView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    public void CheckBox_Checked(object sender, RoutedEventArgs e)
    {  
 
        var viewModel = (HabitCheckListViewModel)this.DataContext!;
        var checkBox = (CheckBox)sender;
        var isChecked = checkBox.IsChecked ?? false;
        var content = checkBox.Content?.ToString();

        DateTimeOffset date = DateTimeOffset.MinValue;

        foreach (var habitCheck in viewModel.Days)
        {
            if (habitCheck.CurrentDate.ToString("dd/MM/yyyy").Substring(0, 10) == content.Substring(0, 10))
            {
                date = habitCheck.CurrentDate;
                break;
            }
        }

        Console.WriteLine(date);



        using (var db = new HabitDbContext()) 
        {
            var d = db.HabitChecks.FirstOrDefault(b => b.CurrentDate == date);

            if(checkBox.IsChecked == true) 
            {   
                d.CurrentDate = date;
                d.IsChecked = true;
                db.SaveChanges();
            }

            var fin = db.Habits.SingleOrDefault(f => f.Id == 1);
            if(checkBox.IsChecked == true && date == viewModel.EndDate){
                fin.IsFinished = true;
                db.SaveChanges();
                // FinishCommand();
            }
        }

    }
}