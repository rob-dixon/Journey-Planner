namespace Network
{

    public class Station
    {
        public int Id { get; set; }

        public RouteMedium[] Branches { get; private set; }

        public Station(RouteMedium[] branches)
        {
            this.Branches = branches;
        }
    }
}
