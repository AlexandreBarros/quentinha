namespace QuentinhaCarioca.Root
{
    using System;
    public class LegalUserSettings
    {
        public Guid LegalUserSettingsId { get; set; }
        public LegalUser LegalUser { get; set; }
        public decimal DeliveryCoust { get; set; }
        public bool IsOpen { get; set; }
        public bool MondayIsWorkDay { get; set; }
        public string MondayStartHour { get; set; }
        public string MondayEndHour { get; set; }
        public bool TuesdayIsWorkDay { get; set; }
        public string TuesdayStartHour { get; set; }
        public string TuesdayEndHour { get; set; }
        public bool WednesdayIsWorkDay { get; set; }
        public string WednesdayStartHour { get; set; }
        public string WednesdayEndHour { get; set; }
        public bool ThursdayIsWorkDay { get; set; }
        public string ThursdayStartHour { get; set; }
        public string ThursdayEndHour { get; set; }
        public bool FridayIsWorkDay { get; set; }
        public string FridayStartHour { get; set; }
        public string FridayEndHour { get; set; }
        public bool SaturdayIsWorkDay { get; set; }
        public string SaturdayStartHour { get; set; }
        public string SaturdayEndHour { get; set; }
        public bool SundayIsWorkDay { get; set; }
        public string SundayStartHour { get; set; }
        public string SundayEndHour { get; set; }



    }
}
