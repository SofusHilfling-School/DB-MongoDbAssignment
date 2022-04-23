using Website.Data;

namespace Website.Other;

public class TweetEventArgs : EventArgs
{
    public Tweet Tweet { get; set; }
}
