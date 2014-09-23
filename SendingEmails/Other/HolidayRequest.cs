namespace Other
{
    public class HolidayRequest
    {
        private readonly Employee employee;
        private readonly PeriodOfTime periodOfTime;

        public HolidayRequest(Employee employee, PeriodOfTime periodOfTime)
        {
            this.employee = employee;
            this.periodOfTime = periodOfTime;
        }

        public ManagerDecision Approve()
        {
            return new Approval(employee, "Also, here's some info: " + periodOfTime);
        }

        public ManagerDecision Reject(string reason)
        {
            return new Approval(employee, reason);
        }
    }
}
