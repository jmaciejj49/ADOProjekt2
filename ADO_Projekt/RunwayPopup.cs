using System;
using System.Windows.Forms;

namespace ADO_Projekt
{
    public partial class RunwayPopup : Form
    {
        public event EventHandler<RunwayDateSelectedEventArgs> RunwayDateSelected;
        public class RunwayDateSelectedEventArgs : EventArgs
        {
            public DateTime StartsAt { get; set; }
            public DateTime EndsAt { get; set; }
            public bool isActive { get; set; }
        }


        public RunwayPopup(DateTime dateToDisplay = default(DateTime))
        {
            InitializeComponent();


            if (dateToDisplay == default(DateTime))
            {
                dateToDisplay = DateTime.Now.AddDays(1);
            }

            datePickerStartsAt.Value = dateToDisplay;
            timePickerStartsAt.Value = dateToDisplay;

            datePickerEndsAt.Value = dateToDisplay.AddHours(1);
            timePickerEndsAt.Value = dateToDisplay.AddHours(1);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            DateTime startsAt = datePickerStartsAt.Value.Date + timePickerStartsAt.Value.TimeOfDay;
            DateTime endsAt = datePickerEndsAt.Value.Date + timePickerEndsAt.Value.TimeOfDay;

            //ValidateRunwayData()

            RunwayDateSelected?.Invoke(this, new RunwayDateSelectedEventArgs {StartsAt = startsAt, 
                EndsAt = endsAt, isActive = checkBoxActive.Checked });
            this.Close();
        }

        private void RunwayPopup_Load(object sender, EventArgs e)
        {
            timePickerStartsAt.Format = DateTimePickerFormat.Custom;
            timePickerEndsAt.Format = DateTimePickerFormat.Custom;

            timePickerStartsAt.CustomFormat = "HH:mm";
            timePickerEndsAt.CustomFormat = "HH:mm";
        }
    }
}
