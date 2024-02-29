---
order: 1
---

# Getting a tweet

If you already have the ID of a tweet (or status messages as they are called in the Twitter API), you can use the {{method:Skybrud.Social.Twitter.Endpoints.TwitterStatusesEndpoint.GetStatusMessage}} method to get information about that tweet:

```cshtml
@using Skybrud.Social.Twitter.Models.Statuses
@using Skybrud.Social.Twitter.Responses.Statuses
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{

    // Make the call to the Twitter API
    TwitterGetStatusMessageResponse response = Model.Statuses.GetStatusMessage(610040220470349824);

    // Get a reference to the tweet (from the response body)
    TwitterStatusMessage tweet = response.Body;

    // Write out some information about the tweet
    <pre>@tweet.Text</pre>
    <pre>@tweet.User.ScreenName</pre>
    <pre>@tweet.RetweetCount</pre>
    
}
```

An overloaded version of the method lets you specify an instance of {{class:Skybrud.Social.Twitter.Options.Statuses.TwitterGetStatusMessageOptions}} instead. Generally the options you have here will limit the amount of information returned in the JSON from the API, so you won't need them in most cases.

The example below shows how to use the TwitterStatusMessageOptions class - the properties have been defined with their standard values (equal to calling the overload described in the example above).

```cshtml
@using Skybrud.Social.Twitter.Models.Statuses
@using Skybrud.Social.Twitter.Options.Statuses
@using Skybrud.Social.Twitter.Responses.Statuses
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{

    // Initialize the options
    TwitterGetStatusMessageOptions options = new TwitterGetStatusMessageOptions {
        Id = 610040220470349824,
        IncludeEntities = true,
        IncludeMyRetweet = true,
        TrimUser = false
    };

    // Make the call to the Twitter API
    TwitterGetStatusMessageResponse response = Model.Statuses.GetStatusMessage(options);

    // Get a reference to the tweet (from the response body)
    TwitterStatusMessage tweet = response.Body;

    // Write out some information about the tweet
    <pre>@tweet.Text</pre>
    <pre>@tweet.User.ScreenName</pre>
    <pre>@tweet.RetweetCount</pre>
    
}
```