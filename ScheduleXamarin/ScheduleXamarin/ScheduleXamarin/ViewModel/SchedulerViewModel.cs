using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace ScheduleXamarin
{
    public class SchedulerViewModel : INotifyPropertyChanged
    {
        private List<string> currentDayMeetings;

        private ScheduleAppointmentCollection appointments;

        public ObservableCollection<DayOfWeek> nonWorkingDays;
        public SchedulerViewModel()
        {
            this.Appointments = new ScheduleAppointmentCollection();
            this.nonWorkingDays = new ObservableCollection<DayOfWeek>();
            nonWorkingDays.Add(DayOfWeek.Wednesday);
            nonWorkingDays.Add(DayOfWeek.Thursday);
            this.InitializeDataForBookings();
            this.BookingAppointments();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ScheduleAppointmentCollection Appointments
        {
            get
            {
                return this.appointments;
            }

            set
            {
                this.appointments = value;
                this.RaiseOnPropertyChanged("Appointments");
            }
        }

        public ObservableCollection<DayOfWeek> NonWorkingDays
        {
            get
            {
                return this.nonWorkingDays;
            }

            set
            {
                this.nonWorkingDays = value;
                this.RaiseOnPropertyChanged("NonWorkingDays");
            }
        }

        private void BookingAppointments()
        {
            Random randomTime = new Random();
            List<Point> randomTimeCollection = this.GettingTimeRanges();

            DateTime date;
            DateTime dateFrom = DateTime.Now.AddDays(-10);
            DateTime dateTo = DateTime.Now.AddDays(10);
            DateTime dateRangeStart = DateTime.Now.AddDays(-3);
            DateTime dateRangeEnd = DateTime.Now.AddDays(3);

            for (date = dateFrom; date < dateTo; date = date.AddDays(1))
            {
                if ((DateTime.Compare(date, dateRangeStart) > 0) && (DateTime.Compare(date, dateRangeEnd) < 0))
                {
                    for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 3; additionalAppointmentIndex++)
                    {
                        ScheduleAppointment meeting = new ScheduleAppointment();
                        int hour = randomTime.Next((int)randomTimeCollection[additionalAppointmentIndex].X, (int)randomTimeCollection[additionalAppointmentIndex].Y);
                        meeting.StartTime = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
                        meeting.EndTime = meeting.StartTime.AddHours(1);
                        meeting.Subject = this.currentDayMeetings[randomTime.Next(9)];
                        meeting.Color = meeting.Color = Color.FromHex("#889e81");
                        meeting.IsAllDay = false;
                        this.Appointments.Add(meeting);
                    }
                }
                else
                {
                    ScheduleAppointment meeting = new ScheduleAppointment();
                    meeting.StartTime = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 11), 0, 0);
                    meeting.EndTime = meeting.StartTime.AddHours(1);
                    meeting.Subject = this.currentDayMeetings[randomTime.Next(9)];
                    meeting.Color = meeting.Color = Color.FromHex("#889e81");
                    meeting.IsAllDay = false;
                    this.Appointments.Add(meeting);
                }
            }
        }
        private List<Point> GettingTimeRanges()
        {
            List<Point> randomTimeCollection = new List<Point>();
            randomTimeCollection.Add(new Point(9, 11));
            randomTimeCollection.Add(new Point(12, 14));
            randomTimeCollection.Add(new Point(15, 17));

            return randomTimeCollection;
        }
        private void InitializeDataForBookings()
        {
            this.currentDayMeetings = new List<string>();
            this.currentDayMeetings.Add("General Meeting");
            this.currentDayMeetings.Add("Plan Execution");
            this.currentDayMeetings.Add("Project Plan");
            this.currentDayMeetings.Add("Consulting");
            this.currentDayMeetings.Add("Performance Check");
            this.currentDayMeetings.Add("Yoga Therapy");
            this.currentDayMeetings.Add("Plan Execution");
            this.currentDayMeetings.Add("Project Plan");
            this.currentDayMeetings.Add("Consulting");
            this.currentDayMeetings.Add("Performance Check");
        }
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
