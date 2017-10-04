namespace AnyStatus.API
{
    public class RootStateChanged
    {
        public RootStateChanged(State state)
        {
            State = state;
        }

        public State State { get; set; }
    }
}
