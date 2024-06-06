using System;
using System.Windows.Forms;

namespace ADO_Projekt
{
    public partial class RunwayPopup : Form
    {
        public event EventHandler<RunwayPanelArguments> RunwayDateSelected;
        private readonly DataHelper dataHelper = new DataHelper();
        private readonly DBHelper dbHelper = new DBHelper();
        private RunwayPanelArguments _initialArguments;
        public class RunwayPanelArguments : EventArgs
        {
            public DateTime StartsAt { get; set; }
            public DateTime EndsAt { get; set; }
            public bool IsActive { get; set; }
            public int? EntityID { get; set; }
        }

        public RunwayPopup(RunwayPanelArguments initialArguments)
        {
            InitializeComponent();
            _initialArguments = initialArguments;

            if(initialArguments != null )
            {
                datePickerStartsAt.Value = initialArguments.StartsAt;
                datePickerEndsAt.Value = initialArguments.EndsAt;

                timePickerStartsAt.Value = initialArguments.StartsAt;
                timePickerEndsAt.Value = initialArguments.EndsAt;

                checkBoxActive.Checked = initialArguments.IsActive;
            }
            else
            {
                DateTime dateToDisplay = DateTime.Now;
                datePickerStartsAt.Value = dateToDisplay;
                timePickerStartsAt.Value = dateToDisplay;
                datePickerEndsAt.Value = dateToDisplay.AddHours(1);
                timePickerEndsAt.Value = dateToDisplay.AddHours(1);
            }
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
            bool checkboxValue = checkBoxActive.Checked;

            int? scheduleEntityID = _initialArguments?.EntityID;

            RunwayPanelArguments arguments = new RunwayPanelArguments
            {
                StartsAt = startsAt,
                EndsAt = endsAt,
                IsActive = checkboxValue,
                EntityID = scheduleEntityID
            };

            if (!dataHelper.ValidateRunwayData(arguments))
            {
                return;
            }

            bool runwayStatusCheck = scheduleEntityID.HasValue
                ? dbHelper.RunwayStatusDateTaken(startsAt, endsAt, scheduleEntityID.Value)
                : dbHelper.RunwayStatusDateTaken(startsAt, endsAt);

            if (!runwayStatusCheck)
            {
                MessageBox.Show("Dla podanego okresu czasu istnieje już wpis!");
                return;
            }
            if (dbHelper.FlightScheduleDateTaken(startsAt, endsAt))
            {
                MessageBox.Show("Dla podanego okresu czasu zaplanowane są loty!");
                return;
            }

            RunwayDateSelected?.Invoke(this, arguments);
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
