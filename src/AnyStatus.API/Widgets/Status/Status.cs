using System.Linq;

namespace AnyStatus.API
{
    public class Status : Enumeration<Status, int>
    {
        private StateMetadata _stateMetadata;

        public static readonly Status None = new Status(0);
        public static readonly Status Unknown = new Status(1);
        public static readonly Status Disabled = new Status(2);
        public static readonly Status Canceled = new Status(3);
        public static readonly Status Ok = new Status(4);
        public static readonly Status Open = new Status(5);
        public static readonly Status Closed = new Status(6);
        public static readonly Status PartiallySucceeded = new Status(7);
        public static readonly Status Failed = new Status(8);
        public static readonly Status Invalid = new Status(9);
        public static readonly Status Error = new Status(10);
        public static readonly Status Running = new Status(11);
        public static readonly Status Queued = new Status(12);

        private Status(int value) : base(value)
        {
            Metadata = new StateMetadata
            {
                Value = value,
                Priority = value
            };
        }

        public StateMetadata Metadata
        {
            get { return _stateMetadata; }
            private set
            {
                _stateMetadata = value;
                OnPropertyChanged();
            }
        }

        public static void SetMetadata(StateMetadata[] metadataArray)
        {
            if (metadataArray == null)
                return;

            var states = GetAll().ToDictionary(k => k.Value, v => v);

            foreach (var metadata in metadataArray)
            {
                if (states.ContainsKey(metadata.Value))
                {
                    states[metadata.Value].Metadata = metadata;
                }
            }
        }

        public static StateMetadata[] GetMetadata()
        {
            return GetAll().Select(status => status.Metadata).ToArray();
        }

        public static implicit operator int(Status status)
        {
            return status.Value;
        }
    }
}