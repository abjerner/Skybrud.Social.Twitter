---
order: 5
---

# Extended Tweets

As Twitter over time has changed the way tweets are structured (eg. adding support for more than one image, allowing more than 140 characters etc.), requests made to the Twitter API will by default use compatibility mode.

Compatibility mode will mean that even if a tweet contains more than one image, or contains more than 140 characters, the JSON returned by the Twitter API will only contain one image and only the 140 first characters of the tweet.

Also, as the image will typically be the last part of the tweet, you may experience that the media is mentioned after the 140 first characters, which means that the media won't be part of the default response.

Get get the additional information about the tweet(s), you can enable extended mode, which when getting a single tweet, can look like this:

```cshtml
@using Skybrud.Social.Twitter.Models.Statuses
@using Skybrud.Social.Twitter.Options.Statuses
@using Skybrud.Social.Twitter.Responses.Statuses
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{
    
    // Initialize the options
    TwitterGetStatusMessageOptions options = new TwitterGetStatusMessageOptions(930827848423825408) {
        TweetMode = TwitterTweetMode.Extended
    };

    // Make the call to the API
    TwitterGetStatusMessageResponse response = Model.Statuses.GetStatusMessage(options);

    // Get the tweet from the response body
    TwitterStatusMessage tweet = response.Body;

    // List the extended entities (if present)
    if (tweet.HasExtendedEntities) {
        foreach (var media in tweet.ExtendedEntities.Media) {
            <pre>@media.MediaUrl</pre>
        }
    }

}
```