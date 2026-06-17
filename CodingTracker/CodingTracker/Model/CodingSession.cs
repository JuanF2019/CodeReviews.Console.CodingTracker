namespace CodingTracker.Model
{
    internal class CodingSession
    {
        public DateTime StartDate
        {
            get;
            set
            {
                if (value > EndDate)
                {
                    throw new ArgumentException("Start Date must be before End Date");
                }
                field = value;
            }
        }
        public DateTime EndDate
        {
            get;
            set
            {
                if (value < StartDate)
                {
                    throw new ArgumentException("End Date must be after Start Date");
                }
                field = value;
            }
        }
        public TimeSpan Duration
        {
            get
            {
                return EndDate - StartDate;
            }
        }
    }
}
