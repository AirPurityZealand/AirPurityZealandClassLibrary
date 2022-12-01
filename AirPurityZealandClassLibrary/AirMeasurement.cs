namespace AirPurityZealandClassLibrary
{
    public class AirMeasurement
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string RoomId { get; set; }
        public int Co2 { get; set; }
        public string Quality { get; set; }

        public AirMeasurement()
        {

        }

        public AirMeasurement(int id,DateTime timestamp,string roomId,int Co2)
        {
            this.Id = id;
            this.Timestamp = timestamp;
            this.RoomId = roomId;
            this.Co2 = Co2;
        }

        public AirMeasurement(int id,DateTime timestamp,string roomId)
        {
            this.Id = id;
            this.Timestamp = timestamp;
            this.RoomId = roomId;
        }

        public void ValidateRoomId()
        {
            if (this.RoomId.Length <= 0)
            {
                throw new ArgumentOutOfRangeException("The room id is invalid. The room id must be more than zero characters");
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