namespace AirPurityZealandClassLibrary
{
    public class AirMeasurement
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string RoomParameter { get; set; }
        public int Co2 { get; set; }
        public string Quality { get; set; }

        public AirMeasurement()
        {

        }

        public AirMeasurement(int id,DateTime timestamp,string roomParameter,int Co2)
        {
            this.Id = id;
            this.Timestamp = timestamp;
            this.RoomParameter = roomParameter;
            this.Co2 = Co2;
        }

        public AirMeasurement(int id,DateTime timestamp,string roomParameter)
        {
            this.Id = id;
            this.Timestamp = timestamp;
            this.RoomParameter = roomParameter;
        }

        public void ValidateRoomNumber()
        {
            if (this.RoomParameter.Length <= 0)
            {
                throw new ArgumentOutOfRangeException("The room number is invalid. The room parameter must be more than zero characters");
            }
        }

        //public void ValidateCo2()
        //{
        //    if(this.Co2 < 0)
        //    {
        //        throw new ArgumentOutOfRangeException("Co2 must be above 0% and below 100%. Co2 is currently below 0%");
        //    } else if (this.Co2 > 100)
        //    {
        //        throw new ArgumentOutOfRangeException("Co2 must be above 0% and below 100%. Co2 is currently above 100%");
        //    }
        //}

        public void ValidateDateTime()
        {
            DateTime dtMax = DateTime.Now.AddHours(25);
            TimeSpan subtract = TimeSpan.Parse("1.01:00:00");
            DateTime dtMin = DateTime.Now.Subtract(subtract);

            if (this.Timestamp >= dtMax)
            {
                throw new ArgumentOutOfRangeException("Timestamp is invalid. Timestamp is from the future");
            }
            if(this.Timestamp <= dtMin)
            {
                throw new ArgumentOutOfRangeException("Timestamp is invalid. Timestamp is too old");
            }
        }
    }
}