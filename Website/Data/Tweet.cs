using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Website.Data;


public class Tweet
{
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonId]
    public string _id { get; set; }
    public string created_at { get; set; }
    [BsonElement("id")]
    public long id { get; set; }
    public string id_str { get; set; }
    public string text { get; set; }
    public string source { get; set; }
    public bool truncated { get; set; }
    public object in_reply_to_status_id { get; set; }
    public object in_reply_to_status_id_str { get; set; }
    public object in_reply_to_user_id { get; set; }
    public object in_reply_to_user_id_str { get; set; }
    public object in_reply_to_screen_name { get; set; }
    public User user { get; set; }
    public object geo { get; set; }
    public object coordinates { get; set; }
    public object place { get; set; }
    public object contributors { get; set; }
    public Retweeted_Status retweeted_status { get; set; }
    public int retweet_count { get; set; }
    public int favorite_count { get; set; }
    public Entities1 entities { get; set; }
    public Extended_Entities extended_entities { get; set; }
    public bool favorited { get; set; }
    public bool retweeted { get; set; }
    public bool possibly_sensitive { get; set; }
    public bool possibly_sensitive_appealable { get; set; }
    public string lang { get; set; }
}

[BsonNoId]
public class User
{
    public bool default_profile_image { get; set; }
    public string url { get; set; }
    public Entities entities { get; set; }
    public int friends_count { get; set; }
    public string profile_image_url { get; set; }
    public string profile_sidebar_fill_color { get; set; }
    public bool notifications { get; set; }
    public bool default_profile { get; set; }
    [BsonElement("id")]
    public long id { get; set; }
    public string id_str { get; set; }
    public bool geo_enabled { get; set; }
    public bool profile_background_tile { get; set; }
    public bool profile_use_background_image { get; set; }
    [BsonElement("protected")]
    public bool _protected { get; set; }
    public string created_at { get; set; }
    public int? utc_offset { get; set; }
    public string profile_background_image_url_https { get; set; }
    public string name { get; set; }
    public string location { get; set; }
    public string profile_background_image_url { get; set; }
    public string profile_banner_url { get; set; }
    public string profile_link_color { get; set; }
    public string time_zone { get; set; }
    public int statuses_count { get; set; }
    public bool is_translation_enabled { get; set; }
    public string profile_background_color { get; set; }
    public string profile_image_url_https { get; set; }
    public string profile_sidebar_border_color { get; set; }
    public string profile_text_color { get; set; }
    public bool following { get; set; }
    public object profile_location { get; set; }
    public int followers_count { get; set; }
    public int listed_count { get; set; }
    public bool is_translator { get; set; }
    public string lang { get; set; }
    public bool contributors_enabled { get; set; }
    public bool follow_request_sent { get; set; }
    public string screen_name { get; set; }
    public string description { get; set; }
    public int favourites_count { get; set; }
    public bool verified { get; set; }
}

public class Entities
{
    public Urls url { get; set; }
    public Description description { get; set; }
}

public class Urls
{
    public Url[] urls { get; set; }
}

public class Url
{
    public int[] indices { get; set; }
    public string url { get; set; }
    public string expanded_url { get; set; }
    public string display_url { get; set; }
}

public class Description
{
    public Url[] urls { get; set; }
}

[BsonNoId]
public class Retweeted_Status
{
    public long id { get; set; }
    public string id_str { get; set; }
    public string source { get; set; }
    public object coordinates { get; set; }
    public object place { get; set; }
    public bool retweeted { get; set; }
    public string created_at { get; set; }
    public bool truncated { get; set; }
    public object in_reply_to_user_id { get; set; }
    public object in_reply_to_user_id_str { get; set; }
    public int retweet_count { get; set; }
    public int favorite_count { get; set; }
    public bool possibly_sensitive { get; set; }
    public bool possibly_sensitive_appealable { get; set; }
    public string lang { get; set; }
    public string text { get; set; }
    public object in_reply_to_status_id { get; set; }
    public object in_reply_to_status_id_str { get; set; }
    public object in_reply_to_screen_name { get; set; }
    public User user { get; set; }
    public object geo { get; set; }
    public Entities1 entities { get; set; }
    public Extended_Entities extended_entities { get; set; }
    public object contributors { get; set; }
    public bool favorited { get; set; }
}

[BsonNoId]
public class Medium
{
    public string media_url { get; set; }
    public string media_url_https { get; set; }
    public string display_url { get; set; }
    public string type { get; set; }
    public Sizes sizes { get; set; }
    public long id { get; set; }
    public string id_str { get; set; }
    public int[] indices { get; set; }
    public string url { get; set; }
    public string expanded_url { get; set; }
    public long source_user_id { get; set; }
    public string source_user_id_str { get; set; }
    public long source_status_id { get; set; }
    public string source_status_id_str { get; set; }
}

public class Sizes
{
    public Size large { get; set; }
    public Size thumb { get; set; }
    public Size medium { get; set; }
    public Size small { get; set; }
}

public class Size
{
    public string resize { get; set; }
    public int w { get; set; }
    public int h { get; set; }
}

public class Extended_Entities
{
    public Medium[] media { get; set; }
}


public class Entities1
{
    public Url[] urls { get; set; }
    public Medium[] media { get; set; }
    public object[] hashtags { get; set; }
    public object[] symbols { get; set; }
    public User_Mentions[] user_mentions { get; set; }
}



[BsonNoId]
public class User_Mentions
{
    public string name { get; set; }
    public long id { get; set; }
    public string id_str { get; set; }
    public int[] indices { get; set; }
    public string screen_name { get; set; }
}
