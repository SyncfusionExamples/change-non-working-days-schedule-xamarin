# How to change the nonworking days in Xamarin.Forms Schedule (SfSchedule)


You can customize the non-working days of a week by using the [NonWorkingDays](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfSchedule.XForms.WorkWeekViewSettings.html#Syncfusion_SfSchedule_XForms_WorkWeekViewSettings_NonWorkingsDays) property of [WorkWeekViewSettings](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfSchedule.XForms.WorkWeekViewSettings.html) in Xamarin.Forms [SfSchedule](https://www.syncfusion.com/xamarin-ui-controls/xamarin-scheduler).

**C#**

Declare and define the nonworking days property in ViewModel.
```
public SchedulerViewModel()
{
    this.Appointments = new ScheduleAppointmentCollection();
    this.NonWorkingDays = new ObservableCollection<DayOfWeek>();
    NonWorkingDays.Add(DayOfWeek.Wednesday);
    NonWorkingDays.Add(DayOfWeek.Thursday);
    this.InitializeDataForBookings();
    this.BookingAppointments();
}
```

**XAML**
Bind the appointments to a schedule by using the DataSource property. You can bind the nonworking days collection to the `NonWorkingDays` property of `WorkWeekViewSettings`.
```
    <syncfusion:SfSchedule x:Name="Schedule" ScheduleView="WorkWeekView" DataSource="{Binding Appointments}">
        <syncfusion:SfSchedule.WorkWeekViewSettings>
            <syncfusion:WorkWeekViewSettings NonWorkingsDays="{Binding NonWorkingDays}"/>
        </syncfusion:SfSchedule.WorkWeekViewSettings>
         <syncfusion:SfSchedule.TimelineViewSettings>
            <syncfusion:TimelineViewSettings NonWorkingsDays="{Binding NonWorkingDays}"/>
        </syncfusion:SfSchedule.TimelineViewSettings>
        <syncfusion:SfSchedule.BindingContext>
            <local:SchedulerViewModel/>
        </syncfusion:SfSchedule.BindingContext>
    </syncfusion:SfSchedule>
</ContentPage>
```

KB article - [How to change the nonworking days in Xamarin.Forms Schedule (SfSchedule)](https://www.syncfusion.com/kb/12228/how-to-change-the-nonworking-days-in-xamarin-forms-schedule-sfschedule)