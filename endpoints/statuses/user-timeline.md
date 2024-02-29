---
order: 3
---

# User timeline

The `GetUserTimeline` method allows you to get the most recent tweets of a given user (called user timeline). The method comes in a few overloads since you might not always need to specify the extra options. 

For simple usage, you can specify either the ID of the user:


```cshtml
@using Skybrud.Social.Twitter.Models.Statuses
@using Skybrud.Social.Twitter.Responses.Statuses
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{

    TwitterGetUserTimelineResponse response = Model.Statuses.GetUserTimeline(319219802);

    foreach (TwitterStatusMessage tweet in response.Body) {
        <pre>@tweet.Text</pre>
    }

}
```

or the screen name:

```csharp
@using Skybrud.Social.Twitter.Models.Statuses
@using Skybrud.Social.Twitter.Responses.Statuses
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{

    TwitterGetUserTimelineResponse response = Model.Statuses.GetUserTimeline("skybrud");

    foreach (TwitterStatusMessage tweet in response.Body) {
        <pre>@tweet.Text</pre>
    }

}
```



## Options

Also by default, the API will return replies as well as retweets made by the user. If you wan't to filter those out, you can tell the API to so by specifying an instance of the `TwitterUserTimelineOptions` class:

```cshtml
@using Skybrud.Social.Twitter.Models.Statuses
@using Skybrud.Social.Twitter.Options.Statuses
@using Skybrud.Social.Twitter.Responses.Statuses
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{
    
    // Initialize the options
    TwitterGetUserTimelineOptions options = new TwitterGetUserTimelineOptions {
        ScreenName = "abjerner",
        ExcludeReplies = true,
        IncludeRetweets = false
    };
    
    // Make the call to the API
    TwitterGetUserTimelineResponse response = Model.Statuses.GetUserTimeline(options);

    // Iterate through the tweets from the response
    foreach (TwitterStatusMessage tweet in response.Body) {
        <pre>@tweet.Text</pre>
    }

}
```

One thing worth noticing is that the Twitter API will apply pagination, and *then* filter out replies and retweets. So assuming that you're requesting the 20 most recent tweets, and five of them are retweets, while the rest are regular tweets, the example above will only result in 15 tweets. So it may be easier to filter out replies and retweets in your own code.

### Pagination

By default, the Twitter API will only return the 20 most recent tweets by the specified user. You can also specify options for pagination, letting you get more tweets from the API. This could look like:

```cshtml
@using Skybrud.Social.Twitter.Models.Statuses
@using Skybrud.Social.Twitter.Options.Statuses
@using Skybrud.Social.Twitter.Responses.Statuses
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{
    
    // Set the initial options
    TwitterGetUserTimelineOptions options = new TwitterGetUserTimelineOptions {
        ScreenName = "abjerner",
        Count = 50
    };
    
    // Make the call to the API
    TwitterGetUserTimelineResponse response = Model.Statuses.GetUserTimeline(options);

    // Iterate through the tweets from the response
    foreach (TwitterStatusMessage tweet in response.Body) {
        <pre>@tweet.Text</pre>
    }

    if (response.Body.Length >= options.Count) {

        // Set the maximum ID for the next request (last ID minus one)
        options.MaxId = response.Body.Last().Id - 1;

        // Make another call to the API
        response = Model.Statuses.GetUserTimeline(options);

        // Iterate through the tweets
        foreach (TwitterStatusMessage tweet in response.Body) {
            <pre>@tweet.Text</pre>
        }

    }

}
```

This example will make two requests to the Twitter API, each returning 50 tweets (assuming that the user has more than 100 tweets).

Alternatively, you can also do pagination by additional parameters to the `GetUserTimeline` method:

```cshtml
@using Skybrud.Social.Twitter.Models.Statuses
@using Skybrud.Social.Twitter.Responses.Statuses
@inherits WebViewPage<Skybrud.Social.Twitter.TwitterService>

@{
    
    // Make the call to the API
    TwitterGetUserTimelineResponse response = Model.Statuses.GetUserTimeline("abjerner", 50);

    // Iterate through the tweets from the response
    foreach (TwitterStatusMessage tweet in response.Body) {
        <pre>@tweet.Text</pre>
    }

    if (response.Body.Length >= 50) {

        // Set the maximum ID for the next request (last ID minus one)
        long maxId = response.Body.Last().Id - 1;

        // Make another call to the API
        response = Model.Statuses.GetUserTimeline("abjerner", 50, maxId);

        // Iterate through the tweets
        foreach (TwitterStatusMessage tweet in response.Body) {
            <pre>@tweet.Text</pre>
        }

    }

}
```









